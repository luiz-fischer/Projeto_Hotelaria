using System.Drawing;


namespace Library
{
    public class RichTextBox : System.Windows.Forms.RichTextBox
    {
        public RichTextBox()
        {
            this.BackColor = ColorTranslator.FromHtml("#273444");
            this.ForeColor = ColorTranslator.FromHtml("#C0CCDA");
            this.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.SelectionColor = Color.Black;
            this.Size = new Size(330, 100);
        }
    }
}