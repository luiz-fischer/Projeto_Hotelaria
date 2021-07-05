using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View 
{
    public partial class ListProducts : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnConfirmar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvProduct;

        public ListProducts()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvProduct = new Library.ListView();
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Produtos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvProduct
            this.lvProduct.Size = new Size(1050, 400);
            this.lvProduct.Location = new Point(250, 100);

            List<Product> productList = Controller.Product.GetProducts();
            foreach (var product in productList)
            {
                ListViewItem lvListProduct = new ListViewItem(product.ProductId.ToString());
                lvListProduct.SubItems.Add(product.ProductName);
                lvListProduct.SubItems.Add(product.ProductValue.ToString("C2"));
                lvProduct.Items.Add(lvListProduct);
            }
            
            this.lvProduct.MultiSelect = false;
            this.lvProduct.Columns.Add("ID Product", -2, HorizontalAlignment.Center);
            this.lvProduct.Columns.Add("Nome do Produto", -2, HorizontalAlignment.Center);
            this.lvProduct.Columns.Add("Valor do Produto", -2, HorizontalAlignment.Center);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Location = new Point(780, 620);
            //
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.Location = new Point(420, 620);
            //
            // btnRelatorio
            this.btnRelatorio.Click += new EventHandler(this.btnRelatorio_Click);
            this.btnRelatorio.Location = new Point(600, 620);
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvProduct);
            this.Text = "       LISTAR PRODUTOS";

        }
       private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportProduct.ReportProductPdf();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdProduct = this.lvProduct.SelectedItems[0].Text;
                Product product = Controller.Product.GetProduct(Int32.Parse(IdProduct));
                EditProduct editProduct = new EditProduct(product);
                editProduct.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar um Produto!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

