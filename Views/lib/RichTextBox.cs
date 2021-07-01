using System.Drawing;


namespace Library
{
    public class RichTextBox : System.Windows.Forms.RichTextBox
    {
        public RichTextBox() 
        {           
            this.ForeColor = Color.DarkBlue;
            this.Font = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Bold);
            this.SelectionColor = System.Drawing.Color.Black;
            this.Size = new Size(330, 100);
        }
    }
}