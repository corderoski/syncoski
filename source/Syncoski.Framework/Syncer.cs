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

        private readonly TimeSpan _delaySpan;

        private bool _isRunning;

        public Syncer()
        {
            _isRunning = false;
            _delaySpan = TimeSpan.FromSeconds(2);
            _syncerComparer = new SyncerComparer();
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

            while (_isRunning)
            {
                //Task.Run(() =>
                //    {

                var equal = actualServer.Equals(localRepository);

                if (!equal)
                {
                    //_syncerComparer.Compare(localRepository, actualServer);


                   
                    OnChangesDetected();
                }

                Task.Delay(_delaySpan).Wait();
                //});
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        protected virtual void OnChangesDetected(SyncerEventArgs e)
        {
            EventHandler<SyncerEventArgs> handler = ChangesDetected;
            if (handler != null) handler(this, e);
        }

        //private static IEnumerable<NodeString> GetStructure(string path)
        //{
        //    var content = FileHelper.OpenStream(path);
        //    var nodes = JsonHelper.DeserializeNodeStringArray(content);
        //    return nodes;
        //}

    }
}
