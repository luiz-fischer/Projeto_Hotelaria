using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace View
{
    public partial class ListRoom : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnCancelar;
        private Library.Label lblTitle;
        private Library.ListView lvlRoom;

        public ListRoom()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.lvlRoom = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Quartos";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlRoom
            this.lvlRoom.Size = new Size(1050, 400);
            this.lvlRoom.Location = new Point(250, 100);

            List<Model.Room> productRoom = Controller.Room.GetRooms();
            foreach (var room in productRoom)
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
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lvlRoom);
            this.Text = "       LISTAR QUARTOS";
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
