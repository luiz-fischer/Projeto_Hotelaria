using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditRoom : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.RichTextBox richTextBoxRoom;
        private Library.Label lblDataRoom;
        private Library.Label lblTitle;

        private int idRoom;
        protected Room Room;

        public EditRoom(Room room)
        {
            InitializeComponent(room);
        }

        public void InitializeComponent(Room room)
        {
            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.menu_side = new Library.PictureBox("menu_side");
            this.richTextBoxRoom = new Library.RichTextBox();
            this.lblDataRoom = new Library.Label();
            this.lblTitle = new Library.Label();
            //
            // btnAlterar
            this.btnAlterar.Click += new EventHandler(this.btnAlterar_Click);
            //
            // btnDeletar
            this.btnDeletar.Click += new EventHandler(this.btnDeletar_Click);
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            this.btnCancelar.Location = new Point(810, 510);
            //
            // lblTitle
            this.lblTitle.Text = "EDITAR QUARTO";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblDataRoom
            this.lblDataRoom.Text = "DADOS DO QUARTO";
            this.lblDataRoom.Location = new Point(600, 220);
            this.lblDataRoom.Size = new Size(420, 25);
            this.lblDataRoom.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxRoom
            this.richTextBoxRoom.Location = new Point(500, 250);
            this.richTextBoxRoom.Size = new Size(430, 200);
            this.richTextBoxRoom.Text =
                "\n\n ID do Quarto:                "         + room.IdRoom +
                "\n Andar:                           "       + room.RoomFloor +
                "\n Número do Quarto:      "                 + room.RoomNumber +
                "\n Descrição:                               "    + room.RoomDescription +
                "\n Valor:                  "            + room.RoomValue.ToString("C2");
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.richTextBoxRoom);
            this.Controls.Add(this.lblDataRoom);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR QUARTO";
            this.idRoom = room.IdRoom;
            this.Room = room;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new(idRoom);
            createRoom.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Quarto?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Room.DeleteRoom(idRoom);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}