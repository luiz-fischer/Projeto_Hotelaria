using System.Windows.Forms;
using System.Drawing;

namespace View
{
    public partial class CreateClean : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.PictureBox logo_image;
      

        public CreateClean()
        {
       
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.logo_image = new Library.PictureBox("logo_image");
         
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(40, 105, 85);//default colour
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.logo_image);

        }
    }
}