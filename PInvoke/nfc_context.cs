using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_context
     * @brief NFC library context
     * Struct which contains internal options, references, pointers, etc. used by library
     */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct nfc_context
    {
        //struct nfc_context {
        //  bool allow_autoscan;
        //  bool allow_intrusive_scan;
        //  uint32_t  log_level;
        //  struct nfc_user_defined_device user_defined_devices[MAX_USER_DEFINED_DEVICES];
        //  unsigned int user_defined_device_count;
        //};

        public bool allow_autoscan;
        public bool allow_intrusive_scan;
        public UInt32 log_level;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_USER_DEFINED_DEVICES)]
        public nfc_user_defined_device[] user_defined_devices;
        public uint user_defined_device_count;
    }
}
