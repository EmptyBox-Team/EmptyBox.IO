﻿using EmptyBox.IO.Devices;

namespace EmptyBox.IO.Network.WiFi
{
    public sealed class WiFiNetwork
    {
        /// <summary>
        /// Name of Wi-Fi Network. Also known as SSID.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Address of network owner device.
        /// </summary>
        public MACAddress BSSID { get; private set; }
        public ConnectionStatus ConnectionStatus { get; private set; }
        public WiFiEncryptionMode EncryptionMode { get; private set; }
    }
}
