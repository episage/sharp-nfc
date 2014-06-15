using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class nfc_driver
    {
        //const char *name;
        public string name;
        //const scan_type_enum scan_type;
        public scan_type_enum scan_type;
        //size_t (*scan)(const nfc_context *context, nfc_connstring connstrings[], const size_t connstrings_len);
        public delegate UIntPtr scan_Delegate(ref nfc_context context, string[] connstrings, int connstrings_len);
        scan_Delegate scan;
        //struct nfc_device *(*open)(const nfc_context *context, const nfc_connstring connstring);
        public delegate void open_Delegate(ref nfc_context context, string connstring);
        open_Delegate open;
        //void (*close)(struct nfc_device *pnd);
        public delegate char close_Delegate(ref nfc_device pnd);
        close_Delegate close;
        //const char *(*strerror)(const struct nfc_device *pnd);
        public delegate char strerror_Delegate(ref nfc_device pnd);
        strerror_Delegate strerror;

        //int (*initiator_init)(struct nfc_device *pnd);
        public delegate int initiator_init_Delegate(ref nfc_device pnd);
        initiator_init_Delegate initiator_init;
        //int (*initiator_init_secure_element)(struct nfc_device *pnd);
        public delegate int initiator_init_secure_element_Delegate(ref nfc_device pnd);
        initiator_init_secure_element_Delegate initiator_init_secure_element;
        //int (*initiator_select_passive_target)(struct nfc_device *pnd,  const nfc_modulation nm, const uint8_t *pbtInitData, const size_t szInitData, nfc_target *pnt);
        public delegate int initiator_select_passive_target_Delegate(ref nfc_device pnd, nfc_modulation nm, UIntPtr pbtInitData, int szInitData, IntPtr pnt);
        initiator_select_passive_target_Delegate initiator_select_passive_target;
        //int (*initiator_poll_target)(struct nfc_device *pnd, const nfc_modulation *pnmModulations, const size_t szModulations, const uint8_t uiPollNr, const uint8_t btPeriod, nfc_target *pnt);
        public delegate int initiator_poll_target_Delegate(ref nfc_device pnd, ref nfc_modulation pnmModulations, int szModulations, byte uiPollNr, byte btPeriod, IntPtr pnt);
        initiator_poll_target_Delegate initiator_poll_target;
        //int (*initiator_select_dep_target)(struct nfc_device *pnd, const nfc_dep_mode ndm, const nfc_baud_rate nbr, const nfc_dep_info *pndiInitiator, nfc_target *pnt, const int timeout);
        public delegate int initiator_select_dep_target_Delegate(ref nfc_device pnd, nfc_dep_mode ndm, nfc_baud_rate nbr, ref nfc_dep_info pndiInitiator, IntPtr pnt, int timeout);
        initiator_select_dep_target_Delegate initiator_select_dep_target;
        ////int (*initiator_deselect_target)(struct nfc_device *pnd);
        public delegate int initiator_deselect_target_Delegate(ref nfc_device pnd);
        initiator_deselect_target_Delegate initiator_deselect_target;

        ////int (*initiator_transceive_bytes)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTx, uint8_t *pbtRx, const size_t szRx, int timeout);
        public delegate int initiator_transceive_bytes_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTx, ref Byte pbtRx, UIntPtr szRx, int timeout);
        initiator_transceive_bytes_Delegate initiator_transceive_bytes;

        ////int (*initiator_transceive_bits)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTxBits, const uint8_t *pbtTxPar, uint8_t *pbtRx, uint8_t *pbtRxPar);
        public delegate int initiator_transceive_bits_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTxBits, ref Byte pbtTxPar, ref Byte pbtRx, ref Byte pbtRxPar);
        initiator_transceive_bits_Delegate initiator_transceive_bits;

        ////int (*initiator_transceive_bytes_timed)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTx, uint8_t *pbtRx, const size_t szRx, uint32_t *cycles);
        public delegate int initiator_transceive_bytes_timed_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTx, ref Byte pbtRx, uint szRx, UIntPtr cycles);
        initiator_transceive_bytes_timed_Delegate initiator_transceive_bytes_timed;

        ////int (*initiator_transceive_bits_timed)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTxBits, const uint8_t *pbtTxPar, uint8_t *pbtRx, uint8_t *pbtRxPar, uint32_t *cycles);
        public delegate int initiator_transceive_bits_timed_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTxBits, ref Byte pbtTxPar, ref Byte pbtRx, ref Byte pbtRxPar, UIntPtr cycles);
        initiator_transceive_bits_timed_Delegate initiator_transceive_bits_timed;

        ////int (*initiator_target_is_present)(struct nfc_device *pnd, const nfc_target *pnt);
        public delegate int initiator_target_is_present_Delegate(ref nfc_device pnd, IntPtr pnt);
        initiator_target_is_present_Delegate initiator_target_is_present;


        ////int (*target_init)(struct nfc_device *pnd, nfc_target *pnt, uint8_t *pbtRx, const size_t szRx, int timeout);
        public delegate int target_init_Delegate(ref nfc_device pnd, IntPtr pnt, ref Byte pbtRx, UIntPtr szRx, int timeout);
        target_init_Delegate target_init;

        ////int (*target_send_bytes)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTx, int timeout);
        public delegate int target_send_bytes_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTx, int timeout);
        target_send_bytes_Delegate target_send_bytes;

        ////int (*target_receive_bytes)(struct nfc_device *pnd, uint8_t *pbtRx, const size_t szRxLen, int timeout);
        public delegate int target_receive_bytes_Delegate(ref nfc_device pnd, ref Byte pbtRx, UIntPtr szRxLen, int timeout);
        target_receive_bytes_Delegate target_receive_bytes;

        ////int (*target_send_bits)(struct nfc_device *pnd, const uint8_t *pbtTx, const size_t szTxBits, const uint8_t *pbtTxPar);
        public delegate int target_send_bits_Delegate(ref nfc_device pnd, ref Byte pbtTx, UIntPtr szTxBits, ref Byte pbtTxPar);
        target_send_bits_Delegate target_send_bits;

        ////int (*target_receive_bits)(struct nfc_device *pnd, uint8_t *pbtRx, const size_t szRxLen, uint8_t *pbtRxPar);
        public delegate int target_receive_bits_Delegate(ref nfc_device pnd, ref Byte pbtRx, UIntPtr szRxLen, ref Byte pbtRxPar);
        target_receive_bits_Delegate target_receive_bits;


        ////int (*device_set_property_bool)(struct nfc_device *pnd, const nfc_property property, const bool bEnable);
        public delegate int device_set_property_bool_Delegate(ref nfc_device pnd, nfc_property property, bool bEnable);
        device_set_property_bool_Delegate device_set_property_bool;

        ////int (*device_set_property_int)(struct nfc_device *pnd, const nfc_property property, const int value);
        public delegate int device_set_property_int_Delegate(ref nfc_device pnd, nfc_property property, int value);
        device_set_property_int_Delegate device_set_property_int;

        ////int (*get_supported_modulation)(struct nfc_device *pnd, const nfc_mode mode, const nfc_modulation_type **const supported_mt);
        public delegate int get_supported_modulation_Delegate(ref nfc_device pnd, nfc_mode mode, ref nfc_modulation_type supported_mt);
        get_supported_modulation_Delegate get_supported_modulation;

        ////int (*get_supported_baud_rate)(struct nfc_device *pnd, const nfc_mode mode, const nfc_modulation_type nmt, const nfc_baud_rate **const supported_br);
        public delegate int get_supported_baud_rate_Delegate(ref nfc_device pnd, nfc_mode mode, nfc_modulation_type nmt, ref  nfc_baud_rate supported_br);
        get_supported_baud_rate_Delegate get_supported_baud_rate;

        ////int (*device_get_information_about)(struct nfc_device *pnd, char **buf);
        public delegate int device_get_information_about_Delegate(ref nfc_device pnd, ref char buf);
        device_get_information_about_Delegate device_get_information_about;


        ////int (*abort_command)(struct nfc_device *pnd);
        public delegate int abort_command_Delegate(ref nfc_device pnd);
        abort_command_Delegate abort_command;

        ////int (*idle)(struct nfc_device *pnd);
        public delegate int idle_Delegate(ref nfc_device pnd);
        idle_Delegate idle;

        ////int (*powerdown)(struct nfc_device *pnd);
        public delegate int powerdown_Delegate(ref nfc_device pnd);
        powerdown_Delegate powerdown;

    }
}
