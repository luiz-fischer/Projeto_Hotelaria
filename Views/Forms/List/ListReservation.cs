using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListReservation : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnConfirmar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvlReservation;

        public ListReservation()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvlReservation = new Library.ListView();
            this.lblTitle = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Reservas";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlReservations
            this.lvlReservation.Size = new Size(1050, 400);
            this.lvlReservation.Location = new Point(250, 100);

            List<Reservation> reservationList = Controller.Reservation.GetReservations();
            foreach (Reservation reservation in reservationList)
            {  
                Guest guest = Controller.Guest.GetGuest(reservation.IdGuest);
                ListViewItem lvListRoom = new ListViewItem(reservation.IdReservation.ToString());
                lvListRoom.SubItems.Add(guest.GuestName.ToString());
                lvListRoom.SubItems.Add(guest.GuestIdentification.ToString());
                lvListRoom.SubItems.Add(reservation.CheckIn.ToString("dd/MM/yyyy"));
                lvListRoom.SubItems.Add(reservation.CheckOut.ToString("dd/MM/yyyy"));
                lvListRoom.SubItems.Add(reservation.TotalValueReservation().ToString("C2"));
                lvlReservation.Items.Add(lvListRoom);
            }
            this.lvlReservation.Size = new Size(1050, 400);
            this.lvlReservation.Location = new Point(250, 100);
            this.lvlReservation.MultiSelect = false;
            this.lvlReservation.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lvlReservation.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
            this.lvlReservation.Columns.Add("C.P.F.", -2, HorizontalAlignment.Center);
            this.lvlReservation.Columns.Add("Data Do CheckIn", -2, HorizontalAlignment.Center);
            this.lvlReservation.Columns.Add("Data Da CheckOut", -2, HorizontalAlignment.Center);
            this.lvlReservation.Columns.Add("Total", -2, HorizontalAlignment.Center);
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
            // Forms
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvlReservation);
            this.Text = "       LISTAR RESERVAS";

        }
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportReservation.ReportReservationPdf();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {   
                string IdReservation = this.lvlReservation.SelectedItems[0].Text;
                Reservation reservation = Controller.Reservation.GetReservation(Int32.Parse(IdReservation));
                EditReservation editReservation = new EditReservation(reservation);
                editReservation.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar uma Reserva para Avançar!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

