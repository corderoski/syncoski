using System;
using System.Drawing;
using System.Windows.Forms;
using Syncoski.Framework;

namespace Syncoski.App.UI
{
    internal partial class Main : Form
    {

        [Obsolete("Do not use.", true)]
        public event EventHandler<String> ServerPathChanged;

        private readonly Engine _engine;

        private bool _close;

        public Main()
        {
            InitializeComponent();
            _notifyIcon = new NotifyIcon();
            //
            this.textBoxSelectedPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.textBoxSelectedPath.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            this.textBoxSelectedPath.Click += this.textBoxSelectedPath_Click;
            this.textBoxSelectedPath.LostFocus += textBoxSelectedPath_LostFocus;
            //this.textBoxSelectedPath.TextChanged += this.textBoxSelectedPath_TextActioner;
            //this.textBoxSelectedPath.Validated += this.textBoxSelectedPath_TextActioner;
            //
            _notifyIcon.Visible = true;
            this.Icon = Properties.Resources.logo_win;
            this.Text = Program.APP_NAME;
            this.Opacity = 40;
            this.MaximizeBox = false;
            this.FormClosing += Form_FormClosing;
            toolStripStateLabel.Text = "...";
            actionButton.Text = "Start";
            //
            textBoxSelectedPath.Text = ConfigurationHelper.GetSetting(LastPath);
        }

        public Main(Engine engine)
            : this()
        {
            _engine = engine;
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
                    MinimizeWindow();
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
        }

        private void textBoxSelectedPath_LostFocus(object sender, EventArgs e)
        {
            textBoxSelectedPath.ReadOnly = true;
        }

        private void textBoxSelectedPath_Click(object sender, EventArgs e)
        {
            textBoxSelectedPath.ReadOnly = false;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GetSelectedPath()))
            {
                return;
            }
            if (!System.IO.Directory.Exists(GetSelectedPath()))
            {
                return;
            }
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
            ConfigurationHelper.SaveValue(LastPath, GetSelectedPath());
            //
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

        private readonly NotifyIcon _notifyIcon;

        private const string LastPath = "lastPath";

    }
}
