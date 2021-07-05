using System.Drawing;


namespace Library
{
    public class Label : System.Windows.Forms.Label
    {
        public Label()
        {
            this.Size = new Size(500, 40);
            this.Font = new Font("Roboto", 23F, FontStyle.Bold, GraphicsUnit.Point);
            this.ForeColor = ColorTranslator.FromHtml("#3C4858");
        }
     }
}