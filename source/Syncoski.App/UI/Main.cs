using System;
using System.Drawing;
using System.Windows.Forms;
using Syncoski.Framework;

namespace Syncoski.App.UI
{
    internal partial class Main : Form
    {

        public event EventHandler<String> ServerPathChanged;

        private readonly Engine _engine;

        private bool _close;

        public Main()
        {
            InitializeComponent();
            _notifyIcon = new NotifyIcon();
            //
            //_engine = new Engine();
            //
            _notifyIcon.Visible = true;
            this.Icon = Properties.Resources.logo_win;
            this.Text = Program.APP_NAME;
            this.Opacity = 40;
            this.MaximizeBox = false;
            this.FormClosing += Form_FormClosing;
            toolStripStateLabel.Text = "...";
            actionButton.Text = "Start";
        }

        public Main(Engine engine)
            : this()
        {
            _engine = engine;
        }

        protected virtual void OnServerPathChange(string e)
        {
            EventHandler<string> handler = ServerPathChanged;
            if (handler != null) handler(this, e);
        }

        private string GetSelectedPath()
        {
            return textBoxSelectedPath.Text;
        }

        private void MakeUIChanges()
        {
            switch (_engine.State)
            {
                case SyncerState.New:
                case SyncerState.Stopped:
                    //toolStripStateLabel.Text = "Stopped";
                    actionButton.Text = "Start";
                    textBoxSelectedPath.ReadOnly = false;
                    break;
                case SyncerState.Running:
                    //toolStripStateLabel.Text = "Running";
                    actionButton.Text = "Stop";
                    textBoxSelectedPath.ReadOnly = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            toolStripStateLabel.Text = _engine.State.ToString();
        }

        private void MinimizeWindow()
        {
            Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Text = Program.APP_NAME;
            var screen = Screen.PrimaryScreen.WorkingArea;
            var w = screen.Width - this.Size.Width - 10;
            var h = screen.Height - this.Size.Height - 10;
            this.Location = new Point(w, h);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_close) return;
            e.Cancel = true;
            MinimizeWindow();
            _notifyIcon.ShowBalloonTip(1200, Program.APP_NAME, Program.APP_NAME + " still running.", ToolTipIcon.Info);
        }

        private void textBoxSelectedPath_Click(object sender, EventArgs e)
        {
            textBoxSelectedPath.ReadOnly = false;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            /*
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                var dResult = dialog.ShowDialog(this);

                if (dResult != DialogResult.OK) return;
                textBox1.Text = dialog.SelectedPath;
                OnServerPathChange(dialog.SelectedPath);
            }
            */
            //  know what to do
            switch (_engine.State)
            {
                case SyncerState.New:
                case SyncerState.Stopped:
                    _engine.Start(GetSelectedPath());
                    MakeUIChanges();
                    break;
                case SyncerState.Running:
                    _engine.Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            MakeUIChanges();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _close = true;
            Close();
        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Helpers.IOPath.CheckIfExists())
            {
                Helpers.IOPath.CreateShortcutByShellLink();
                MessageBox.Show(this, "The application has been registered to initiate with Windows.", Program.APP_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSelectedPath_TextActioner(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(textBoxSelectedPath.Text))
            {
                OnServerPathChange(textBoxSelectedPath.Text);
                MakeUIChanges();
            }
        }

        private readonly NotifyIcon _notifyIcon;


    }
}
