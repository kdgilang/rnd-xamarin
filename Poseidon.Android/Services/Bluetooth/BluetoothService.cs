using System;
using Poseidon.Services.BlueTooth;
using Android.Bluetooth;
using System.Collections.Generic;
using System.Threading.Tasks;
using Poseidon.Droid.Services.Bluetooth;
using System.Linq;
using System.Diagnostics;
using Java.Util;
using ESCPOS_NET.Utilities;

[assembly: Xamarin.Forms.Dependency(typeof(BluetoothService))]
namespace Poseidon.Droid.Services.Bluetooth
{
    public class BluetoothService: IBluetoothService
    {
        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

        public IList<string> GetDevices()
        {
            var devices = bluetoothAdapter?.BondedDevices
                .Select(item => item.Name).ToList();
            return devices;
        }

        public async Task Print(string deviceName, byte[][] buffer)
        {
            BluetoothDevice device = (from bd in bluetoothAdapter?.BondedDevices
                                      where bd?.Name == deviceName
                                      select bd).FirstOrDefault();

            try
            {
                await Task.Delay(1000);
                BluetoothSocket bluetoothSocket = device?.CreateRfcommSocketToServiceRecord
                    (
                        UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")
                    );
                var bufferToPrint = ByteSplicer.Combine(buffer);
                bluetoothSocket?.Connect();
                bluetoothSocket?.OutputStream.Write(bufferToPrint, 0, bufferToPrint.Length);
                bluetoothSocket.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
