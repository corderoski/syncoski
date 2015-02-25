using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syncoski.Framework.IO;
using VGExplorer.Framework.Entities;
using VGExplorer.Framework.Factory;
using VGExplorer.Framework.Helpers;

namespace Syncoski.Framework
{
    public class Syncer
    {

        public event EventHandler<SyncerEventArgs> ChangesDetected;

        private SyncerComparer _syncerComparer;

        private SyncerWatcher _syncerWatcher;

        private readonly TimeSpan _delaySpan;

        private bool _isRunning;

        public Syncer()
        {
            _isRunning = false;
            _delaySpan = TimeSpan.FromSeconds(2);
            _syncerComparer = new SyncerComparer();
            _syncerWatcher = new SyncerWatcher();
            ChangesDetected += (sender, args) => OnChangesDetected(args);
        }

        public void Start(string path)
        {
            _isRunning = true;

            var actualServer = NodeStringFactory.CreateNodeString(path);
            var localRepository = JsonHelper.Deserialize<NodeString>(FileManager.GetAppFileContent());

            if (localRepository == null)
            {
                var content = JsonHelper.Serialize(actualServer);
                FileHelper.SaveStream(FileManager.GetAppFile(), content);
            }

            _syncerWatcher.Register(path, (sender, args) => OnChangesDetected(args));


            while (_isRunning)
            {
                Task.Run(() =>
                    {
                        _syncerWatcher.Listen();
                        Task.Delay(_delaySpan).Wait();
                    });
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        protected virtual void OnChangesDetected(SyncerEventArgs e)
        {
            //  External use
            var handler = ChangesDetected;
            if (handler != null) handler(this, e);

            //  Internal use

        }

        //private static IEnumerable<NodeString> GetStructure(string path)
        //{
        //    var content = FileHelper.OpenStream(path);
        //    var nodes = JsonHelper.DeserializeNodeStringArray(content);
        //    return nodes;
        //}

    }
}
