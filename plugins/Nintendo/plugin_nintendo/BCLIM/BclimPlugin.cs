﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponent.IO;
using Kontract.Interfaces.FileSystem;
using Kontract.Interfaces.Managers;
using Kontract.Interfaces.Plugins.Identifier;
using Kontract.Interfaces.Plugins.State;
using Kontract.Interfaces.Providers;
using Kontract.Models;
using Kontract.Models.IO;
using plugin_nintendo.CTPK;

namespace plugin_nintendo.BCLIM
{
    public class BclimPlugin : IFilePlugin, IIdentifyFiles
    {
        public Guid PluginId => Guid.Parse("cf5ae49f-0ce9-4241-900c-668b5c62ce33");
        public string[] FileExtensions => new[] { "*.bclim" };
        public PluginMetadata Metadata { get; }

        public async Task<bool> IdentifyAsync(IFileSystem fileSystem, UPath filePath, ITemporaryStreamProvider temporaryStreamProvider)
        {
            var fileStream = await fileSystem.OpenFileAsync(filePath);
            using (var br = new BinaryReaderX(fileStream))
            {
                if (br.BaseStream.Length < 0x28) 
                    return false;

                br.BaseStream.Position = br.BaseStream.Length - 0x28;
                return br.ReadString(4) == "CLIM";
            }
        }

        public IPluginState CreatePluginState(IPluginManager pluginManager)
        {
            return new BclimState();
        }
    }
}