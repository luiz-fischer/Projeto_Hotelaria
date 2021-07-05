using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace View
{
    partial class CreateRoom : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.ComboBox cbRoomFloor;
        private Library.TextBox txtBxRoomNumber;
        private Library.TextBox txtBxRoomDescription;
        private Library.TextBox txtBxRoomValue;
        private Library.Label lblTitle;
        private ErrorProvider TextErrorRoomFloor;
        private ErrorProvider TextErrorRoomNumber;
        private ErrorProvider TextErrorRoomDescription;
        private ErrorProvider TextErrorRoomValue;
        Model.Room room;


        public CreateRoom(int id = 0)
        {

            try
            {
                room = Controller.Room.GetRoom(id);
            }
            catch
            {

            }
            InitializeComponent(id > 0);
        }

        public void InitializeComponent(bool isUpdate)
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.cbRoomFloor = new Library.ComboBox("cbRoomFloor");
            this.txtBxRoomNumber = new Library.TextBox("");
            this.txtBxRoomDescription = new Library.TextBox("");
            this.txtBxRoomValue = new Library.TextBox("");
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Quarto";
            this.lblTitle.Location = new Point(600, 10);
            //
            // txtBxRoomNumber
            this.txtBxRoomNumber.Location = new Point(600, 215);
            this.txtBxRoomNumber.PlaceholderText = "    Numero do Quarto";
            //
            // txtBxRoomDescription
            this.txtBxRoomDescription.Location = new Point(600, 280);
            this.txtBxRoomDescription.PlaceholderText = "    Descrição do Quarto";
            //
            // txtBxRoomValue
            this.txtBxRoomValue.Location = new Point(600, 345);
            this.txtBxRoomValue.PlaceholderText = "    Valor do Quarto";
            //
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            //
            // Erros
            this.TextErrorRoomFloor = new ErrorProvider();
            this.TextErrorRoomNumber = new ErrorProvider();
            this.TextErrorRoomDescription = new ErrorProvider();
            this.TextErrorRoomValue = new ErrorProvider();
            //
            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cbRoomFloor);
            this.Controls.Add(this.txtBxRoomNumber);
            this.Controls.Add(this.txtBxRoomDescription);
            this.Controls.Add(this.txtBxRoomValue);
            this.Controls.Add(this.lblTitle);

        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                double convertDoubleNumber;

                convertDoubleNumber = Convert.ToDouble(txtBxRoomValue.Text);
                Regex roomNumber = new(@"^[a-zA-Z\s]");
                Regex roomDescription = new(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]s|1[012])[- /.](19|20)\d\d$");
                Regex roomValue = new(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");

                if ((!roomNumber.IsMatch(this.txtBxRoomNumber.Text)))
                {
                    this.TextErrorRoomNumber.SetError(this.txtBxRoomNumber, "Apenas letras!");
                }
                else if (!roomDescription.IsMatch(this.txtBxRoomDescription.Text))
                {
                    this.TextErrorRoomDescription.SetError(this.txtBxRoomDescription, "Formato Inválido!");
                }
                else if (!roomValue.IsMatch(this.txtBxRoomValue.Text))
                {
                    this.TextErrorRoomValue.SetError(this.txtBxRoomValue, "CPF Inválido!");
                } else if (cbRoomFloor.SelectedItem == null)
                {
                    this.TextErrorRoomFloor.SetError(this.cbRoomFloor, "Quantidade Inválida!");
                }
                
                else if ((txtBxRoomNumber.Text != string.Empty)
                && (txtBxRoomDescription.Text != string.Empty)
                && (txtBxRoomValue.Text != string.Empty)
                && (cbRoomFloor.Text != string.Empty))
                {

                    if (room == null)
                    {
                        Controller.Room.AddRoom(
                        cbRoomFloor.Text == "1º Andar" ? 1 :
                        cbRoomFloor.Text == "2º Andar" ? 2 :
                        cbRoomFloor.Text == "3º Andar" ? 3 :
                        cbRoomFloor.Text == "4º Andar" ? 4 : 5,
                        txtBxRoomNumber.Text,
                        txtBxRoomDescription.Text,
                        convertDoubleNumber
                        );
                        this.TextErrorRoomFloor.SetError(this.cbRoomFloor, String.Empty);
                        this.TextErrorRoomNumber.SetError(this.txtBxRoomNumber, String.Empty);
                        this.TextErrorRoomDescription.SetError(this.txtBxRoomDescription, String.Empty);
                        this.TextErrorRoomValue.SetError(this.txtBxRoomValue, String.Empty);
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        convertDoubleNumber = Convert.ToDouble(txtBxRoomValue.Text);
                        Controller.Room.UpdateRoom(
                        room.IdRoom,
                        cbRoomFloor.Text == "1º Andar" ? 1 :
                        cbRoomFloor.Text == "2º Andar" ? 2 :
                        cbRoomFloor.Text == "3º Andar" ? 3 :
                        cbRoomFloor.Text == "4º Andar" ? 4 : 5,
                        txtBxRoomNumber.Text,
                        txtBxRoomDescription.Text,
                        convertDoubleNumber
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
