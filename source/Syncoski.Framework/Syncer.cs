using System;
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

        private readonly SyncerWatcher _syncerWatcher;

        private readonly TimeSpan _delaySpan;

        private bool _isRunning;
        private NodeString _actualServer;

        public Syncer()
        {
            _isRunning = false;
            _delaySpan = TimeSpan.FromSeconds(0);
            _syncerWatcher = new SyncerWatcher();
        }

        public async Task StartAsync(string path)
        {
            await Task.Run(() => Start(path));
        }

        public void Start(string path)
        {
            _isRunning = true;

            _actualServer = NodeStringFactory.CreateNodeString(path);
            var localRepository = JsonHelper.Deserialize<NodeString>(FileManager.GetAppFileContent());

            if (localRepository == null)
                SaveActualServer(_actualServer);

            _syncerWatcher.Register(path, (sender, args) => OnChangesDetected(args));

            while (_isRunning)
            {
                _syncerWatcher.Listen();
                Task.Delay(_delaySpan).Wait();
            }

            _actualServer = NodeStringFactory.CreateNodeString(path);
            SaveActualServer(_actualServer);
        }


        public void Stop()
        {
            _isRunning = false;
        }

        protected virtual void OnChangesDetected(SyncerEventArgs e)
        {
            //  Internal use
            System.Diagnostics.Debug.WriteLine(String.Format("{0} - [{2}] {1}", e.ActionType, e.Item, e.ItemType));

            //  External use
            var handler = ChangesDetected;
            if (handler != null) handler(this, e);
        }


        private void SaveActualServer(NodeString actualServer)
        {
            var content = JsonHelper.Serialize(actualServer);
            FileHelper.SaveStream(FileManager.GetAppFile(), content);
        }

    }
}
