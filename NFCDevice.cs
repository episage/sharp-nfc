using SharpNFC.PInvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC
{
    public class NFCDevice : IDisposable
    {
        //protected nfc_device device;
        public readonly IntPtr DevicePointer;

        protected internal NFCDevice(IntPtr devicePointer)
        {
            //var device = (nfc_device)Marshal.PtrToStructure(devicePointer, typeof(nfc_device));
            this.DevicePointer = devicePointer;
        }

        public int Pool(List<nfc_modulation> modulation, byte poolCount, byte poolingInterval, out nfc_target nfc_target)
        {
            //var ptrArray = new IntPtr[modulation.Count];
            //for (int i = 0; i < modulation.Count; i++)
            //{
            //    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(modulation[i]));
            //    Marshal.StructureToPtr(modulation[i], ptr, false);
            //    ptrArray[i] = ptr;
            //}

            var target = new nfc_target();
            //var targetPtr = Marshal.AllocHGlobal(Marshal.SizeOf(target));

            var modArr = modulation.ToArray();
            var intResult = Functions.nfc_initiator_poll_target(DevicePointer, modArr, (uint)modArr.Length, poolCount, poolingInterval, ref target);
            nfc_target = target;

            return intResult;
        }

        public void Dispose()
        {
            SharpNFC.PInvoke.Functions.nfc_close(DevicePointer);
        }
    }
}
