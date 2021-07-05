using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace View
{
    public partial class CreateEmployee : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.TextBox txtBxName;
        private Library.Label lblTitle;
        private ErrorProvider TextErrorName;
        readonly Model.Employee employee;


        public CreateEmployee(int id = 0)
        {

            try
            {
                employee = Controller.Employee.GetEmployee(id);
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
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Empregados";
            this.lblTitle.Location = new Point(600, 10);
            //
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            this.TextErrorName = new ErrorProvider();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBxName);
            this.Controls.Add(this.lblTitle);

        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                Regex employeeName = new Regex(@"^[a-zA-Z\s]");

                if ((!employeeName.IsMatch(this.txtBxName.Text)))
                {
                    this.TextErrorName.SetError(this.txtBxName, "Apenas Letras!");
                }
                else if ((txtBxName.Text != string.Empty))
                {
                    if (employee == null)
                    {
                        Controller.Employee.AddEmployee(
                        txtBxName.Text
                        );
                        this.TextErrorName.SetError(this.txtBxName, String.Empty);
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        Controller.Employee.UpdateEmployee(
                        employee.EmployeeId,
                        txtBxName.Text
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

