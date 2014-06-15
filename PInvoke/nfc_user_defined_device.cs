using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct nfc_user_defined_device
    {
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.DEVICE_NAME_LENGTH)]
        public string connstring;
        public bool optional;
    }
}
