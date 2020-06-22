using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordpressDesktopClient
{
    public partial class SplashScreen : Form
    {
        private static Thread splashThread;
        private static SplashScreen splashForm;

        public SplashScreen()
        {
            InitializeComponent();
        }

        public static void ShowSplash()
        {
            if (splashThread == null)
            {
                splashThread = new Thread(new ThreadStart(DoShowSplash));
                splashThread.IsBackground = true;
                splashThread.Start();
            }
        }

        private static void DoShowSplash()
        {
            if (splashForm == null)
                splashForm = new SplashScreen();

            Application.Run(splashForm);
        }

        public static void CloseSplash()
        {
            if (splashForm.InvokeRequired)
                splashForm.Invoke(new MethodInvoker(CloseSplash));
            else
                Application.ExitThread();
        }
    }
}
