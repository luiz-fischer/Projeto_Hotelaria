using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;


namespace View
{
    public partial class ListEmployees : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnConfirmar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.Label lblTableEmployee;
        private Library.ListView lvlEmpolyee;

        public ListEmployees()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
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
            foreach (var employee in employeeList)
            {
                ListViewItem lvListEmployee = new ListViewItem(employee.EmployeeId.ToString());
                lvListEmployee.SubItems.Add(employee.EmployeeName);
                lvlEmpolyee.Items.Add(lvListEmployee);
            }

            this.lvlEmpolyee.MultiSelect = false;
            this.lvlEmpolyee.Columns.Add("ID Empregado", -2, HorizontalAlignment.Center);
            this.lvlEmpolyee.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Location = new Point(780, 620);
            //
            // btnConfirmar
            this.btnConfirmar.Click += new EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.Location = new Point(420, 620);
            //
            // btnRelatorio
            this.btnRelatorio.Click += new EventHandler(this.btnRelatorio_Click);
            this.btnRelatorio.Location = new Point(600, 620);
            //
            // Forms
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lvlEmpolyee);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTableEmployee);
            this.Text = "       LISTAR EMPREGADOS";

        }
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportEmployee.ReportEmployeePdf();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

