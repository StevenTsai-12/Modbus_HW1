using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;//寫D要用的
using System.Text;//寫D要用的
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus_Connect;
using System.Threading;


namespace MODBUS_teaching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Text = "Connect";
        }

        public bool isRunning = false;
        private Thread workerThread;
        //多筆寫入M用的
        private bool _batchOn = false; // 紀錄目前狀態，初始為 OFF
        //多筆寫入D用的
        // 放在 Form1 類別裡（方法外）
        private bool _dPatternActive = false;


        private void PLC_Connection()
        {
            string description = String.Empty;
            bool bCheckOK = false;         
           
            bCheckOK = Connect.ConnectTcpClient("Client1", txtIP1.Text, int.Parse(txtPort1.Text), out description);
            if (bCheckOK == false)
            {
                MessageBox.Show("連線失敗：" + "\r\n" + "\r\n" + description, "連線失敗");
                SENDRECEIVE_INFO srInfo;

                return; //連線失敗不繼續 
            }
            else
            {
                MessageBox.Show("連線成功：" + "\r\n" + "\r\n" + description, "連線成功");
            }
        }

        private void Write_MultiCoil()
        {
            string client_1_value = "";
            string resultText = "";

            //此處為寫入 AS 系列 M接點，為多筆寫入，從M0開始往後寫8位，狀態寫為true
            bool value_1 = Connect.DoFunctionCode0x0F("Client1", "0000", 23, 1, out GlobalVar.SRInfo); //M0-M22全部開啟
            if (value_1)
            {
                resultText += "成功多筆寫入" + "\r\n";
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            else
            {
                resultText += "❌ 多筆寫入失敗！\r\n";
                resultText += "錯誤描述: " + GlobalVar.SRInfo.Descript + "\r\n";
            }
            Console.WriteLine(resultText);

            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100000001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100010001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(resultText);

            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100160001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(resultText);

            //value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100160001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100000017", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(resultText);

            // 更新 UI
            Invoke(new Action(() =>
            {
                txtPLCCode.Text = resultText;
            }));
            Thread.Sleep(1000); // 每秒執行一次
        }

        private void Read_MultiRegisters()
        {
            string client_1_value = "";
            string client_2_value = "";

            while (isRunning)
            {
                string resultText = "";
                bool value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010300000064", GlobalVar.SRCond, out GlobalVar.SRInfo);
                if (value_1)
                {
                    resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                    resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                    resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                    client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                }
                bool value_2 = Connect.DoSendReceiveBytcpClient("Client1", "010300000064", GlobalVar.SRCond, out GlobalVar.SRInfo);
                if (value_2)
                {
                    resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                    resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                    resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                    client_2_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                }
                int j = 0;
                for (int i = 0; i < 100; i++)
                {
                    j = j + 4;
                    //resultText += "Client_1" + "  D" + i.ToString() + "= H" + client_1_value.Substring(14 + j, 4) + "   " + "Client_2" + "  D" + i.ToString() + "= H" + client_2_value.Substring(14 + j, 4) + "\r\n";
                    resultText += "Client_1" + "  D" + i.ToString() + "= H" + client_1_value.Substring(14 + j, 4) + "\r\n"; //1140520
                }
                Console.WriteLine(resultText);
                // 更新 UI
                Invoke(new Action(() =>
                {
                    txtPLCCode.Text = resultText;
                }));
                Thread.Sleep(1000); // 每秒執行一次
            }
        }

        private void M0_ON(bool M0)
        {
            string resultText = "";
            string client_1_value = "";
            //此處為寫入 AS 系列 M接點，為多筆寫入，從M0開始往後寫8位，狀態寫為true
            // Connect.DoFunctionCode0x05(IP, 位址, on/off, 回傳);
            bool value_1 = Connect.DoFunctionCode0x05("Client1", "0000", M0, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100000001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            // 更新 UI
            Invoke(new Action(() =>
            {
                txtPLCCode.Text = resultText;
                btnServo.Text = M0 ? "Servo off" : "Servo on";
                Servo.Text = M0 ? "開啟 COIL" : "關閉 COIL";
            }));
            Thread.Sleep(1000); // 每秒執行一次
        }
        private void M1_ON(bool M1)
        {
            string resultText = "";
            string client_1_value = "";
            //此處為寫入 AS 系列 M接點，為多筆寫入，從M0開始往後寫8位，狀態寫為true
            // Connect.DoFunctionCode0x05(IP, 位址, on/off, 回傳);
            bool value_1 = Connect.DoFunctionCode0x05("Client1", "0001", M1, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100010001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            // 更新 UI
            Invoke(new Action(() =>
            {
                txtPLCCode.Text = resultText;
                btnSwitch.Text = M1 ? "Shut down PR01" : "Switch to PR01";
                PR01.Text = M1 ? "開啟 COIL" : "關閉 COIL";
            }));
            Thread.Sleep(1000); // 每秒執行一次
        }
        private void M2_ON(bool M2)
        {
            string resultText = "";
            string client_1_value = "";
            //此處為寫入 AS 系列 M接點，為多筆寫入，從M0開始往後寫8位，狀態寫為true
            // Connect.DoFunctionCode0x05(IP, 位址, on/off, 回傳);
            bool value_1 = Connect.DoFunctionCode0x05("Client1", "0002", M2, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100020001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
          
            // 更新 UI
            Invoke(new Action(() =>
            {
                txtPLCCode.Text = resultText;
                btnM2.Text = M2 ? "M2 Off" : "M2 On";
                textM2.Text = M2 ? "開啟 COIL" : "關閉 COIL";
            }));
            Thread.Sleep(1000); // 每秒執行一次
        }
        private void M3_ON(bool M3)
        {
            string resultText = "";
            string client_1_value = "";
            //此處為寫入 AS 系列 M接點，為多筆寫入，從M0開始往後寫8位，狀態寫為true
            // Connect.DoFunctionCode0x05(IP, 位址, on/off, 回傳);
            bool value_1 = Connect.DoFunctionCode0x05("Client1", "0003", M3, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            value_1 = Connect.DoSendReceiveBytcpClient("Client1", "010100030001", GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (value_1)
            {
                resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
                resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n\r\n";

                client_1_value = GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            Console.WriteLine(client_1_value);
            // 更新 UI
            Invoke(new Action(() =>
            {
                txtPLCCode.Text = resultText;
                btnSwitch03.Text = M3 ? "Shut down PR03" : "Switch to PR03";
                PR03.Text = M3 ? "開啟 COIL" : "關閉 COIL";
            }));
            Thread.Sleep(1000); // 每秒執行一次
        }

        private void PLC_Connect(object sender, EventArgs e)
        {
            PLC_Connection();
        }
        //Test PLC Device M Multi-Write
        private void MultiCoil(object sender, EventArgs e)
        {
            Write_MultiCoil();
        }

        private void registers_Info(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                reg.Text = "Stop";
                // 啟動執行緒
                workerThread = new Thread(Read_MultiRegisters);
                workerThread.IsBackground = true; // 背景執行緒，程式結束時會自動終止
                workerThread.Start();
            }
            else
            {
                // 停止執行
                isRunning = false;
                reg.Text = "Runs";
                if (workerThread != null && workerThread.IsAlive)
                {
                    workerThread.Join(); // 等待執行緒結束
                }
            }
        }

        //PLC-1
        private bool ServoStatus = false;
        private void M0_writecoil(object sender, EventArgs e)
        {
            ServoStatus = !ServoStatus;
            M0_ON(ServoStatus);
        }
        private bool PR1Status = false;
        private void M1_writecoil(object sender, EventArgs e)
        {
            PR1Status = !PR1Status;
            M1_ON(PR1Status);
        }
        private bool M2Status = false;
        private void M2_writecoil(object sender, EventArgs e)
        {
            M2Status = !M2Status;
            M2_ON(M2Status);
        }
        private bool M3Status = false;
        private void M3_writecoil(object sender, EventArgs e)
        {
            M3Status = !M3Status;
            M3_ON(M3Status);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string clientName = "Client1";   //ConnectTcpClient連線名稱
            string startAddr = "0000";       // 從M0開始
            int count = 20;                  // M0~M19，共20筆資料
            int value = _batchOn ? 0 : 1;    // 寫的狀態（切換）

            bool ok = Connect.DoFunctionCode0x0F(clientName, startAddr, count, value, out GlobalVar.SRInfo);

            if (ok)
            {
                _batchOn = !_batchOn; //切換狀態
                txtPLCCode.Text = $"M0~M19 已經全部{(_batchOn ? "ON" : "OFF")}\r\n"
                                  + "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n"
                                  + "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            }
            else
            {
                txtPLCCode.Text = "批次寫入失敗：" + GlobalVar.SRInfo.Descript;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ConnectTcpClient連線名稱
            string clientName = "Client1";

            //讀取 M0 ~ M19，功能碼01，起始位址0000，筆數0014(=20)
            //PDU：01 01 00 00 00 14
            bool ok = Connect.DoSendReceiveBytcpClient(clientName, "010100000014",
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);

            string resultText;

            if (ok)
            {
                // 直接把顯示窗改成 M0=TRUE/FALSE 清單
                txtPLCCode.Text = FormatCoilsFromRx(GlobalVar.SRInfo.ReceiveString, 20, GlobalVar.SRCond.nSlaveID);
            }
            else
            {
                txtPLCCode.Text = "讀取失敗：" + GlobalVar.SRInfo.Descript;
            }

            //if (ok)
            //{
            //resultText = "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
            //resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            //resultText += "Result: " + GlobalVar.SRInfo.Descript + "\r\n";
            //}
            //else
            //{
            //resultText = "讀取失敗：" + GlobalVar.SRInfo.Descript + "\r\n";
            //resultText += "PC >> " + GlobalVar.SRInfo.SendString.Replace("\r\n", "\\r\\n") + "\r\n";
            //// 有時失敗仍會有回應內容，保留除錯
            //resultText += "PC << " + GlobalVar.SRInfo.ReceiveString.Replace("\r\n", "\\r\\n") + "\r\n";
            //}

            //// 顯示在右側白色文字框
            //txtPLCCode.Text = resultText;
        }

        /// 將 Read Coils 回應(十六進位字串) 解析成
        /// M0=TRUE/FALSE... 的清單。支援 TCP/ASCII；count=要顯示的點數。
        private static string FormatCoilsFromRx(string rxHex, int count, int unitId)
        {
            if (string.IsNullOrWhiteSpace(rxHex)) return "無回應";

            string s = rxHex.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToUpperInvariant();

            // 找到 "UnitId + 01(Read Coils)" 的起點 (同時適用 TCP/ASCII 回覆)
            string uid = unitId.ToString("X2");
            int idx = s.IndexOf(uid + "01");
            if (idx < 0 || s.Length < idx + 6) return "回應格式不符";

            // ByteCount 之後是資料位元組
            int byteCount = Convert.ToInt32(s.Substring(idx + 4, 2), 16);
            int dataStart = idx + 6;
            int needChars = byteCount * 2;
            if (s.Length < dataStart + needChars) return "資料長度不足";

            string dataHex = s.Substring(dataStart, needChars);

            // 轉成位元組
            var bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
                bytes[i] = Convert.ToByte(dataHex.Substring(i * 2, 2), 16);

            // LSB-first 解析成布林
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int bi = i / 8, bit = i % 8;
                bool on = ((bytes[bi] >> bit) & 1) == 1;  // LSB-first
                sb.AppendLine($"M{i}={(on ? "TRUE" : "FALSE")}");
            }
            return sb.ToString();
        }

        private void txtPLCCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string clientName = "Client1"; // 建立連線時用的名稱

            // 讀取 Y0.0~Y0.9：FC=01, start=A000, count=000A(=10)
            bool ok = Connect.DoSendReceiveBytcpClient(clientName, "0101A000000A",
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (!ok)
            {
                txtPLCCode.Text = "讀取Y失敗：" + GlobalVar.SRInfo.Descript;
                return;
            }

            // 把回應解析為布林並格式化成 Y0.0=TRUE/FALSE ...
            txtPLCCode.Text = FormatYBitsFromRx(GlobalVar.SRInfo.ReceiveString,
                                                count: 10,
                                                unitId: GlobalVar.SRCond.nSlaveID,
                                                baseWordIndex: 0,   // Y0.*
                                                startBitIndex: 0);  // 從 .0 開始
        }

        /// 解析 Read Coils 回應，輸出 Y{word}.{bit}=TRUE/FALSE 清單。
        /// - 支援 Modbus TCP/ASCII（會從回應中尋找 "UnitId + 01"）
        /// - LSB-first：資料位元組的 bit0 對應起始位址
        private static string FormatYBitsFromRx(string rxHex, int count, int unitId,
                                                int baseWordIndex, int startBitIndex)
        {
            if (string.IsNullOrWhiteSpace(rxHex)) return "無回應";

            string s = rxHex.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToUpperInvariant();

            // 找 "UnitId + 01(Read Coils)" 的位置
            string uid = unitId.ToString("X2");
            int idx = s.IndexOf(uid + "01");
            if (idx < 0 || s.Length < idx + 6) return "回應格式不符";

            // 讀出 ByteCount 與資料區
            int byteCount = Convert.ToInt32(s.Substring(idx + 4, 2), 16);
            int dataStart = idx + 6;
            int needChars = byteCount * 2;
            if (s.Length < dataStart + needChars) return "資料長度不足";

            string dataHex = s.Substring(dataStart, needChars);

            // 轉位元組
            var bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
                bytes[i] = Convert.ToByte(dataHex.Substring(i * 2, 2), 16);

            // 逐點 LSB-first 取值並輸出成 Y{word}.{bit}=TRUE/FALSE
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int bi = (startBitIndex + i) / 8;
                int bit = (startBitIndex + i) % 8;
                bool on = bi < bytes.Length && ((bytes[bi] >> bit) & 1) == 1;

                int word = baseWordIndex + (startBitIndex + i) / 16; // 每 16 點換一個 Y{word}
                int bitInWord = (startBitIndex + i) % 16;

                sb.AppendLine($"Y{word}.{bitInWord}={(on ? "TRUE" : "FALSE")}");
            }
            return sb.ToString();
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            string clientName = "Client1";
            int unitId = GlobalVar.SRCond.nSlaveID;
            string startAddrHex = "0000"; // D0
            int count = 20;               // D0~D19

            ushort[] values = _dPatternActive
                ? Enumerable.Repeat((ushort)0, count).ToArray()
                : Enumerable.Range(0, count).Select(i => (ushort)(1000 + i * 100)).ToArray();

            string pdu = BuildWriteMultiRegPdu(unitId, startAddrHex, values);

            bool ok = Connect.DoSendReceiveBytcpClient(clientName, pdu, GlobalVar.SRCond, out GlobalVar.SRInfo);

            var sb = new StringBuilder();
            if (ok)
            {
                string action = _dPatternActive ? "已歸零" : "已寫入資料";
                sb.AppendLine(action + "：D0~D" + (count - 1));
                for (int i = 0; i < values.Length; i++)
                {
                    sb.Append("D").Append(i).Append("=").Append(values[i]);
                    if (i != values.Length - 1) sb.Append(", ");
                }
                sb.AppendLine();

                var sr = GlobalVar.SRInfo;                
                string send = (sr.SendString != null) ? sr.SendString : "";
                string recv = (sr.ReceiveString != null) ? sr.ReceiveString : "";
                string desc = (sr.Descript != null) ? sr.Descript : "";


                sb.AppendLine("PC >> " + send.Replace("\r\n", "\\r\\n"));
                sb.AppendLine("PC << " + recv.Replace("\r\n", "\\r\\n"));
                sb.AppendLine("Result: " + desc);

                _dPatternActive = !_dPatternActive;
            }
            else
            {
                var sr = GlobalVar.SRInfo;                 
                string send = (sr.SendString != null) ? sr.SendString : "";
                string recv = (sr.ReceiveString != null) ? sr.ReceiveString : "";
                string desc = (sr.Descript != null) ? sr.Descript : "";


                sb.AppendLine("多筆寫入失敗：" + desc);
                sb.AppendLine("PC >> " + send.Replace("\r\n", "\\r\\n"));
                sb.AppendLine("PC << " + recv.Replace("\r\n", "\\r\\n"));
            }

            txtPLCCode.Text = sb.ToString();
        }
        private static string BuildWriteMultiRegPdu(int unitId, string startAddrHex, ushort[] values)
        {
            int count = values.Length;
            string countHex = count.ToString("X4");            // 0014
            string byteCountHex = (count * 2).ToString("X2");  // 0x28
            var dataHex = new StringBuilder();
            foreach (ushort v in values) dataHex.Append(v.ToString("X4")); // Big-endian
            return unitId.ToString("X2") + "10" + startAddrHex + countHex + byteCountHex + dataHex.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string clientName = "Client1";                 // ConnectTcpClient名稱
            int unitId = GlobalVar.SRCond.nSlaveID;        // 站號
                                                           // 讀 D0~D19：FC=03、起始位址=0000(D0)、數量=0014(20)
            bool ok = Connect.DoSendReceiveBytcpClient(clientName, "010300000014",
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (!ok)
            {
                txtPLCCode.Text = "讀取D失敗：" + GlobalVar.SRInfo.Descript;
                return;
            }

            // 解析回應，20 筆 ushort 值（Big-endian）
            ushort[] regs = ParseHoldingRegisters(GlobalVar.SRInfo.ReceiveString, 20, unitId);

            // 顯示（十進位；若要看 16 進位可加 $" (0x{regs[i]:X4})"）
            var sb = new StringBuilder();
            for (int i = 0; i < regs.Length; i++)
                sb.AppendLine($"D{i}={regs[i]}");
            txtPLCCode.Text = sb.ToString();
        }

        // 解析 Modbus Read Holding Registers(0x03) 回應，回傳前 count 筆 ushort
        private static ushort[] ParseHoldingRegisters(string rxHex, int count, int unitId)
        {
            var result = new ushort[count];
            if (string.IsNullOrWhiteSpace(rxHex)) return result;

            string s = rxHex.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToUpperInvariant();

            // 尋找 "UnitId + 03"
            string uid = unitId.ToString("X2");
            int idx = s.IndexOf(uid + "03");
            if (idx < 0 || s.Length < idx + 6) return result;

            // ByteCount & 資料區
            int byteCount = Convert.ToInt32(s.Substring(idx + 4, 2), 16);    
            int dataStart = idx + 6;
            int needChars = byteCount * 2;
            if (s.Length < dataStart + needChars) needChars = s.Length - dataStart;
            if (needChars < 4) return result;

            string dataHex = s.Substring(dataStart, needChars);

            // 逐兩個 byte（Big-endian）轉成 ushort
            int n = Math.Min(count, dataHex.Length / 4);
            for (int i = 0; i < n; i++)
            {
                int hi = Convert.ToInt32(dataHex.Substring(i * 4 + 0, 2), 16);
                int lo = Convert.ToInt32(dataHex.Substring(i * 4 + 2, 2), 16);
                result[i] = (ushort)((hi << 8) | lo);
            }
            return result;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string clientName = "Client1"; // Connect名稱

            // 讀取 M0：FC=01、start=0000、count=0001
            bool ok = Connect.DoSendReceiveBytcpClient(clientName, "010100000001",
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (ok)
            {
                // 直接把顯示窗改成 M0=TRUE/FALSE
                txtPLCCode.Text = FormatCoilsFromRx(GlobalVar.SRInfo.ReceiveString, 1, GlobalVar.SRCond.nSlaveID);
            }
            else
            {
                // 失敗時顯示原因＋原始封包（避免 null 造成例外）
                var sr = GlobalVar.SRInfo;
                string desc = (sr.Descript != null) ? sr.Descript : "(no desc)";
                string send = (sr.SendString != null) ? sr.SendString : "(no send)";
                string recv = (sr.ReceiveString != null) ? sr.ReceiveString : "(no recv)";

                txtPLCCode.Text = "讀取 M0 失敗：" + desc + "\r\n"
                                + "PC >> " + send.Replace("\r\n", "\\r\\n") + "\r\n"
                                + "PC << " + recv.Replace("\r\n", "\\r\\n");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string clientName = "Client1";                 // Connect 名稱
            int unitId = GlobalVar.SRCond.nSlaveID;        // 站號 

            // 寫單一保持暫存器：FC=06，位址 D0=0000，值=10000(0x2710)
            string pdu = unitId.ToString("X2") + "06" + "0000" + 10000.ToString("X4");

            bool ok = Connect.DoSendReceiveBytcpClient(clientName, pdu,
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);

            // 安全取出回傳字串（避免 null）
            var sr = GlobalVar.SRInfo;
            string send = (sr.SendString != null) ? sr.SendString : "(no send)";
            string recv = (sr.ReceiveString != null) ? sr.ReceiveString : "(no recv)";
            string desc = (sr.Descript != null) ? sr.Descript : "(no desc)";

            if (ok)
            {
                txtPLCCode.Text = "寫入成功：D0=10000\r\n"
                                + "PC >> " + send.Replace("\r\n", "\\r\\n") + "\r\n"
                                + "PC << " + recv.Replace("\r\n", "\\r\\n") + "\r\n"
                                + "Result: " + desc;
            }
            else
            {
                txtPLCCode.Text = "寫入 D0 失敗：" + desc + "\r\n"
                                + "PC >> " + send.Replace("\r\n", "\\r\\n") + "\r\n"
                                + "PC << " + recv.Replace("\r\n", "\\r\\n");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string clientName = "Client1";              // 與 Connect 時的名稱一致
            int unitId = GlobalVar.SRCond.nSlaveID;     // 站號(通常為 1)

            // 讀 D0 一筆：01 03 00 00 00 01
            bool ok = Connect.DoSendReceiveBytcpClient(clientName, "010300000001",
                                                       GlobalVar.SRCond, out GlobalVar.SRInfo);
            if (ok)
            {
                // 用你已經有的解析函式，取回一筆
                ushort[] regs = ParseHoldingRegisters(GlobalVar.SRInfo.ReceiveString, 1, unitId);
                ushort d0 = regs[0];

                // 顯示十進位與十六進位
                txtPLCCode.Text = $"D0={d0} (0x{d0:X4})";
            }
            else
            {
                // 失敗時顯示原因與原始封包（做 null 防呆）
                var sr = GlobalVar.SRInfo;
                string desc = (sr.Descript != null) ? sr.Descript : "(no desc)";
                string send = (sr.SendString != null) ? sr.SendString : "(no send)";
                string recv = (sr.ReceiveString != null) ? sr.ReceiveString : "(no recv)";

                txtPLCCode.Text = "讀取 D0 失敗：" + desc + "\r\n"
                                + "PC >> " + send.Replace("\r\n", "\\r\\n") + "\r\n"
                                + "PC << " + recv.Replace("\r\n", "\\r\\n");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 1) 若有背景讀取（例如你 registers_Info 開的執行緒），先停掉
            if (isRunning)
            {
                isRunning = false;
                reg.Text = "Runs";
                if (workerThread != null && workerThread.IsAlive)
                    workerThread.Join(); // 等待結束，避免邊斷線邊收資料
            }

            // 2) 關閉與 PLC 的連線
            string name = "Client1";   // 連線時用的名稱
            string desc;
            bool ok = Connect.CloseSocket(name, out desc);

            // 3) 顯示結果
            txtPLCCode.Text = (ok ? "斷線成功" : "斷線失敗") + "：" + desc;
        }
    }
}
