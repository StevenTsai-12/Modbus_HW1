using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus_Connect
{
    public struct SENDRECEIVE_COND
    {
        public SIMULATOR simulator;

        public PORT_TYPE portType;

        public int nSlaveID;

        public int nRetryTimes;

        public int nReceiveTimeOut;

        public string TCP_Header;
    }
}