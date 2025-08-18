using Modbus_Connect;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Modbus_Connect
{
    
    public class Connect
    {
        private static Dictionary<string, TcpClient> clientMapping = new Dictionary<string, TcpClient>();

        // 新增 TcpClient 並命名
        public static bool ConnectTcpClient(string name, string strIP, int nPort, out string Description, int nAbnormalTimeOut = 1000)
        {
            Description = "";
            GlobalVar.SRCond = default(SENDRECEIVE_COND);
            if (clientMapping.ContainsKey(name))
            {
                Description = $"Name '{name}' already exists.";
                return false;
            }

            try
            {
                TcpClient tcpClient = new TcpClient();
                IPAddress address = IPAddress.Parse(strIP);
                IAsyncResult asyncResult = tcpClient.BeginConnect(address, nPort, null, null);
                bool isConnected = asyncResult.AsyncWaitHandle.WaitOne(nAbnormalTimeOut, exitContext: true);

                if (isConnected)
                {
                    clientMapping[name] = tcpClient;
                    Description = $"Successfully added client '{name}' with IP {strIP}:{nPort}.";
                    GlobalVar.SRCond.simulator = GlobalVar.Simulator;
                    GlobalVar.SRCond.portType = ((GlobalVar.Simulator != SIMULATOR.DVP) ? PORT_TYPE.TCP : PORT_TYPE.SOCKET_ASCII);
                    GlobalVar.SRCond.nSlaveID = 1;
                    GlobalVar.SRCond.TCP_Header = "0000";
                    GlobalVar.SRCond.nReceiveTimeOut = 300;
                    GlobalVar.SRCond.nRetryTimes = 3;
                    return true;
                }
                else
                {
                    Description = $"Failed to connect to {strIP}:{nPort}.";
                    tcpClient.Dispose();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Description = $"Error: {ex.Message}";
                return false;
            }
        }


        public static bool CloseSocket(string name, out string strDescript)

        {
            if (clientMapping.TryGetValue(name, out TcpClient tcpClient))
            {
                bool result = false;
                try
                {
                    tcpClient.Close();
                    tcpClient.Dispose();
                    strDescript = "CloseSocket() Success";
                    result = true;
                }
                catch (Exception ex)
                {
                    strDescript = "CloseSocket() Fail-" + ex;
                }

                return result;
            }
            else
            {
                strDescript = $"CloseSocket() Fail - Client with name '{name}' not found.";
                return false;
            }
        }

        public static void GetPortIP(SIMULATOR simulator, out string strIP, out int nPort)
        {
            strIP = "127.0.0.1";
            nPort = ((simulator == SIMULATOR.DVP) ? 10003 : 10002);
        }

        public static string GetDevAddr(SIMULATOR simulator, string DevName)
        {
            string text = Operation.Left(DevName, 1);
            if (text != "D")
            {
                return "";
            }

            int.TryParse(Operation.Mid(DevName, 2), out var result);
            string result2 = "";
            switch (simulator)
            {
                case SIMULATOR.AS:
                    {
                        int num = result;
                        result2 = num.ToString("X4");
                        break;
                    }
                case SIMULATOR.DVP:
                    result2 = (4096 + result).ToString("X4");
                    break;
            }

            return result2;
        }
        public static string FunctionCode0x01(int nSlaveID, string DevAddr, int nDevCount)
        {
            string text = Operation.ToHex(nSlaveID, bWord: false);
            DevAddr = Operation.Right("0000" + DevAddr, 4);
            string text2 = Operation.ToHex(nDevCount);
            return text + "01" + DevAddr + text2;
        }
        public static string FunctionCode0x03(int nSlaveID, string DevAddr, int nDevCount)
        {
            string text = Operation.ToHex(nSlaveID, bWord: false);
            DevAddr = Operation.Right("0000" + DevAddr, 4);
            string text2 = Operation.ToHex(nDevCount);
            return text + "03" + DevAddr + text2;
        }
        public static string FunctionCode0x05(int nSlaveID, string DevAddr, bool value)
        {
            string text = Operation.ToHex(nSlaveID, bWord: false);
            //DevAddr = Operation.Right("0000" + DevAddr, 4);
            //string text2 = Operation.ToHex(nDevCount);
            string text3 = "";
            if (value)
            {
                text3 = "FF00";
            }
            else { text3 = "0000"; }
            return text + "05" + DevAddr + text3;
            //01050001FF00
        }
        public static string FunctionCode0x06(int nSlaveID, string DevAddr, string strDevValue)
        {
            string text = Operation.ToHex(nSlaveID, bWord: false);
            DevAddr = Operation.Right("0000" + DevAddr, 4);
            strDevValue = Operation.Right("0000" + strDevValue, 4);
            return text + "06" + DevAddr + strDevValue;
        }

        public static string FunctionCode0x10(int nSlaveID, string DevAddr, int nDevCount, string strDevValue)
        {
            string text = Operation.ToHex(nSlaveID, bWord: false);
            DevAddr = Operation.Right("0000" + DevAddr, 4);
            string text2 = Operation.ToHex(nDevCount);
            strDevValue = strDevValue.PadLeft(4 * nDevCount, '0').ToUpper();
            string text3 = (strDevValue.Length / 2).ToString("X2");
            return text + "10" + DevAddr + text2 + text3 + strDevValue;
        }

        public static string FunctionCode0x0F(int nSlaveID, string DevAddr, int nDevCount, int value)
        {
            string text3 = "";
            string text = Operation.ToHex(nSlaveID, bWord: false);
            DevAddr = Operation.Right("0000" + DevAddr, 4);
            string text2 = Operation.ToHex(nDevCount);

            int byteCount = (nDevCount + 7) / 8;
            string byteCountHex = byteCount.ToString("X2");

            if (value == 1)
            {
                // ⚠️ int 最多支援 31 bits（bit31 是符號位不能用）
                if (nDevCount > 31)
                    throw new ArgumentException("最多只能寫入 31 個線圈（int 最大支援 32 bits）");

                // 產生 nDevCount 個 1 的二進位值，例如 n=5 → 0001_1111
                int binaryValue = (1 << nDevCount) - 1;

                // ✅ 將 int 轉成 byte[]，位元順序是「LSB-first」
                // 即 bit0 = M0、bit1 = M1、...、bit22 = M22
                byte[] bytes = BitConverter.GetBytes(binaryValue);
                /*
                 範例：binaryValue = 0x7FFFFF (M0~M22 = 1)
                 BitConverter.GetBytes(binaryValue) → [0xFF, 0xFF, 0x7F, 0x00]
                 LSB-first 排列，正確對應 Modbus bit 對應順序
                */

                // ✅ 只保留實際要傳送的 byte 數（例如 23 bits → 3 bytes）
                // 多餘的高位 byte 會裁掉
                Array.Resize(ref bytes, byteCount);
                /*
                 範例：
                 原本是 [0xFF, 0xFF, 0x7F, 0x00]
                 Resize 後是 [0xFF, 0xFF, 0x7F]
                 → 正確對應 M0~M22，bit23 = 0（padding）
                */

                // 將 byte[] 轉成 HEX 字串，如 "FFFF7F"
                text3 = BitConverter.ToString(bytes).Replace("-", "");
            }
            else
            {
                // value == 0 時，產生 byteCount 個 0
                text3 = new string('0', byteCount * 2);
            }

            // 組成 Modbus 0x0F 封包字串：SlaveID + 功能碼 + 起始地址 + 數量 + byteCount + 資料
            return text + "0F" + DevAddr + text2 + byteCountHex + text3;
        }

        public static bool DoFunctionCode0x01(string name, string DevAddr, int nDevCount, out SENDRECEIVE_INFO SRInfo)
        {
            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x01(GlobalVar.SRCond.nSlaveID, DevAddr, nDevCount);

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x01: {ex.Message}"
                };

                return false;
            }
        }
        public static bool DoFunctionCode0x03(string name, string DevAddr, int nDevCount, out SENDRECEIVE_INFO SRInfo)
        {
            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x03(GlobalVar.SRCond.nSlaveID, DevAddr, nDevCount);

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x03: {ex.Message}"
                };

                return false;
            }
        }
        public static bool DoFunctionCode0x05(string name, string DevAddr, bool value, out SENDRECEIVE_INFO SRInfo)
        {

            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x05(GlobalVar.SRCond.nSlaveID, DevAddr, value);//呼叫05的function 後面輸入的型態要確認

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x03: {ex.Message}"
                };

                return false;
            }
        }
        public static bool DoFunctionCode0x06(string name, string DevAddr, string strDevValue, out SENDRECEIVE_INFO SRInfo)
        {

            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x06(GlobalVar.SRCond.nSlaveID, DevAddr, strDevValue);

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x03: {ex.Message}"
                };

                return false;
            }
        }

        public static bool DoFunctionCode0x10(string name, string DevAddr, int nDevCount, string strDevValue, out SENDRECEIVE_INFO SRInfo)
        {
            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x10(GlobalVar.SRCond.nSlaveID, DevAddr, nDevCount, strDevValue);

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x03: {ex.Message}"
                };

                return false;
            }
        }
        public static bool DoFunctionCode0x0F(string name, string DevAddr, int nDevCount, int value, out SENDRECEIVE_INFO SRInfo)
        {
            SRInfo = default(SENDRECEIVE_INFO);

            // 從名稱映射中取得對應的 TcpClient

            try
            {
                // 生成 PDU 字串
                string sendStringPDU = FunctionCode0x0F(GlobalVar.SRCond.nSlaveID, DevAddr, nDevCount, value);

                // 傳送和接收資料
                return DoSendReceiveBytcpClient(name, sendStringPDU, GlobalVar.SRCond, out SRInfo);
            }
            catch (Exception ex)
            {
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"Error in DoFunctionCode0x0F: {ex.Message}"
                };
                return false;
            }
        }
        public static bool WriteRegister(string name, string DevName, int nDevCount, string WriteHexData, out SENDRECEIVE_INFO SRInfo)
        {
            string devAddr = GetDevAddr(GlobalVar.SRCond.simulator, DevName);
            return DoFunctionCode0x10(name, devAddr, nDevCount, WriteHexData, out SRInfo);
        }

        public static string ReadRegister(string name, string DevName, out SENDRECEIVE_INFO SRInfo)
        {
            string devAddr = GetDevAddr(GlobalVar.SRCond.simulator, DevName);
            if (!DoFunctionCode0x03(name, devAddr, 1, out SRInfo))
            {
                return "";
            }

            string text = "";
            string text2 = "";
            if (GlobalVar.SRCond.portType == PORT_TYPE.SOCKET_ASCII)
            {
                text = Operation.Mid(SRInfo.ReceiveString, 6, 2);
                text2 = Operation.Mid(SRInfo.ReceiveString, 8);
            }
            else
            {
                text = Operation.Mid(SRInfo.ReceiveString, 17, 2);
                text2 = Operation.Mid(SRInfo.ReceiveString, 19);
            }

            int num = Convert.ToInt16(text, 16);
            return Operation.Left(text2, num * 2);
        }

        public static bool DoSendReceiveBytcpClient(string name, string SendStringPDU, SENDRECEIVE_COND SRCond, out SENDRECEIVE_INFO SRInfo)
        {
            if (clientMapping.TryGetValue(name, out TcpClient tcpClient))
            {
                bool flag = false;
                bool flag2 = false;
                int num = 0;
                string ErrorDescript = "";
                SRInfo = default(SENDRECEIVE_INFO);
                SRInfo.SendString = SendStringByPortType(SRCond.portType, SendStringPDU, SRCond.TCP_Header);
                do
                {
                    Application.DoEvents();
                    num++;
                    flag = DoSendBytcpClient(tcpClient, SRCond.portType, SRInfo.SendString, out ErrorDescript);
                    if (!flag)
                    {
                        break;
                    }

                    flag2 = DoReceiveBytcpClient(tcpClient, SRCond.portType, out SRInfo.ReceiveString, out ErrorDescript, SRCond.nReceiveTimeOut);
                }
                while ((flag2 || num < SRCond.nRetryTimes) && !GlobalVar.bStopProgram && !flag2);
                if (!flag)
                {
                    SRInfo.bProcessOK = false;
                    SRInfo.Descript = "PC => 傳送通訊失敗(" + ErrorDescript + ")";
                }
                else if (!flag2)
                {
                    SRInfo.bProcessOK = false;
                    SRInfo.Descript = "PC <= 接收通訊失敗(" + ErrorDescript + ")";
                }
                else
                {
                    /*0000 0000 0003 01 8F03 index13 指到 0 num+2 = 15 指到 8 所以index 15 16 => 8F 
                      num2 + 4 = 17 → index 17 18 => Exception Code "03"
                    */
                    int num2 = ((SRCond.portType == PORT_TYPE.TCP) ? 13 : 2);
                    string strSource = Operation.Mid(SRInfo.ReceiveString, num2 + 2, 2);
                    if (Operation.Left(strSource, 1) == "8" || Operation.Left(strSource, 1) == "9")
                    {
                        flag2 = false;
                        SRInfo.bProcessOK = false;
                        string text = Operation.Mid(SRInfo.ReceiveString, num2 + 4, 2);
                        SRInfo.Descript = "接收通訊失敗(接收到ExceptionCode 0x" + text + ")";
                    }
                    else
                    {
                        SRInfo.bProcessOK = true;
                        SRInfo.Descript = "傳送接收通訊成功";
                    }
                }

                return flag2;
            }
            else
            {
                // 無法找到指定名稱的 TcpClient
                SRInfo = new SENDRECEIVE_INFO
                {
                    bProcessOK = false,
                    Descript = $"TcpClient with name '{name}' not found."
                };

                return false;
            }

        }

        private static bool DoSendBytcpClient(TcpClient tcpclient, PORT_TYPE portType, string SendString, out string ErrorDescript)
        {
            ErrorDescript = "";
            bool result = false;
            switch (portType)
            {
                case PORT_TYPE.TCP:
                    {
                        byte[] array = new byte[SendString.Length / 2];
                        for (int i = 0; i < SendString.Length / 2; i++)
                        {
                            //array[i] = Convert.ToByte(Operation.Mid(SendString, i * 2 + 1, 2), 16);
                            array[i] = Convert.ToByte(SendString.Substring(i * 2, 2), 16); //1140522 這兩行一樣功能 就是取兩位 Hex 轉 byte
                        }

                        if (tcpclient.Connected)
                        {
                            if (tcpclient == null)
                            {
                                break;
                            }

                            try
                            {
                                NetworkStream stream2 = tcpclient.GetStream();
                                if (stream2.CanWrite)
                                {
                                    stream2.Write(array, 0, array.Length);
                                }

                                if (!stream2.CanRead)
                                {
                                    ErrorDescript = "網路通訊連線失敗";
                                    return result;
                                }

                                stream2.Flush();
                            }
                            catch (SystemException ex2)
                            {
                                ErrorDescript = "發生 try-catch 意外：\r\n\r\n" + ex2.Message;
                                return result;
                            }

                            break;
                        }

                        ErrorDescript = "TCPClient 未連線或已斷線。";
                        return result;
                    }
                case PORT_TYPE.SOCKET_ASCII:
                    if (tcpclient == null || !tcpclient.Connected)
                    {
                        break;
                    }

                    try
                    {
                        NetworkStream stream = tcpclient.GetStream();
                        byte[] bytes = Encoding.ASCII.GetBytes(SendString);
                        string @string = Encoding.ASCII.GetString(bytes);
                        if (stream.CanWrite)
                        {
                            stream.Write(bytes, 0, bytes.Length);
                        }

                        if (!stream.CanRead)
                        {
                            ErrorDescript = "網路通訊連線失敗";
                            return result;
                        }

                        stream.Flush();
                    }
                    catch (SystemException ex)
                    {
                        ErrorDescript = "發生 try-catch 意外：\r\n\r\n" + ex.Message;
                        return result;
                    }

                    break;
            }

            return true;
        }

        private static bool DoReceiveBytcpClient(TcpClient tcpClient, PORT_TYPE portType, out string ReceiveString, out string ErrorDescript, int nTimeOut = 100)
        {
            DateTime now = DateTime.Now;
            byte[] array = new byte[0];
            bool flag = false;
            ErrorDescript = "";
            ReceiveString = "";
            if (nTimeOut <= 100)
            {
                nTimeOut = 100;
            }

            Application.DoEvents();
            do
            {
                if (tcpClient == null || !tcpClient.Connected || tcpClient.Available == 0)
                {
                    continue;
                }

                now = DateTime.Now;
                NetworkStream stream = tcpClient.GetStream();
                if (!stream.DataAvailable)
                {
                    continue;
                }

                int available = tcpClient.Available;
                Array.Resize(ref array, available);
                try
                {
                    int num = stream.Read(array, 0, array.Length);
                    if (portType == PORT_TYPE.SOCKET_ASCII)
                    {
                        ReceiveString += Encoding.ASCII.GetString(array);
                        if (Operation.Left(ReceiveString, 1) == ":" && Operation.Right(ReceiveString, 2) == "\r\n")
                        {
                            flag = true;
                        }

                        continue;
                    }

                    string text = BitConverter.ToString(array).Replace("-", "");
                    ReceiveString += text;
                    string strSource = Operation.Left(text, 12);
                    string text2 = Operation.Mid(text, 13);
                    int num2 = Convert.ToInt32(Operation.Mid(strSource, 9, 4), 16);
                    if (text2.Length / 2 >= num2)
                    {
                        flag = true;
                    }
                }
                catch (SystemException ex)
                {
                    ErrorDescript = "發生 try-catch 意外：\r\n\r\n" + ex.Message;
                    MessageBox.Show(ErrorDescript);
                }
            }
            while (!((DateTime.Now - now).TotalMilliseconds >= (double)nTimeOut) && !GlobalVar.bStopProgram && !flag);
            return flag;
        }

        private static string SendStringByPortType(PORT_TYPE portType, string SendStringPDU, string TCP_Header = "0000")
        {
            string text = SendStringPDU;
            switch (portType)
            {
                case PORT_TYPE.SOCKET_ASCII:
                    {
                        string text3 = Operation.LRC(text);
                        text += text3;
                        text = ":" + text + "\r\n";
                        break;
                    }
                case PORT_TYPE.TCP:
                    {
                        string text2 = Operation.ToHex(text.Length / 2);
                        text = TCP_Header + "0000" + text2 + text;
                        break;
                    }
            }

            return text;
        }
    }
}