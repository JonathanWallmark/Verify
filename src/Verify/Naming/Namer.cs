﻿using System;
using System.Runtime.InteropServices;

namespace Verify
{
    public class Namer
    {
        internal bool UniqueForRuntime = false;
        internal bool UniqueForAssemblyConfiguration = false;
        internal bool UniqueForRuntimeAndVersion = false;

        static Namer()
        {
            var (runtime, version) = GetRuntimeAndVersion();
            Runtime = runtime;
            RuntimeAndVersion = $"{runtime}{version.Major}_{version.Minor}";
        }

        public static string Runtime { get; }

        public static string RuntimeAndVersion { get; }

        internal Namer()
        {
        }

        internal Namer(Namer namer)
        {
            UniqueForRuntime = namer.UniqueForRuntime;
            UniqueForAssemblyConfiguration = namer.UniqueForAssemblyConfiguration;
            UniqueForRuntimeAndVersion = namer.UniqueForRuntimeAndVersion;
        }

        static (string runtime, Version Version) GetRuntimeAndVersion()
        {
            var description = RuntimeInformation.FrameworkDescription;
            if (description.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase))
            {
                var version = Version.Parse(description.Replace(".NET Framework ", ""));
                return ("Net", version);
            }

            if (description.StartsWith(".NET Core", StringComparison.OrdinalIgnoreCase))
            {
                return ("Core", Environment.Version);
            }

            throw new Exception($"Could not resolve runtime for '{description}'.");
        }
    }
}