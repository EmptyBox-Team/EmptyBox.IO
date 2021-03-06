﻿using EmptyBox.IO.Access;
using EmptyBox.IO.Devices.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.IO.Storage.FileSystems
{
    public interface IFileSystem : IStorageItem
    {
        ulong Space { get; }
        IDrive Drive { get; }

        Task<IFolder> GetRoot();
    }
}
