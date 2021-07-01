using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class MaskedTextBox : System.Windows.Forms.MaskedTextBox
    {
        public MaskedTextBox() 
        {
            this.Size = new Size(90, 20);
            this.TextAlign = HorizontalAlignment.Center;
        }
    }
}