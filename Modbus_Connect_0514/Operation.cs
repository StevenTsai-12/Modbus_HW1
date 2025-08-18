using System;
using System.Globalization;

namespace Modbus_Connect
{

    public class Operation
    {
        public static string Right(string strSource, int nLength)
        {
            if (string.IsNullOrEmpty(strSource) || nLength < 0)
            {
                return "";
            }

            if (nLength > strSource.Length)
            {
                return strSource;
            }

            return strSource.Substring(strSource.Length - nLength, nLength);
        }

        public static string Left(string strSource, int nLength)
        {
            if (string.IsNullOrEmpty(strSource) || nLength < 0)
            {
                return "";
            }

            if (nLength > strSource.Length)
            {
                return strSource;
            }

            return strSource.Substring(0, nLength);
        }

        public static string Mid(string strSource, int nStartPosition, int nLength)
        {
            if (string.IsNullOrEmpty(strSource))
            {
                return "";
            }

            string strSource2 = Right(strSource, strSource.Length - nStartPosition + 1);
            return Left(strSource2, nLength);
        }

        public static string Mid(string strData, int nStartPosition)
        {
            if (string.IsNullOrEmpty(strData))
            {
                return "";
            }

            return Right(strData, strData.Length - nStartPosition + 1);
        }

        public static string ToHex(int nDec, bool bWord = true)
        {
            string strSource = Convert.ToString(nDec, 16);
            int num = (bWord ? 4 : 2);
            strSource = Right(strSource, num);
            return strSource.PadLeft(num, '0').ToUpper();
        }

        public static string LRC(string strData)
        {
            int num = 0;
            strData = strData.Replace(" ", "");
            if (string.IsNullOrEmpty(strData))
            {
                strData = "";
            }

            string text = strData;
            string text2 = "";
            try
            {
                for (int i = 0; i < strData.Length; i += 2)
                {
                    string s = Left(text, 2);
                    text = Mid(text, 3);
                    num += int.Parse(s, NumberStyles.HexNumber);
                }

                return Right($"{(num ^ 0xFF) + 1:X2}", 2);
            }
            catch
            {
                return "";
            }
        }
    }
}