using System.Windows.Forms;

namespace View
{
    public partial class CreateClean : Form
    {
        private Library.PictureBox imagemSide1;
        private Library.PictureBox imagemSide2;
      
        private Library.PictureBox imagemSide3;

        public CreateClean()
        {
       
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.imagemSide1 = new Library.PictureBox("imagemSide1");
            this.imagemSide2 = new Library.PictureBox("imagemSide3");
            this.imagemSide3 = new Library.PictureBox("imagemSide2");
         
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.imagemSide1);
            this.Controls.Add(this.imagemSide2);
            this.Controls.Add(this.imagemSide3);

        }
    }
}