using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poseidon.Services.BlueTooth
{
    public interface IBluetoothService
    {
        IList<string> GetDevices();
        Task Print(string deviceName, byte[][] buffer);
    }
}
