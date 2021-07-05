using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditEmployee : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.RichTextBox richTextBoxEmployee;
        private Library.Label lblDataEmployee;
        private Library.Label lblTitle;

        private int idEmployee;
        protected Employee Employee;

        public EditEmployee(Employee employee)
        {
            InitializeComponent(employee);
        }

        public void InitializeComponent(Employee employee)
        {
            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.menu_side = new Library.PictureBox("menu_side");
            this.richTextBoxEmployee = new Library.RichTextBox();
            this.lblDataEmployee = new Library.Label();
            this.lblTitle = new Library.Label();
            //
            // btnAlterar
            this.btnAlterar.Click += new EventHandler(this.btnAlterar_Click);
            //
            // btnDeletar
            this.btnDeletar.Click += new EventHandler(this.btnDeletar_Click);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            this.btnCancelar.Location = new Point(810, 510);
            //
            // lblTitle
            this.lblTitle.Text = "EDITAR EMPREGADO";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblDataEmployee
            this.lblDataEmployee.Text = "DADOS DO EMPREGADO";
            this.lblDataEmployee.Location = new Point(600, 220);
            this.lblDataEmployee.Size = new Size(420, 25);
            this.lblDataEmployee.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxEmployee
            this.richTextBoxEmployee.Location = new Point(500, 250);
            this.richTextBoxEmployee.Size = new Size(430, 200);
            this.richTextBoxEmployee.Text =       
                "\n\n ID do Employee:         "             + employee.EmployeeId +
                "\n Nome:                           "       + employee.EmployeeName;
            // 
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.richTextBoxEmployee);
            this.Controls.Add(this.lblDataEmployee);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR EMPREGADO";
            this.idEmployee = employee.EmployeeId;
            this.Employee = employee;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateEmployee createEmployee = new(idEmployee);
            createEmployee.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Empregado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Employee.DeleteEmployee(idEmployee);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
