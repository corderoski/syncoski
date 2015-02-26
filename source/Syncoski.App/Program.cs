using System;
using System.Windows.Forms;

namespace Syncoski.App
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var engine = new UI.Engine();
            Application.Run(engine.Run());
        }

        internal const String APP_NAME = Framework.Constants.APP_NAME + " - Alpha";

    }
}
