using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace View
{
    public partial class ListEmployees : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnCancelar;
        private Library.Label lblTitle;
        private Library.ListView lvlEmpolyee;

        public ListEmployees()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.lvlEmpolyee = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Empregados";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlEmpolyee
            this.lvlEmpolyee.Size = new Size(1050, 400);
            this.lvlEmpolyee.Location = new Point(250, 100);

            List<Model.Employee> productList = Controller.Employee.GetEmployees();
            foreach (var employee in productList)
            {
                ListViewItem lvlListEmployee = new(employee.EmployeeId.ToString());
                lvlListEmployee.SubItems.Add(employee.EmployeeName);
                lvlEmpolyee.Items.Add(lvlListEmployee);
            }
            
            this.lvlEmpolyee.MultiSelect = false;
            this.lvlEmpolyee.Columns.Add("ID Employee", -2, HorizontalAlignment.Center);
            this.lvlEmpolyee.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
            // 
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lvlEmpolyee);
            this.Text = "       LISTAR EMPREGADOS";
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);


            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTitle);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
