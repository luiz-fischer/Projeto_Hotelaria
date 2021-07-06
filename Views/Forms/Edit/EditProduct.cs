using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditProduct : Form
    {
        private Library.Button btnDelete;
        private Library.Button btnEdit;
        private Library.Button btnCancel;
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
            this.btnDelete = new Library.Button("btnDelete");
            this.btnEdit = new Library.Button("btnEdit");
            this.btnCancel = new Library.Button("btnCancel");
            this.richTextBoxProduct = new Library.RichTextBox();
            this.lblDataProduct = new Library.Label();
            this.lblTitle = new Library.Label();
            //
            // btnEdit
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            this.btnCancel.Location = new Point(810, 510);
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
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.richTextBoxProduct);
            this.Controls.Add(this.lblDataProduct);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR PRODUTO";
            this.idProduct = product.ProductId;
            this.Product = product;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct(idProduct);
            createProduct.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
