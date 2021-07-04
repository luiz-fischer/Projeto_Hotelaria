using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace View
{
    public partial class ListProducts : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnCancelar;
        private Library.Label lblTitle;
        private Library.ListView lvProduct;

        public ListProducts()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.lvProduct = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Produtos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvProduct
            this.lvProduct.Size = new Size(1050, 400);
            this.lvProduct.Location = new Point(250, 100);

            List<Model.Product> productList = Controller.Product.GetProducts();
            foreach (var product in productList)
            {
                ListViewItem lvListProduct = new(product.ProductId.ToString());
                lvListProduct.SubItems.Add(product.ProductName);
                lvProduct.Items.Add(lvListProduct);
            }
            
            this.lvProduct.MultiSelect = false;
            this.lvProduct.Columns.Add("ID Product", -2, HorizontalAlignment.Center);
            this.lvProduct.Columns.Add("Nome do Produto", -2, HorizontalAlignment.Center);
            // 
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lvProduct);
            this.Text = "       LISTAR PRODUTOS";
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);


            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTitle);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
