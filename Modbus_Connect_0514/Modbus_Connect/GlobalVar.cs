using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus_Connect
{ 
public static class GlobalVar
{
    public static SIMULATOR Simulator = SIMULATOR.AS;

    public static SENDRECEIVE_COND SRCond = default(SENDRECEIVE_COND);

    public static SENDRECEIVE_INFO SRInfo = default(SENDRECEIVE_INFO);

    public static bool bStopProgram = false;
}
}