using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.IO;
using UnityEngine;
using Path = System.IO.Path;
using File = System.IO.File;

using System.Reflection;

namespace KSPLua
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class KSPLuaBehavior : MonoBehaviour
    {

        private const string x86TargetPath = @"KSP_Data/Mono/lua5.2";
        private const string x64TargetPath = @"KSP_x64_Data/Mono/lua5.2";

        private const string x86WinSourcePath = @"bin/win/x86/lua5.2";
        private const string x64WinSourcePath =  @"bin/win/x64/lua5.2";

        private const string x86LinuxSourcePath = @"bin/linux/x86/lua5.2";
        private const string x64LinuxSourcePath = @"bin/linux/x64/lua5.2";

        public void Awake()
        {
            string rootPath = KSPUtil.ApplicationRootPath;

            string pluginPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Environment.OSVersion.Platform == PlatformID.MacOSX ||
                Environment.OSVersion.Platform == PlatformID.Unix)
            {

                if (!File.Exists(Path.Combine(rootPath, x86TargetPath)))
                {
                    Debug.Log("Installed Linux x86 lua binaries");
                    File.Copy(Path.Combine(pluginPath, x86LinuxSourcePath), Path.Combine(rootPath, x86TargetPath));
                }

                if (!File.Exists(Path.Combine(rootPath, x64TargetPath)))
                {
                    Debug.Log("Installed Linux x64 lua binaries");
                    File.Copy(Path.Combine(pluginPath, x64LinuxSourcePath), Path.Combine(rootPath, x64TargetPath));
                }
            }
            else
            {             
                if (!File.Exists(Path.Combine(rootPath, x86TargetPath)))
                {
                    Debug.Log("Installed Windows x86 lua binaries");
                    File.Copy(Path.Combine(pluginPath, x86WinSourcePath), Path.Combine(rootPath, x86TargetPath));
                }

                if (!File.Exists(Path.Combine(rootPath, x64TargetPath)))
                {
                    Debug.Log("Installed Windows x64 lua binaries");
                    File.Copy(Path.Combine(pluginPath, x64WinSourcePath), Path.Combine(rootPath, x64TargetPath));
                }            
            }
        }
    }
}
