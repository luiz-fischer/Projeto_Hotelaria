using System;
using System.Windows.Forms;

namespace View
{
    static class Program
    {
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Home());
        }
    }
}
