using System.Windows.Forms;
using System.Drawing;

namespace View
{
    public partial class CreateClean : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.PictureBox logo_image;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.TextBox txtBxBirth;
        private Library.TextBox txtBxIdentification;
        private Library.TextBox txtBxPayment;
        private Library.TextBox txtBxNameMotherName;

      

        public CreateClean()
        {
       
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.logo_image = new Library.PictureBox("logo_image");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.txtBxName = new Library.TextBox("txtBxName");
            this.txtBxBirth = new Library.TextBox("txtBxBirth");
            this.txtBxNameMotherName = new Library.TextBox("txtBxNameMotherName");
            this.txtBxPayment = new Library.TextBox("txtBxPayment");
            this.txtBxIdentification = new Library.TextBox("txtBxIdentification");
         
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.logo_image);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.txtBxBirth);
            this.Controls.Add(this.txtBxIdentification);
            this.Controls.Add(this.txtBxNameMotherName);
            this.Controls.Add(this.txtBxPayment);


        }
    }
}
