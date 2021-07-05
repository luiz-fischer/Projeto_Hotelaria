using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class MaskedTextBox : System.Windows.Forms.MaskedTextBox
    {
        public MaskedTextBox()
        {
            this.Font = new Font("Roboto", 20F, GraphicsUnit.Point);
            this.BorderStyle = BorderStyle.None;
            this.AutoSize = false;
            this.Size = new Size(330, 35);
            this.ForeColor = ColorTranslator.FromHtml("#8492A6");
            this.TextAlign = HorizontalAlignment.Center;
        }
    }
}