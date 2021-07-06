using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace View
{
    public partial class CreateEmployee : Form
    {
        private Library.PictureBox menu_side;        private Library.Button btnConfirm;
        private Library.Button btnCancel;
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
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnCancel = new Library.Button("btnCancel");
            this.txtBxName = new Library.TextBox("txtBxName");
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Empregados";
            this.lblTitle.Location = new Point(600, 10);
            //
            // btnConfirm
            this.btnConfirm.Click += new EventHandler(this.btn_ConfirmarClick);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.TextErrorName = new ErrorProvider();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

