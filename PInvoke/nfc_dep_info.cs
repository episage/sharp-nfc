using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_dep_info
     * @brief NFC target information in D.E.P. (Data Exchange Protocol) see ISO/IEC 18092 (NFCIP-1)
     */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class nfc_dep_info
    {
        /** NFCID3 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        Byte[] abtNFCID3;
        /** DID */
        Byte btDID;
        /** Supported send-bit rate */
        Byte btBS;
        /** Supported receive-bit rate */
        Byte btBR;
        /** Timeout value */
        Byte btTO;
        /** PP Parameters */
        Byte btPP;
        /** General Bytes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        Byte[] abtGB;
        int szGB;
        /** DEP mode */
        nfc_dep_mode ndm;
    } ;
}
