using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpNFC.PInvoke;
using System.Runtime.InteropServices;

namespace SharpNFC
{
    public class NFCContext : IDisposable
    {
        protected IntPtr contextPointer;

        public NFCContext()
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            Functions.nfc_init(ptr);

            contextPointer = (IntPtr)Marshal.PtrToStructure(ptr, typeof(IntPtr));

            Marshal.FreeHGlobal(ptr);
        }

        public List<string> ListDevices()
        {
            int count = 8;
            IntPtr connectionStringsPointer = Marshal.AllocHGlobal(Constants.NFC_BUFSIZE_CONNSTRING * count);
            var devicesCount = Functions.nfc_list_devices(contextPointer, connectionStringsPointer, (uint)count);

            var devices = new List<string>();
            for (int i = 0; i < devicesCount; i++)
            {
                devices.Add(Marshal.PtrToStringAnsi(connectionStringsPointer + i * count));
            }

            Marshal.FreeHGlobal(connectionStringsPointer);

            return devices;
        }

        public virtual NFCDevice OpenDevice(string name)
        {
            IntPtr devicePointer;

            try
            {
                devicePointer = Functions.nfc_open(contextPointer, name);
                if(devicePointer == IntPtr.Zero)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception("nfc_open() failed.");
            }

            return new NFCDevice(devicePointer);
        }

        public virtual void Dispose()
        {
            Functions.nfc_exit(contextPointer);
        }
    }
}