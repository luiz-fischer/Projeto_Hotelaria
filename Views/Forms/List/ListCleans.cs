using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListCleans : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvlClean;

        public ListCleans()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvlClean = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Limpezas";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlCleans
            this.lvlClean.Size = new Size(1050, 400);
            this.lvlClean.Location = new Point(250, 100);


            List<Model.Clean> cleanList = Controller.Clean.GetCleans();
            List<Model.Room> roomList = Controller.Room.GetRooms();

            foreach (var clean in cleanList)
            {
                foreach (var room in roomList)
                {
                    Model.Employee employee = Controller.Employee.GetEmployee(clean.EmployeeId);
                    Model.Room roomLt = Controller.Room.GetRoom(room.IdRoom);
                    ListViewItem lvListRoom = new(clean.CleanId.ToString());
                    lvListRoom.SubItems.Add(employee.EmployeeName.ToString());
                    lvListRoom.SubItems.Add(clean.Date.ToString("dd/MM/yyyy"));
                    lvListRoom.SubItems.Add(room.RoomFloor.ToString());
                    lvListRoom.SubItems.Add(room.RoomNumber.ToString());
                    lvListRoom.SubItems.Add(room.RoomDescription.ToString());
                    lvlClean.Items.Add(lvListRoom);
                }
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
            this.Text = "       LISTAR LIMPEZAS";
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Location = new Point(780, 620);
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
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvlClean);

        }
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportClean.ReportCleanPdf();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
