using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;


namespace View
{
    public partial class ListEmployees : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.Label lblTableEmployee;
        private Library.ListView lvlEmpolyee;

        public ListEmployees()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
            this.lvlEmpolyee = new Library.ListView();
            this.lblTitle = new Library.Label();
            this.lblTableEmployee = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Empregados";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblTableEmployee
            this.lblTableEmployee.Text = "Selecione um Hóspede para Consultar, Exlcuir ou Alterar!";
            this.lblTableEmployee.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblTableEmployee.Location = new Point(500, 70);
            this.lblTableEmployee.Size = new Size(700, 30);
            //
            // lvlEmpolyee
            this.lvlEmpolyee.Size = new Size(1050, 400);
            this.lvlEmpolyee.Location = new Point(250, 100);

            List<Employee> employeeList = Controller.Employee.GetEmployees();
            foreach (Employee employee in employeeList)
            {
                ListViewItem lvListEmployee = new ListViewItem(employee.EmployeeId.ToString());
                lvListEmployee.SubItems.Add(employee.EmployeeName);
                lvlEmpolyee.Items.Add(lvListEmployee);
            }

            this.lvlEmpolyee.MultiSelect = false;
            this.lvlEmpolyee.Columns.Add("ID Empregado", -2, HorizontalAlignment.Center);
            this.lvlEmpolyee.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
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
            // Forms
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lvlEmpolyee);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTableEmployee);
            this.Text = "       LISTAR EMPREGADOS";

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportEmployee.ReportEmployeePdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string IdEmployee = this.lvlEmpolyee.SelectedItems[0].Text;
                Employee employee = Controller.Employee.GetEmployee(Int32.Parse(IdEmployee));
                EditEmployee editEmployee = new EditEmployee(employee);
                editEmployee.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar um Empregado!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

