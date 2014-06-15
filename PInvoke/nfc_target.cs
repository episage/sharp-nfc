using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_target
     * @brief NFC target structure
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct nfc_target
    {
        public nfc_iso14443a_info nti;
        public nfc_modulation nm;
    } ;
}
