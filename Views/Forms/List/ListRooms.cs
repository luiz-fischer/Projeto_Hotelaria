using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListRoom : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.ListView lvRoom;

        public ListRoom()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
            this.lvRoom = new Library.ListView();
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Quartos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvRoom
            this.lvRoom.Size = new Size(1050, 400);
            this.lvRoom.Location = new Point(250, 100);

            List<Room> roomList = Controller.Room.GetRooms();
            foreach (Room room in roomList)
            { 
                ListViewItem lvListRoom = new ListViewItem(room.IdRoom.ToString());
                lvListRoom.SubItems.Add(room.RoomFloor.ToString());
                lvListRoom.SubItems.Add(room.RoomNumber);
                lvListRoom.SubItems.Add(room.RoomDescription);
                lvListRoom.SubItems.Add(room.RoomValue.ToString("C2"));
                lvRoom.Items.Add(lvListRoom);
            }

            this.lvRoom.MultiSelect = false;
            this.lvRoom.Columns.Add("ID Room", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Andar", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Numero do Quarto", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Descrição", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Valor do Diaria", -2, HorizontalAlignment.Center);
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
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lvRoom);
            this.Controls.Add(this.lblTitle);
            this.Text = "       LISTAR QUARTOS";

        } 
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportRoom.ReportRoomPdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string IdRoom = this.lvRoom.SelectedItems[0].Text;
                Room room = Controller.Room.GetRoom(Int32.Parse(IdRoom));
                EditRoom editRoom = new EditRoom(room);
                editRoom.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar um Produto!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

