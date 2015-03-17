using System;
using System.IO;

namespace Syncoski.Framework
{
    public class SyncerWatcher
    {

        private readonly FileSystemWatcher _watcher;

        private EventHandler<SyncerEventArgs> _handler;

        private string _actualFolder;

        public SyncerWatcher()
        {
            _watcher = new FileSystemWatcher { IncludeSubdirectories = true };
        }

        public void Clean()
        {
            GC.Collect();
        }

        public void Register(string folder, EventHandler<SyncerEventArgs> handler)
        {
            _actualFolder = folder;
            _watcher.Path = _actualFolder;
            _watcher.EnableRaisingEvents = true;
            this._handler = handler;
        }

        public void Listen()
        {
            var result = _watcher.WaitForChanged(WatcherChangeTypes.All);
            //
            var args = new SyncerEventArgs
                {
                    ActionType = (SyncerWatcherAction)((int)result.ChangeType),
                    Item = result.Name,
                    OldItem = result.OldName,
                    FullPath = Path.Combine(_actualFolder, result.Name)
                };
            args.ItemType = String.IsNullOrEmpty(Path.GetExtension(args.Item)) ? ItemType.Folder : ItemType.File;
            _handler(this, args);
        }

    }
}
