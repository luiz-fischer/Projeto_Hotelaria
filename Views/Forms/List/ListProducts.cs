using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View 
{
    public partial class ListProducts : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.ListView lvProduct;

        public ListProducts()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
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
            foreach (Product product in productList)
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
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.Location = new Point(780, 620);
            //
            // btnConfirm
            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);
            this.btnConfirm.Location = new Point(420, 620);
            //
            // btnReport
            this.btnReport.Click += new EventHandler(this.btnReport_Click);
            this.btnReport.Location = new Point(600, 620);
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvProduct);
            this.Text = "       LISTAR PRODUTOS";

        }
       private void btnReport_Click(object sender, EventArgs e)
        {
            ReportProduct.ReportProductPdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

