using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_device
     * @brief NFC device information
     */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct nfc_device
    {
        public IntPtr context;
        public IntPtr driver;
        public IntPtr driver_data;
        public IntPtr chip_data;

        /** Device name string, including device wrapper firmware */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.DEVICE_NAME_LENGTH)]
        public string name;
        /** Device connection string */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.NFC_BUFSIZE_CONNSTRING)]
        public string connstring;
        /** Is the CRC automaticly added, checked and removed from the frames */
        public bool bCrc;
        /** Does the chip handle parity bits, all parities are handled as data */
        public bool bPar;
        /** Should the chip handle frames encapsulation and chaining */
        public bool bEasyFraming;
        /** Should the chip try forever on select? */
        public bool bInfiniteSelect;
        /** Should the chip switch automatically activate ISO14443-4 when
            selecting tags supporting it? */
        public bool bAutoIso14443_4;
        /** Supported modulation encoded in a byte */
        public byte btSupportByte;
        /** Last reported error */
        public int last_error;
    }

//struct nfc_device {
//  const nfc_context *context;
//  const struct nfc_driver *driver;
//  void *driver_data;
//  void *chip_data;

//  /** Device name string, including device wrapper firmware */
//  char    name[DEVICE_NAME_LENGTH];
//  /** Device connection string */
//  nfc_connstring connstring;
//  /** Is the CRC automaticly added, checked and removed from the frames */
//  bool    bCrc;
//  /** Does the chip handle parity bits, all parities are handled as data */
//  bool    bPar;
//  /** Should the chip handle frames encapsulation and chaining */
//  bool    bEasyFraming;
//  /** Should the chip try forever on select? */
//  bool    bInfiniteSelect;
//  /** Should the chip switch automatically activate ISO14443-4 when
//      selecting tags supporting it? */
//  bool    bAutoIso14443_4;
//  /** Supported modulation encoded in a byte */
//  uint8_t  btSupportByte;
//  /** Last reported error */
//  int     last_error;
//};
}
