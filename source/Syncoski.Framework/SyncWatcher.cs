using System;
using System.IO;

namespace Syncoski.Framework
{
    public class SyncWatcher
    {

        private readonly FileSystemWatcher _watcher;

        public SyncWatcher()
        {
            _watcher = new FileSystemWatcher
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = true
            };
        }

        public void Register(string folder)
        {
            _watcher.Path = folder;
        }

        public void T(EventHandler<SyncerEventArgs> handler)
        {
            var result = _watcher.WaitForChanged(WatcherChangeTypes.All);
            //
            var args = new SyncerEventArgs();
            handler(this, args);
        }

    }
}
