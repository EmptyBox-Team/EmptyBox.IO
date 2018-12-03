﻿namespace EmptyBox.IO.Network
{
    public interface IAccessPoint<out TAddress, out TPort>
        where TAddress : IAddress
        where TPort : IPort
    {
        TAddress Address { get; }
        TPort Port { get; }
    }
}
