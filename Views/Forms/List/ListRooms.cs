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
        private Library.Button btnConfirmar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvRoom;

        public ListRoom()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvRoom = new Library.ListView();
            this.lblTitle = new();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Quartos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvRoom
            this.lvRoom.Size = new Size(1050, 400);
            this.lvRoom.Location = new Point(250, 100);

            List<Room> roomList = Controller.Room.GetRooms();
            foreach (var room in roomList)
            { 
                ListViewItem lvListRoom = new(room.IdRoom.ToString());
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
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lvRoom);
            this.Controls.Add(this.lblTitle);
            this.Text = "       LISTAR QUARTOS";

        } 
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportRoom.ReportRoomPdf();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdRoom = this.lvRoom.SelectedItems[0].Text;
                Room room = Controller.Room.GetRoom(Int32.Parse(IdRoom));
                EditRoom editRoom = new(room);
                editRoom.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar um Produto!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
