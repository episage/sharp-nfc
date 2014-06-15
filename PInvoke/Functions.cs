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
        //00003418 T iso14443a_crc
        //00003464 T iso14443a_crc_append
        //000034c4 T iso14443a_locate_historical_bytes
        //000044f8 T nfc_abort_command
        //000037c4 T nfc_close
        /** @ingroup dev
         * @brief Close from a NFC device
         * @param pnd \a nfc_device struct pointer that represent currently used device
         *
         * Initiator's selected tag is closed and the device, including allocated \a nfc_device struct, is released.
         */
        [DllImport("libnfc.so")]
        public static extern void nfc_close(IntPtr pnd);
        //00004e00 T nfc_context_free
        //00004ba0 T nfc_context_new
        //00004998 T nfc_device_free
        //000046e8 T nfc_device_get_connstring
        //00004774 T nfc_device_get_information_about
        //000046d8 T nfc_device_get_last_error
        //000046e0 T nfc_device_get_name
        //00004728 T nfc_device_get_supported_baud_rate
        //000046f0 T nfc_device_get_supported_modulation
        //0000493c T nfc_device_new
        //00003d2c T nfc_device_set_property_bool
        //00003cf4 T nfc_device_set_property_int
        //000049b8 T nfc_emulate_target
        //00003774 T nfc_exit
        /** @ingroup lib
         * @brief Deinitialize libnfc.
         * Should be called after closing all open devices and before your application terminates.
         * @param context The context to deinitialize
         */
        [DllImport("libnfc.so")]
        public static extern void nfc_exit(IntPtr context);
        //00004770 T nfc_free
        //000044c0 T nfc_idle
        //000036b0 T nfc_init
        /** @ingroup lib
         * @brief Initialize libnfc.
         * This function must be called before calling any other libnfc function
         * @param context Output location for nfc_context
         */
        [DllImport("libnfc.so")]
        public static extern void nfc_init(IntPtr context);
        //0000409c T nfc_initiator_deselect_target
        //00003d64 T nfc_initiator_init
        //00003e5c T nfc_initiator_init_secure_element
        //000040d4 T nfc_initiator_list_passive_targets
        //00004008 T nfc_initiator_poll_dep_target
        //00003f60 T nfc_initiator_poll_target
        ///** @ingroup initiator
        // * @brief Polling for NFC targets
        // * @return Returns polled targets count, otherwise returns libnfc's error code (negative value).
        // *
        // * @param pnd \a nfc_device struct pointer that represent currently used device
        // * @param pnmModulations desired modulations
        // * @param szModulations size of \a pnmModulations
        // * @param uiPollNr specifies the number of polling (0x01 – 0xFE: 1 up to 254 polling, 0xFF: Endless polling)
        // * @note one polling is a polling for each desired target type
        // * @param uiPeriod indicates the polling period in units of 150 ms (0x01 – 0x0F: 150ms – 2.25s)
        // * @note e.g. if uiPeriod=10, it will poll each desired target type during 1.5s
        // * @param[out] pnt pointer on \a nfc_target (over)writable struct
        // */
        //int
        //nfc_initiator_poll_target(nfc_device *pnd,
        //                          const nfc_modulation *pnmModulations, const size_t szModulations,
        //                          const uint8_t uiPollNr, const uint8_t uiPeriod,
        //                          nfc_target *pnt)
        [DllImport("libnfc.so")]
        public static extern int nfc_initiator_poll_target(IntPtr pnd, nfc_modulation[] pnmModulations, uint szModulations, byte uiPollNr, byte uiPeriod, ref nfc_target pnt);
        //00003fb4 T nfc_initiator_select_dep_target
        //00003e94 T nfc_initiator_select_passive_target
        //0000430c T nfc_initiator_target_is_present
        //00004264 T nfc_initiator_transceive_bits
        //00004344 T nfc_initiator_transceive_bits_timed
        //00004210 T nfc_initiator_transceive_bytes
        //000042b8 T nfc_initiator_transceive_bytes_timed
        //000037e0 T nfc_list_devices
        /** @ingroup dev
         * @brief Scan for discoverable supported devices (ie. only available for some drivers)
         * @return Returns the number of devices found.
         * @param context The context to operate on, or NULL for the default context.
         * @param connstrings array of \a nfc_connstring.
         * @param connstrings_len size of the \a connstrings array.
         *
         */
        //NFC_EXPORT size_t nfc_list_devices(nfc_context *context, nfc_connstring connstrings[], size_t connstrings_len) ATTRIBUTE_NONNULL(1);
        [DllImport("libnfc.so")]
        public static extern uint nfc_list_devices(
            IntPtr context,
            IntPtr connstrings,
            uint connstrings_len);
        //00003b14 T nfc_open
        /** @ingroup dev
         * @brief Open a NFC device
         * @param context The context to operate on.
         * @param connstring The device connection string if specific device is wanted, \c NULL otherwise
         * @return Returns pointer to a \a nfc_device struct if successfull; otherwise returns \c NULL value.
         *
         * If \e connstring is \c NULL, the first available device from \a nfc_list_devices function is used.
         *
         * If \e connstring is set, this function will try to claim the right device using information provided by \e connstring.
         *
         * When it has successfully claimed a NFC device, memory is allocated to save the device information.
         * It will return a pointer to a \a nfc_device struct.
         * This pointer should be supplied by every next functions of libnfc that should perform an action with this device.
         *
         * @note Depending on the desired operation mode, the device needs to be configured by using nfc_initiator_init() or nfc_target_init(),
         * optionally followed by manual tuning of the parameters if the default parameters are not suiting your goals.
         */
        //nfc_device *
        //nfc_open(nfc_context *context, const nfc_connstring connstring)
        [DllImport("libnfc.so")]
        public static extern IntPtr nfc_open(IntPtr context, string connstring);
        //00004690 T nfc_perror
        //00003654 T nfc_register_driver
        //00004610 T nfc_strerror
        //0000465c T nfc_strerror_r
        //000043a0 T nfc_target_init
        //000045d8 T nfc_target_receive_bits
        //00004568 T nfc_target_receive_bytes
        //000045a0 T nfc_target_send_bits
        //00004530 T nfc_target_send_bytes
        //00004760 T nfc_version
        //0000a8a4 T pn532_SAMConfiguration
        //00008b88 T pn53x_read_register
        //00008478 T pn53x_transceive
        //00008d24 T pn53x_write_register
        //000047ac T str_nfc_baud_rate
        //0000482c T str_nfc_modulation_type
        //000048ec T str_nfc_target
    }
}
