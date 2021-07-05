using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditProduct : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.RichTextBox richTextBoxProduct;
        private Library.Label lblDataProduct;
        private Library.Label lblTitle;

        private int idProduct;
        protected Product Product;

        public EditProduct(Product product)
        {
            InitializeComponent(product);
        }

        public void InitializeComponent(Product product)
        { 
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.richTextBoxProduct = new Library.RichTextBox();
            this.lblDataProduct = new Library.Label();
            this.lblTitle = new Library.Label();
            //
            // btnAlterar
            this.btnAlterar.Click += new EventHandler(this.btnAlterar_Click);
            //
            // btnDeletar
            this.btnDeletar.Click += new EventHandler(this.btnDeletar_Click);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            this.btnCancelar.Location = new Point(810, 510);
            //
            // lblTitle
            this.lblTitle.Text = "EDITAR PRODUTO";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblDataProduct
            this.lblDataProduct.Text = "DADOS DO PRODUTO";
            this.lblDataProduct.Location = new Point(600, 220);
            this.lblDataProduct.Size = new Size(420, 25);
            this.lblDataProduct.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxProduct
            this.richTextBoxProduct.Location = new Point(500, 250); 
            this.richTextBoxProduct.Size = new Size(430, 200);
            this.richTextBoxProduct.Text =                    
                "\n\n ID do Product:                  "     + product.ProductId +
                "\n Nome do Produto:           "            + product.ProductName +
                "\n Valor do Produto:            "          + product.ProductValue;
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.richTextBoxProduct);
            this.Controls.Add(this.lblDataProduct);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR PRODUTO";
            this.idProduct = product.ProductId;
            this.Product = product;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new(idProduct);
            createProduct.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Produto?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Product.DeleteProduct(idProduct);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}