using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public partial class ListReservation : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
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
            this.lvlReservation = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Reservas";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvlReservations
            this.lvlReservation.Size = new Size(1050, 400);
            this.lvlReservation.Location = new Point(250, 100);

            List<Model.Reservation> reservationList = Controller.Reservation.GetReservations();
            foreach (var reservation in reservationList)
            {
                Model.Guest guest = Controller.Guest.GetGuest(reservation.IdGuest);
                ListViewItem lvListRoom = new(reservation.IdReservation.ToString());
                // Model.Veiculo veiculo = Controller.Veiculo.GetVeiculo(reservation.IdReservation);
                lvListRoom.SubItems.Add(guest.GuestName.ToString());
                lvListRoom.SubItems.Add(guest.GuestIdentification.ToString());
                lvListRoom.SubItems.Add(reservation.CheckIn.ToString("dd/MM/yyyy"));
                lvListRoom.SubItems.Add(reservation.CheckOut.ToString("dd/MM/yyyy"));
                // lvListRoom.SubItems.Add(veiculo.Preco.ToString("C2"));
                // lvListRoom.SubItems.Add(reservation.ValorTotalReservation().ToString("C2"));
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
            this.Text = "       LISTAR RESERVAS";
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);


            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvlReservation);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
