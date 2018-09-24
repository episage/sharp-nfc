using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace SharpNFC.PInvoke
{
    internal static class Functions
    {
        /* Library initialization/deinitialization */
        //nfc_init
        //NFC_EXPORT void nfc_init(nfc_context **context) ATTRIBUTE_NONNULL(1);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void nfc_init(out IntPtr context);
        //nfc_exit
        //NFC_EXPORT void nfc_exit(nfc_context *context) ATTRIBUTE_NONNULL(1);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void nfc_exit(IntPtr context);

        /* NFC Device/Hardware manipulation */
        //nfc_open
        //NFC_EXPORT nfc_device *nfc_open(nfc_context *context, const nfc_connstring connstring) ATTRIBUTE_NONNULL(1);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nfc_open(IntPtr context, string connstring);
        //nfc_close
        //NFC_EXPORT void nfc_close(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void nfc_close(IntPtr pnd);
        //nfc_abbort_command
        //nfc_list_devices
        //NFC_EXPORT size_t nfc_list_devices(nfc_context *context, nfc_connstring connstrings[], size_t connstrings_len) ATTRIBUTE_NONNULL(1);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nfc_list_devices(IntPtr context, IntPtr connstrings, uint connstrings_len);
        //nfc_idle
        //NFC_EXPORT int nfc_idle(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_idle(IntPtr pnd);

        /* NFC initiator: act as "reader" */
        //nfc_initiator_init
        //NFC_EXPORT int nfc_initiator_init(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_init(IntPtr pnd);
        //nfc_initiator_init_secure_element
        //NFC_EXPORT int nfc_initiator_init_secure_element(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_init_secure_element(IntPtr pnd);
        //nfc_initiator_select_passive_target
        //NFC_EXPORT int nfc_initiator_select_passive_target(nfc_device *pnd, const nfc_modulation nm, const uint8_t *pbtInitData, const size_t szInitData, nfc_target *pnt);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_select_passive_target(IntPtr pnd, nfc_modulation nm, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbtInitData, uint szInitData, IntPtr pnt);
        //nfc_initiator_list_passive_targets
        //NFC_EXPORT int nfc_initiator_list_passive_targets(nfc_device *pnd, const nfc_modulation nm, nfc_target ant[], const size_t szTargets);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_list_passive_targets(IntPtr pnd, nfc_modulation nm, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]  nfc_target[] ant, uint szTargets);
        //nfc_initiator_poll_target
        //NFC_EXPORT int nfc_initiator_poll_target(nfc_device *pnd, const nfc_modulation *pnmTargetTypes, const size_t szTargetTypes, const uint8_t uiPollNr, const uint8_t uiPeriod, nfc_target *pnt);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_poll_target(IntPtr pnd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] nfc_modulation[] pnmTargetTypes, uint szTargetTypes, byte uiPollNr, byte uiPeriod, out nfc_target pnt);

        //NFC_EXPORT int nfc_initiator_select_dep_target(nfc_device *pnd, nfc_dep_mode ndm, nfc_baud_rate nbr, nfc_dep_info *pndiInitiator, nfc_target *pnt, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_select_dep_target(IntPtr pnd, nfc_dep_mode ndm, nfc_baud_rate nbr, ref nfc_dep_info pndiInitiator, IntPtr pnt, int timeout);
        //NFC_EXPORT int nfc_initiator_poll_dep_target(nfc_device *pnd, nfc_dep_mode ndm, nfc_baud_rate nbr, nfc_dep_info *pndiInitiator, nfc_target *pnt, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_poll_dep_target(IntPtr pnd, nfc_dep_mode ndm, nfc_baud_rate nbr, ref nfc_dep_info pndiInitiator, IntPtr pnt, int timeout);
        //NFC_EXPORT int nfc_initiator_deselect_target(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_deselect_target(IntPtr pnd);
        //NFC_EXPORT int nfc_initiator_transceive_bytes(nfc_device *pnd, uint8_t *pbtTx, size_t szTx, uint8_t *pbtRx, size_t szRx, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_transceive_bytes(IntPtr pnd, byte[] pbtTx, uint szTx, byte[] pbtRx, uint szRx, int timeout);
        //NFC_EXPORT int nfc_initiator_transceive_bits(nfc_device *pnd, uint8_t *pbtTx, size_t szTxBits, uint8_t *pbtTxPar, uint8_t *pbtRx, size_t szRx, uint8_t *pbtRxPar);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_transceive_bits(IntPtr pnd, byte[] pbtTx, uint szTxBits, byte[] pbtTxPar, byte[] pbtRx, uint szRx, byte[] pbtRxPar);
        //NFC_EXPORT int nfc_initiator_transceive_bytes_timed(nfc_device *pnd, uint8_t *pbtTx, size_t szTx, uint8_t *pbtRx, size_t szRx, uint32_t *cycles);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_transceive_bytes_timed(IntPtr pnd, byte[] pbtTx, uint szTx, byte[] pbtRx, uint szRx, ref uint cycles);
        //NFC_EXPORT int nfc_initiator_transceive_bits_timed(nfc_device *pnd, uint8_t *pbtTx, size_t szTxBits, uint8_t *pbtTxPar, uint8_t *pbtRx, size_t szRx, uint8_t *pbtRxPar, uint32_t *cycles);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_transceive_bits_timed(IntPtr pnd, byte[] pbtTx, uint szTxBits, byte[] pbtTxPar, byte[] pbtRx, uint szRx, byte[] pbtRxPar, ref uint cycles);
        //NFC_EXPORT int nfc_initiator_target_is_present(nfc_device *pnd, nfc_target *pnt);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_initiator_target_is_present(IntPtr pnd, IntPtr pnt);

        /* NFC target: act as tag (i.e. MIFARE Classic) or NFC target device. */
        //NFC_EXPORT int nfc_target_init(nfc_device *pnd, nfc_target *pnt, uint8_t *pbtRx, size_t szRx, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_target_init(IntPtr pnd, IntPtr pnt, byte[] pbtRx, uint szRx, int timeout);
        //NFC_EXPORT int nfc_target_send_bytes(nfc_device *pnd, uint8_t *pbtTx, size_t szTx, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_target_send_bytes(IntPtr pnd, byte[] pbtTx, uint szTx, int timeout);
        //NFC_EXPORT int nfc_target_receive_bytes(nfc_device *pnd, uint8_t *pbtRx, size_t szRx, int timeout);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_target_receive_bytes(IntPtr pnd, byte[] pbtRx, uint szRx, int timeout);
        //NFC_EXPORT int nfc_target_send_bits(nfc_device *pnd, uint8_t *pbtTx, size_t szTxBits, uint8_t *pbtTxPar);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_target_send_bits(IntPtr pnd, byte[] pbtTx, uint szTxBits, byte[] pbtTxPar);
        //NFC_EXPORT int nfc_target_receive_bits(nfc_device *pnd, uint8_t *pbtRx, size_t szRx, uint8_t *pbtRxPar);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_target_receive_bits(IntPtr pnd, byte[] pbtRx, uint szRx, byte[] pbtRxPar);

        /* Error reporting */
        //NFC_EXPORT char *nfc_strerror(nfc_device *pnd);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string nfc_strerror(IntPtr pnd);
        //NFC_EXPORT int nfc_strerror_r(nfc_device *pnd, char *buf, size_t buflen);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_strerror_r(IntPtr pnd, string buf, uint buflen);
        //NFC_EXPORT void nfc_perror(nfc_device *pnd, char *s);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nfc_perror(IntPtr pnd, string s);
        //NFC_EXPORT int nfc_device_get_last_error(nfc_device *pnd);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_get_last_error(IntPtr pnd);

        /* Special data accessors */
        //NFC_EXPORT char *nfc_device_get_name(nfc_device *pnd);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string nfc_device_get_name(IntPtr pnd);
        //NFC_EXPORT char *nfc_device_get_connstring(nfc_device *pnd);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string nfc_device_get_connstring(IntPtr pnd);
        //NFC_EXPORT int nfc_device_get_supported_modulation(nfc_device *pnd, nfc_mode mode,  nfc_modulation_type **supported_mt);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_get_supported_modulation(IntPtr pnd, nfc_mode mode, ref IntPtr supported_mt);
        //NFC_EXPORT int nfc_device_get_supported_baud_rate(nfc_device *pnd, nfc_mode mode, nfc_modulation_type nmt, nfc_baud_rate **supported_br);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_get_supported_baud_rate(IntPtr pnd, nfc_mode mode, nfc_modulation_type nmt, ref IntPtr supported_br);

        /* Properties accessors */
        //NFC_EXPORT int nfc_device_set_property_int(nfc_device *pnd, nfc_property property, int value);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_set_property_int(IntPtr pnd, nfc_property property, int value);
        //NFC_EXPORT int nfc_device_set_property_bool(nfc_device *pnd, nfc_property property, bool bEnable);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_set_property_bool(IntPtr pnd, nfc_property property, bool bEnable);

        /* Misc. functions */
        //NFC_EXPORT void iso14443a_crc(uint8_t *pbtData, size_t szLen, uint8_t *pbtCrc);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iso14443a_crc(byte[] pbtData, uint szLen, byte[] pbtCrc);
        //NFC_EXPORT void iso14443a_crc_append(uint8_t *pbtData, size_t szLen);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iso14443a_crc_append(byte[] pbtData, uint szLen);
        //NFC_EXPORT void iso14443b_crc(uint8_t *pbtData, size_t szLen, uint8_t *pbtCrc);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iso14443b_crc(byte[] pbtData, uint szLen, byte[] pbtCrc);
        //NFC_EXPORT void iso14443b_crc_append(uint8_t *pbtData, size_t szLen);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iso14443b_crc_append(byte[] pbtData, uint szLen);
        //NFC_EXPORT uint8_t *iso14443a_locate_historical_bytes(uint8_t *pbtAts, size_t szAts, size_t *pszTk);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte[] iso14443a_locate_historical_bytes(byte[] pbtAts, uint szAts, UIntPtr pszTk);

        //NFC_EXPORT void nfc_free(void *p);
        [DllImport("libnfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void nfc_free(IntPtr p);
        //NFC_EXPORT char *nfc_version(void);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string nfc_version();
        //NFC_EXPORT int nfc_device_get_information_about(nfc_device *pnd, char **buf);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nfc_device_get_information_about(IntPtr pnd, ref string buf);

        /* String converter functions */
        //NFC_EXPORT char *str_nfc_modulation_type(nfc_modulation_type nmt);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string str_nfc_modulation_type(nfc_modulation_type nmt);
        //NFC_EXPORT char *str_nfc_baud_rate(nfc_baud_rate nbr);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string str_nfc_baud_rate(nfc_baud_rate nbr);
        //NFC_EXPORT int str_nfc_target(char **buf, nfc_target *pnt, bool verbose);
        [DllImport("libnfc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int str_nfc_target(ref string buf, IntPtr pnt, bool verbose);

    }
}
