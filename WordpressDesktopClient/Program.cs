using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordpressDesktopClient
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            SplashScreen.ShowSplash();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
            
        }
        
    }
}
