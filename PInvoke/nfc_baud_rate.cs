using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @enum nfc_baud_rate
     * @brief NFC baud rate enumeration
     */
    public enum nfc_baud_rate
    {
        NBR_UNDEFINED = 0,
        NBR_106,
        NBR_212,
        NBR_424,
        NBR_847,
    }
}
