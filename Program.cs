using System;
using System.Windows.Forms;

namespace pig202101_hotel
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
