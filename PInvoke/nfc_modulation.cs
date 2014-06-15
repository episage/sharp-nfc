using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_modulation
     * @brief NFC modulation structure
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct nfc_modulation
    {
        public nfc_modulation_type nmt;
        public nfc_baud_rate nbr;
    }
}
