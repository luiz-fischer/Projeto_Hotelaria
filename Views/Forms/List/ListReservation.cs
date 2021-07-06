using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListReservation : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.ListView lvlReservation;

        public ListReservation()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
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
            // Forms
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvlReservation);
            this.Text = "       LISTAR RESERVAS";

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportReservation.ReportReservationPdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

