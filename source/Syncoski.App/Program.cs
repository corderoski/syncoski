using System;
using System.Linq;
using System.Windows.Forms;
using Syncoski.Framework;

namespace Syncoski.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new Form1());

            var syncer = new Syncer();

        }

    }
}
