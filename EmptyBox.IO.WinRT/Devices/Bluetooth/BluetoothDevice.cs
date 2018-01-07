﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmptyBox.IO.Network.Bluetooth;
using Windows.Devices.Enumeration;
using EmptyBox.IO.Network.MAC;
using Windows.Devices.Bluetooth.Rfcomm;
using EmptyBox.IO.Interoperability;

namespace EmptyBox.IO.Devices.Bluetooth
{
    public class BluetoothDevice : IBluetoothDevice
    {
        public string Name { get; private set; }
        public MACAddress Address { get; private set; }
        public BluetoothLinkType DeviceType => throw new NotImplementedException();
        public DevicePairStatus PairStatus => DevicePairStatus.Paired;
        public ConnectionStatus ConnectionStatus => ConnectionStatus.Unknow;
        public BluetoothDeviceClass DeviceClass => throw new NotImplementedException();

        public event DeviceConnectionStatusHandler ConnectionStatusEvent;

        internal BluetoothDevice(MACAddress address, string name)
        {
            Address = address;
            Name = name;
        }

        public async Task<IEnumerable<BluetoothAccessPoint>> GetServices(BluetoothSDPCacheMode cacheMode = BluetoothSDPCacheMode.Cached)
        {
            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(Constants.AQS_CLASS_GUID + Constants.AQS_BLUETOOTH_GUID);
            List<BluetoothAccessPoint> result = new List<BluetoothAccessPoint>();
            foreach (DeviceInformation device in devices)
            {
                try
                {
                    RfcommDeviceService rds = await RfcommDeviceService.FromIdAsync(device.Id);
                    if (rds != null)
                    {
                        MACAddress address = rds.ConnectionHostName.ToMACAddress();
                        if (Address == address)
                        {
                            result.Add(new BluetoothAccessPoint(Address, rds.ServiceId.ToBluetoothPort()));
                        }
                    }
                }
                catch
                {

                }
            }
            return result;
        }
    }
}
