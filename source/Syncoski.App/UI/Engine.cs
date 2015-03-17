using System;
using System.Windows.Forms;
using Syncoski.Framework;

namespace Syncoski.App.UI
{
    class Engine
    {

        private readonly Syncer _syncer;

        private String _actualSyncerPath;

        public SyncerState State { get { return _syncer.State; } }

        public Engine()
        {
            _syncer = new Syncer();
            _syncer.ChangesDetected += SyncerOnChangesDetected;
            //
            _notifyIcon = new NotifyIcon();
            _frmMain = new UI.Main(this);
            _frmMain.ServerPathChanged += OnMainOnServerPathChanged;
            //
            _notifyIcon.Text = Program.APP_NAME;
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = Properties.Resources.logo_win;
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
            _notifyIcon.BalloonTipClicked += BalloonTipClicked;
        }

        public Form Run()
        {
            _notifyIcon.ShowBalloonTip(2000, Program.APP_NAME,
                   "Running", ToolTipIcon.None);
            return _frmMain;
        }

        public void Start(string path = null)
        {
            if (!String.IsNullOrEmpty(path) || !String.IsNullOrWhiteSpace(path))
                _actualSyncerPath = path;
            _syncer.StartAsync(_actualSyncerPath);
        }

        public void Stop()
        {
            _syncer.Stop();
        }

        private void OnMainOnServerPathChanged(object sender, string s)
        {
            _actualSyncerPath = s;
            _syncer.StartAsync(_actualSyncerPath);
        }

        private void SyncerOnChangesDetected(object sender, SyncerEventArgs e)
        {
            _lastSyncerEventArgs = e;
            _notifyIcon.ShowBalloonTip(2000, Program.APP_NAME,
                   String.Format("{0} - {1}", _lastSyncerEventArgs.ActionType, _lastSyncerEventArgs.Item), ToolTipIcon.Info);
        }

        void BalloonTipClicked(object sender, EventArgs e)
        {
            if (_lastSyncerEventArgs == null) return;

            var path = _lastSyncerEventArgs.ActionType == SyncerWatcherAction.Deleted ?
                           System.IO.Path.GetDirectoryName(_lastSyncerEventArgs.FullPath) : _lastSyncerEventArgs.FullPath;
            System.Diagnostics.Process.Start("explorer", String.Format("/select,{0}", path));
        }

        private void NotifyIconOnDoubleClick(object sender, EventArgs e)
        {
            _frmMain.Show();
        }

        private readonly NotifyIcon _notifyIcon;
        private readonly Main _frmMain;
        private SyncerEventArgs _lastSyncerEventArgs;

    }
}
