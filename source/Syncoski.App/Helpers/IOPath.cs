using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Syncoski.App.Helpers
{
    class IOPath
    {

        const string ShortcutName = "Syncoski.lnk";

        public static void CreateShortcutByShellLink()
        {
            if (CheckIfExists()) return;

            var link = (IShellLink)new ShellLink();

            // setup shortcut information
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            link.SetDescription("Syncoski - A tiny, little, small syncer.");
            link.SetPath(path);

            // save it
            var file = (IPersistFile)link;
            var finalPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            file.Save(Path.Combine(finalPath, ShortcutName), false);
        }

        public static void CreateShortcutByMarshal()
        {
            if (CheckIfExists()) return;

            var t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(ShortcutName);
                try
                {
                    lnk.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                    lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private static bool CheckIfExists()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), ShortcutName);
            return File.Exists(path);
        }

    }
}
