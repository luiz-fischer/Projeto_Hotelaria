using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace View
{
    partial class EditReservation : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.Label lblDataReservation;
        private Library.RichTextBox richTextBoxReservation;
        private Library.Label lblTitle;

        private int idReservation;
        protected Reservation Reservation;

        public EditReservation(Reservation reservation)
        {
            InitializeComponent(reservation);
        }
        public void InitializeComponent(Reservation reservation)
        {

            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");;
            this.menu_side = new Library.PictureBox("menu_side");
            this.lblDataReservation = new Library.Label();
            this.richTextBoxReservation = new Library.RichTextBox();
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
            //
            // lblTitle
            this.lblTitle.Text = "EDITAR RESERVA";
            this.lblTitle.Location = new Point(600, 10);
            this.btnCancelar.Location = new Point(810, 510);
            // 
            // lblDataReservation
            this.lblDataReservation.Text = "DADOS DA RESERVA";
            this.lblDataReservation.Location = new Point(600, 145);
            this.lblDataReservation.Size = new Size(500, 25);
            this.lblDataReservation.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxReservation
            this.richTextBoxReservation.Location = new Point(410, 170);
            this.richTextBoxReservation.Size = new Size(600, 300);
            List<Reservation> reservationList = Controller.Reservation.GetReservations();
            foreach (var reservationVar in reservationList)
            {
                Guest guest = Controller.Guest.GetGuest(reservationVar.IdGuest);
                Room room = Controller.Room.GetRoom(reservationVar.IdGuest);

            this.richTextBoxReservation.Text =                                        
                "\n\n ID da Reserva:                            "     + reservationVar.IdReservation.ToString() +
                "\n Data do CheckIn:                      "           + reservationVar.CheckIn.ToString("dd/MM/yyyy") +
                "\n Data do CheckOut:                   "             + reservationVar.CheckOut.ToString("dd/MM/yyyy") +
                "\n ID do Hóspede:                          "         + guest.IdGuest.ToString() +
                "\n Nome do Hóspede:                   "              + guest.GuestName +
                "\n Andar:                                          " + room.RoomFloor.ToString() +
                "\n Número do Quarto                    "             + room.RoomNumber +
                "\n Descrição do Quarto:               "              + room.RoomDescription ;
            }
            //      
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblDataReservation);
            this.Controls.Add(this.richTextBoxReservation);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR RESERVA";
            this.idReservation = reservation.IdReservation;
            this.Reservation = reservation;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest(idReservation);
            createGuest.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Essa Reserva?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Guest.DeleteGuest(idReservation);
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
