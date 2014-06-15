using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @struct nfc_iso14443a_info
     * @brief NFC ISO14443A tag (MIFARE) information
     */
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct nfc_iso14443a_info
    {                            // COS JEST ZLEEEEE!!!
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 + 10 + 254 + 1 + 4 + 4+50)]
        //public byte[] lol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] abtAtqa;
        public byte btSak;
        public uint szUidLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] abtUid;
        public uint szAtsLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
        public byte[] abtAts; // Maximal theoretical ATS is FSD-2, FSD=256 for FSDI=8 in RATS
    } ;

    ///**
    // * @struct nfc_iso14443a_info
    // * @brief NFC ISO14443A tag (MIFARE) information
    // */
    //typedef struct {
    //  uint8_t  abtAtqa[2];
    //  uint8_t  btSak;
    //  size_t  szUidLen;
    //  uint8_t  abtUid[10];
    //  size_t  szAtsLen;
    //  uint8_t  abtAts[254]; // Maximal theoretical ATS is FSD-2, FSD=256 for FSDI=8 in RATS
    //} nfc_iso14443a_info;
}
