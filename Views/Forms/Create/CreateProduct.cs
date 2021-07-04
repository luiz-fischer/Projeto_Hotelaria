using System.Windows.Forms;
using System.Drawing;
using System;
namespace View
{
    public partial class CreateProduct : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.TextBox txtBxValue;
        private Library.Label lblTitle;


        public CreateProduct()
        {

            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.txtBxName = new Library.TextBox("txtBxName");
            this.txtBxValue = new Library.TextBox("txtBxValue");
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Produtos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // txtBxName
            this.txtBxName.PlaceholderText = "    Nome do Produto";
            //
            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.txtBxValue);
            this.Controls.Add(this.lblTitle);


        }

    }
}
