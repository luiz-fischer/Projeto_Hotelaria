using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace View
{
    public partial class CreateProduct : Form
    {
        private Library.Button btnConfirm;
        private Library.Button btnCancel;
        private Library.TextBox txtBxName;
        private Library.TextBox txtBxValue;
        private Library.Label lblTitle;
        private ErrorProvider TextErrorName;
        private ErrorProvider TextErrorValue;
        readonly Model.Product product;


        public CreateProduct(int id = 0)
        {

            try
            {
                product = Controller.Product.GetProduct(id);
            }
            catch
            {

            }
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnCancel = new Library.Button("btnCancel");
            this.txtBxName = new Library.TextBox("txtBxName");
            this.txtBxValue = new Library.TextBox("txtBxValue");
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Produtos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // txtBxName
            this.txtBxName.PlaceholderText = "    Nome do Produto";
            //
            // btnConfirm
            this.btnConfirm.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            //
            // Erros
            this.TextErrorName = new ErrorProvider();
            this.TextErrorValue = new ErrorProvider();
            //
            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.txtBxValue);
            this.Controls.Add(this.lblTitle);

        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                Regex productName = new Regex(@"^[a-zA-Z\s]");
                Regex productValue = new Regex(@"^?[0-9][0-9,\.]+$");
                if ((!productName.IsMatch(this.txtBxName.Text)))
                {
                    this.TextErrorName.SetError(this.txtBxName, "Apenas letras!");
                }
                else if (!productValue.IsMatch(this.txtBxValue.Text))
                {
                    this.TextErrorValue.SetError(this.txtBxValue, "Formato Inválido!");
                }

                else if ((txtBxName.Text != string.Empty)
                && (txtBxValue.Text != string.Empty))
                {
                    double myNumber;
                    if (product == null)
                    {
                        try
                        {
                             myNumber = Convert.ToDouble(txtBxValue.Text);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show("ERRO" + ex);
                            throw;
                        }

                        Controller.Product.AddProduct(
                        txtBxName.Text,
                        myNumber

                        );
                        this.TextErrorName.SetError(this.txtBxName, String.Empty);
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        Controller.Product.UpdateProduct(
                        product.ProductId,
                        txtBxName.Text,
                        Convert.ToInt32(txtBxValue)
                        );
                        MessageBox.Show("Alteração Feita!");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Preencha Todos Os Campos!");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Preencha Todos Os Campos!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

