using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListRoom : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvlRoom;

        public ListRoom()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvlRoom = new Library.ListView();
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Quartos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlRoom
            this.lvlRoom.Size = new Size(1050, 400);
            this.lvlRoom.Location = new Point(250, 100);

            List<Room> roomList = Controller.Room.GetRooms();
            foreach (var room in roomList)
            {
                ListViewItem lvListRoom = new(room.IdRoom.ToString());
                lvListRoom.SubItems.Add(room.RoomFloor.ToString());
                lvListRoom.SubItems.Add(room.RoomNumber);
                lvListRoom.SubItems.Add(room.RoomDescription);
                lvListRoom.SubItems.Add(room.RoomValue.ToString("C2"));
                lvlRoom.Items.Add(lvListRoom);
            }

            this.lvlRoom.MultiSelect = false;
            this.lvlRoom.Columns.Add("ID Room", -2, HorizontalAlignment.Center);
            this.lvlRoom.Columns.Add("Andar", -2, HorizontalAlignment.Center);
            this.lvlRoom.Columns.Add("Numero do Quarto", -2, HorizontalAlignment.Center);
            this.lvlRoom.Columns.Add("Descrição", -2, HorizontalAlignment.Center);
            this.lvlRoom.Columns.Add("Valor do Diaria", -2, HorizontalAlignment.Center);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Location = new Point(780, 620);
            //
            // btnRelatorio
            this.btnRelatorio.Click += new EventHandler(this.btnRelatorio_Click);
            this.btnRelatorio.Location = new Point(600, 620);
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lvlRoom);
            this.Controls.Add(this.lblTitle);
            this.Text = "       LISTAR QUARTOS";

        } 
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportRoom.ReportRoomPdf();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
