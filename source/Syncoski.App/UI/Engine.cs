using System;
using System.Windows.Forms;
using Syncoski.Framework;

namespace Syncoski.App.UI
{
    class Engine
    {

        private readonly Syncer _syncer;

        private String _actualSyncerPath;

        public Engine()
        {
            _syncer = new Syncer();
            _syncer.ChangesDetected+= SyncerOnChangesDetected;
            //
            _contextMenuStrip = new ContextMenuStrip();
            _notifyIcon = new NotifyIcon();
            _frmMain = new UI.MainForm();
            _frmMain.ServerPathChange += (sender, s) =>
                {
                    _actualSyncerPath = s;
                    _syncer.StartAsync(_actualSyncerPath);
                };
            //
            //_contextMenuStrip.Items.AddRange(new ToolStripItem[] { null });
            //_notifyIcon.ContextMenuStrip = _contextMenuStrip;
            _notifyIcon.Text = Program.APP_NAME;
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = Properties.Resources.logo_win;
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
        }


        public Form Run()
        {
            _notifyIcon.ShowBalloonTip(2000, Program.APP_NAME,
                   "Running", ToolTipIcon.None);
            return _frmMain;
        }

        private void SyncerOnChangesDetected(object sender, SyncerEventArgs e)
        {
            _notifyIcon.ShowBalloonTip(2000, Program.APP_NAME,
                   String.Format("{0} - {1}", e.ActionType, e.Item), ToolTipIcon.Info);
        }

        private void NotifyIconOnDoubleClick(object sender, EventArgs e)
        {
            _frmMain.Show();
        }

        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenuStrip;
        private readonly MainForm _frmMain;
     
    }
}
