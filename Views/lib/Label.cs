using System.Drawing;


namespace Library
{
    public class Label : System.Windows.Forms.Label
    {
        public Label()
        {
            this.Size = new Size(500, 28);
            this.Font = new Font(FontFamily.GenericSansSerif, 12F, FontStyle.Bold);
            this.ForeColor = Color.Black;
        }
     }
}