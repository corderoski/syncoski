using System;
using System.IO;

namespace Syncoski.Framework
{
    public class SyncerWatcher
    {

        private readonly FileSystemWatcher _watcher;

        private EventHandler<SyncerEventArgs> _handler;

        public SyncerWatcher()
        {
            _watcher = new FileSystemWatcher();
            _watcher.IncludeSubdirectories = true;
        }

        public void Register(string folder, EventHandler<SyncerEventArgs> handler)
        {
            _watcher.Path = folder;
            _watcher.EnableRaisingEvents = true;
            this._handler = handler;
        }

        public void Listen()
        {
            var result = _watcher.WaitForChanged(WatcherChangeTypes.All);
            //
            var args = new SyncerEventArgs
                {
                    ActionType = (SyncerWatcherAction) ((int) result.ChangeType),
                    Item = result.Name,
                    OldItem = result.OldName
                };
            _handler(this, args);
        }

    }
}
