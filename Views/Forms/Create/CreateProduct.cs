using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace View
{
    public partial class CreateProduct : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.TextBox txtBxValue;
        private Library.Label lblTitle;
        private ErrorProvider TextErrorName;
        private ErrorProvider TextErrorValue;
        Model.Product product;


        public CreateProduct(int id = 0)
        {

            try
            {
                product = Controller.Product.GetProduct(id);
            }
            catch
            {

            }
            InitializeComponent(id > 0);
        }

        public void InitializeComponent(bool isUpdate)
        {
            this.menu_side = new Library.PictureBox("menu_side");
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
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            //
            // Erros
            this.TextErrorName = new ErrorProvider();
            this.TextErrorValue = new ErrorProvider();
            //
            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.txtBxValue);
            this.Controls.Add(this.lblTitle);

        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                Regex productName = new(@"^[a-zA-Z\s]");
                Regex productValue = new(@"^?[0-9][0-9,\.]+$");
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
