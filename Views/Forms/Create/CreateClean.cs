using System.Windows.Forms;
using System.Drawing;
using System;
namespace View
{
    public partial class CreateClean : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.DateTimePicker txtBxBirth;
        private Library.TextBox txtBxIdentification;
        private Library.ComboBox cbPayment;
        private Library.TextBox txtBxNameMotherName;
        private Library.Label lblTitle;


        public CreateClean()
        {

            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.txtBxName = new Library.TextBox("txtBxName");
            this.txtBxBirth = new Library.DateTimePicker();
            this.txtBxNameMotherName = new Library.TextBox("txtBxNameMotherName");
            this.cbPayment = new Library.ComboBox("cbPayment");
            this.txtBxIdentification = new Library.TextBox("txtBxIdentification");
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Hóspedes";
            this.lblTitle.Location = new Point(600, 10);



            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.txtBxBirth);
            this.Controls.Add(this.txtBxIdentification);
            this.Controls.Add(this.txtBxNameMotherName);
            this.Controls.Add(this.cbPayment);
            this.Controls.Add(this.lblTitle);


        }
       
    }
}
