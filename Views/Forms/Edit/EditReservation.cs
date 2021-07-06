using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace View
{
    partial class EditReservation : Form
    {
        private Library.Button btnDelete;
        private Library.Button btnEdit;
        private Library.Button btnCancel;
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

            this.btnDelete = new Library.Button("btnDelete");
            this.btnEdit = new Library.Button("btnEdit");
            this.btnCancel = new Library.Button("btnCancel");;
            this.lblDataReservation = new Library.Label();
            this.richTextBoxReservation = new Library.RichTextBox();
            this.lblTitle = new Library.Label();
            //
            // btnEdit
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.BackColor = ColorTranslator.FromHtml("#FF6C6C");
            //
            // lblTitle
            this.lblTitle.Text = "EDITAR RESERVA";
            this.lblTitle.Location = new Point(600, 10);
            this.btnCancel.Location = new Point(810, 510);
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
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDataReservation);
            this.Controls.Add(this.richTextBoxReservation);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR RESERVA";
            this.idReservation = reservation.IdReservation;
            this.Reservation = reservation;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest(idReservation);
            createGuest.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
