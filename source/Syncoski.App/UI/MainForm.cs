using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syncoski.App.UI
{
    public partial class MainForm : Form
    {

        public event EventHandler<String> ServerPathChange;

        private bool _close;

        public MainForm()
        {
            InitializeComponent();
            //
            this.textBox1.ReadOnly = true;
            //
            this.Icon = Properties.Resources.logo_win;
            this.Text = Program.APP_NAME;
            this.MaximizeBox = false;
            this.FormClosing += Form_FormClosing;
        }

        protected virtual void OnServerPathChange(string e)
        {
            EventHandler<string> handler = ServerPathChange;
            if (handler != null) handler(this, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

        private void lblExit_Click(object sender, EventArgs e)
        {
            _close = true;
            Close();
        }

        private void MinimizeWindow()
        {
            Hide();
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                var dResult = dialog.ShowDialog(this);

                if (dResult != DialogResult.OK) return;
                textBox1.Text = dialog.SelectedPath;
                OnServerPathChange(dialog.SelectedPath);
            }
        }

    }
}
