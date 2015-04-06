using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syncoski.App.Controls
{
    public partial class DataWatcherControl : UserControl
    {
        public DataWatcherControl()
        {
            InitializeComponent();
        }

        private void DataWatcherControl_Load(object sender, EventArgs e)
        {

        }

        private void actionButton_Click(object sender, EventArgs e)
        {

        }

        private string GetSelectedPath()
        {
            return textBoxSelectedPath.Text;
        }


    }
}
