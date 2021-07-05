using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace View
{
    public partial class CreateGuest : Form
    {
        Model.Guest guest;
        private Library.PictureBox menu_side;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.MaskedTextBox mskBxBirth;
        private Library.MaskedTextBox msktBxIdentification;
        private Library.ComboBox cbPayment;
        private Library.TextBox txtBxMotherName;
        private Library.Label lblTitle;
        private ErrorProvider TextErrorName;
        private ErrorProvider TextErrorBirth;
        private ErrorProvider TextErrorIdentification;
        private ErrorProvider TextErrorPayment;
        private ErrorProvider TextErrorMotherName;



        public CreateGuest(int id = 0)
        {

            try
            {
                guest = Controller.Guest.GetGuest(id);
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
            this.mskBxBirth = new Library.MaskedTextBox();
            this.txtBxMotherName = new Library.TextBox("txtBxMotherName");
            this.cbPayment = new Library.ComboBox("cbPayment");
            this.msktBxIdentification = new Library.MaskedTextBox();
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Hóspedes";
            this.lblTitle.Location = new Point(600, 10);
            //
            // mskBxBirth
            this.mskBxBirth.Mask = "00/00/0000";
            this.mskBxBirth.Location = new Point(600, 215);
            //
            // msktBxIdentification
            this.msktBxIdentification.Mask = "000,000,000-00";
            this.msktBxIdentification.Location = new Point(600, 280);
            //
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            this.TextErrorName = new ErrorProvider();
            this.TextErrorBirth = new ErrorProvider();
            this.TextErrorMotherName = new ErrorProvider();
            this.TextErrorPayment = new ErrorProvider();
            this.TextErrorIdentification = new ErrorProvider();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.mskBxBirth);
            this.Controls.Add(this.msktBxIdentification);
            this.Controls.Add(this.txtBxMotherName);
            this.Controls.Add(this.cbPayment);
            this.Controls.Add(this.lblTitle);


        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                Regex guestName = new(@"^[a-zA-Z\s]");
                Regex guestBirth = new(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]s|1[012])[- /.](19|20)\d\d$");
                Regex guestIdentification = new(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
                Regex guestMotherName = new(@"^[a-zA-Z\s]");
                if ((!guestName.IsMatch(this.txtBxName.Text)))
                {
                    this.TextErrorName.SetError(this.txtBxName, "Apenas Letras!");
                }
                else if (!guestBirth.IsMatch(this.mskBxBirth.Text))
                {
                    this.TextErrorBirth.SetError(this.mskBxBirth, "Formato Inválido!");
                }
                else if (!guestIdentification.IsMatch(this.msktBxIdentification.Text))
                {
                    this.TextErrorIdentification.SetError(this.msktBxIdentification, "CPF Inválido!");
                }
                else if (cbPayment.SelectedItem == null)
                {
                    this.TextErrorPayment.SetError(this.cbPayment, "Quantidade Inválida!");
                } else  if ((!guestMotherName.IsMatch(this.txtBxMotherName.Text)))
                {
                    this.TextErrorName.SetError(this.txtBxMotherName, "Apenas letras!");
                }
                
                else if ((txtBxName.Text != string.Empty)
                && (mskBxBirth.Text != string.Empty)
                && (msktBxIdentification.Text != string.Empty)
                && (txtBxMotherName.Text != string.Empty)
                && (cbPayment.Text != string.Empty))
                {
                    if (guest == null)
                    {
                        Controller.Guest.AddGuest(
                        txtBxName.Text,
                        mskBxBirth.Text,
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "2 Dia" ? 2 :
                        cbPayment.Text == "3 Dia" ? 3 : 1,
                        msktBxIdentification.Text,
                        txtBxMotherName.Text
                        
                        );
                        this.TextErrorName.SetError(this.txtBxName, String.Empty);
                        this.TextErrorBirth.SetError(this.mskBxBirth, String.Empty);
                        this.TextErrorIdentification.SetError(this.msktBxIdentification, String.Empty);
                        this.TextErrorPayment.SetError(this.cbPayment, String.Empty);
                        this.TextErrorMotherName.SetError(this.txtBxMotherName, String.Empty);
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    { 
                        Controller.Guest.UpdateGuest(
                        guest.IdGuest,
                        txtBxName.Text,
                        mskBxBirth.Text,
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "1 Dia" ? 1 :
                        cbPayment.Text == "2 Dia" ? 2 :
                        cbPayment.Text == "3 Dia" ? 3 : 1,
                        msktBxIdentification.Text,
                        txtBxMotherName.Text
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
