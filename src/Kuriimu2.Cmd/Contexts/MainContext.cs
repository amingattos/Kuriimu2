﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kontract.Models;
using Kore.Managers.Plugins;

namespace Kuriimu2.Cmd.Contexts
{
    class MainContext : BaseFileContext
    {
        protected override IList<Command> Commands { get; } = new List<Command>
        {
            new Command("open", "file"),
            new Command("open-with", "file", "plugin-id"),
            new Command("save", "file-index"),
            new Command("save-as","file-index","save-path"),
            new Command("close","file-index"),
            new Command("close-all"),
            new Command("select","file-index"),
            new Command("list-open"),
            new Command("exit")
        };

        public MainContext(IInternalPluginManager pluginManager) : base(pluginManager)
        {
        }

        protected override async Task<IContext> ExecuteNextInternal(Command command, IList<string> arguments)
        {
            var executeContext = await base.ExecuteNextInternal(command, arguments);
            if (executeContext != null)
                return executeContext;

            switch (command.Name)
            {
                case "exit":
                    CloseAll();
                    return null;
            }

            return null;
        }

        protected override bool IsLoaded(string filePath)
        {
            return PluginManager.IsLoaded(filePath);
        }

        protected override bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        protected override Task<LoadResult> LoadFileInternal(string filePath, Guid pluginId)
        {
            return pluginId == Guid.Empty ?
                PluginManager.LoadFile(filePath) :
                PluginManager.LoadFile(filePath, pluginId);
        }
    }
}
