using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListCleans : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.ListView lvlClean;

        public ListCleans()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
            this.lvlClean = new Library.ListView();
            this.lblTitle = new Library.Label();
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
            // lblTitle
            this.lblTitle.Text = "Lista de Limpezas";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlCleans
            this.lvlClean.Size = new Size(1050, 400);
            this.lvlClean.Location = new Point(250, 100);

            List<Clean> cleanList = Controller.Clean.GetCleans();
            foreach (Clean clean in cleanList)
            {
                Employee employee = Controller.Employee.GetEmployee(clean.EmployeeId);
                Room room = Controller.Room.GetRoom(clean.RoomId);
                ListViewItem lvListRoom = new ListViewItem(clean.CleanId.ToString());
                lvListRoom.SubItems.Add(employee.EmployeeName.ToString());
                lvListRoom.SubItems.Add(clean.Date.ToString("dd/MM/yyyy"));
                lvListRoom.SubItems.Add(room.RoomFloor.ToString());
                lvListRoom.SubItems.Add(room.RoomNumber.ToString());
                lvListRoom.SubItems.Add(room.RoomDescription.ToString());
                lvlClean.Items.Add(lvListRoom);
            }

            this.lvlClean.Size = new Size(1050, 400);
            this.lvlClean.Location = new Point(250, 100);
            this.lvlClean.MultiSelect = false;
            this.lvlClean.Columns.Add("ID Limpeza", -2, HorizontalAlignment.Center);
            this.lvlClean.Columns.Add("Nome do Empregado", -2, HorizontalAlignment.Center);
            this.lvlClean.Columns.Add("Data da Limpeza", -2, HorizontalAlignment.Center);
            this.lvlClean.Columns.Add("Andar", -2, HorizontalAlignment.Center);
            this.lvlClean.Columns.Add("Número do Quarto", -2, HorizontalAlignment.Center);
            this.lvlClean.Columns.Add("Descrição do Quarto", -2, HorizontalAlignment.Center);
            //
            // Forms
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvlClean);
            this.Text = "       LISTAR LIMPEZAS";

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportClean.ReportCleanPdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {   
                string IdClean = this.lvlClean.SelectedItems[0].Text;
                Clean clean = Controller.Clean.GetClean(Int32.Parse(IdClean));
                EditClean editClean = new EditClean(clean);
                editClean.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar uma Limpeza para Avançar!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

