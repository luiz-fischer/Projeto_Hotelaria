using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditEmployee : Form
    {
        private Library.Button btnDelete;
        private Library.Button btnEdit;
        private Library.Button btnCancel;
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
            this.btnDelete = new Library.Button("btnDelete");
            this.btnEdit = new Library.Button("btnEdit");
            this.btnCancel = new Library.Button("btnCancel");
            this.richTextBoxEmployee = new Library.RichTextBox();
            this.lblDataEmployee = new Library.Label();
            this.lblTitle = new Library.Label();
            //
            // btnEdit
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            this.btnCancel.Location = new Point(810, 510);
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
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.richTextBoxEmployee);
            this.Controls.Add(this.lblDataEmployee);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR EMPREGADO";
            this.idEmployee = employee.EmployeeId;
            this.Employee = employee;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee(idEmployee);
            createEmployee.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
