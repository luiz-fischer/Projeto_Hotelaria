using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    partial class CreateReservation : Form
    {
        private Library.Button btnConfirm;
        private Library.Button btnCancel;
        private Library.ListView lvListarGuests;
        private Library.ListView lvlListarRooms;
        private DateTimePicker dtCheckIn;
        private DateTimePicker dtCheckOut;
        private Library.Label lblCheckIn;
        private Library.Label lblCheckOut;
        private Library.Label lblTitulo;
        private Library.Label lblGuest;
        private Library.Label lblRoom;
        public CreateReservation(int id = 0)
        {
            try
            {
                Model.Reservation reservation = Controller.Reservation.GetReservation(id);
            }
            catch 
            {

            }

            InitializeComponent();
        }
        public void InitializeComponent()
        {
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnCancel = new Library.Button("btnCancel");
            this.lvListarGuests = new Library.ListView();
            this.lvlListarRooms = new Library.ListView();
            this.lblCheckIn = new Library.Label();
            this.lblCheckOut = new Library.Label();
            this.lblTitulo = new Library.Label();
            this.lblGuest = new Library.Label();
            this.lblRoom = new Library.Label();
            this.dtCheckIn = new DateTimePicker();
            this.dtCheckOut = new DateTimePicker();
            //
            // lblCheckIn
            this.lblCheckIn.Text = "Data CheckIn";
            this.lblCheckIn.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblCheckIn.Location = new Point(900, 355);
            this.lblCheckIn.ForeColor = ColorTranslator.FromHtml("#8492A6");
            //
            // dtCheckIn
            this.dtCheckIn.Location = new Point(950, 385);
            this.dtCheckIn.Format = DateTimePickerFormat.Custom;
            this.dtCheckIn.CustomFormat = "dd/MM/yyyy";
            this.dtCheckIn.ShowUpDown = true;
            //
            // lblCheckOut
            this.lblCheckOut.Text = "Data CheckOut";
            this.lblCheckOut.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblCheckOut.Location = new Point(900, 415);
            this.lblCheckOut.ForeColor = ColorTranslator.FromHtml("#8492A6");
            //
            // dtCheckOut
            this.dtCheckOut.Location = new Point(950, 445);
            this.dtCheckOut.Format = DateTimePickerFormat.Custom;
            this.dtCheckOut.CustomFormat = "dd/MM/yyyy";
            this.dtCheckOut.ShowUpDown = true;
            //
            // btnConfirm
            this.btnConfirm.Click += new EventHandler(this.btn_ConfirmarClick);
            this.btnConfirm.Location = new Point(600, 610);
            //
            // btnCancel
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.Location = new Point(780, 610);
            //
            // lblTitulo
            this.lblTitulo.Text = "Cadastro de Hospedagem";
            this.lblTitulo.Location = new Point(600, 10);
            //
            // lblGuest
            this.lblGuest.Text = "Selecione um Hóspede Para Registrar a Reserva!";
            this.lblGuest.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblGuest.ForeColor = ColorTranslator.FromHtml("#8492A6");
            this.lblGuest.Location = new Point(247, 75);
            //
            // lvListarGuests
            this.lvListarGuests.Size = new Size(900, 200);
            this.lvListarGuests.Location = new Point(250, 100);
            List<Model.Guest> listaGuests = Controller.Guest.GetGuests();
            foreach (Model.Guest guest in listaGuests)
            {
                ListViewItem lv_ListaGuest = new ListViewItem(guest.IdGuest.ToString());
                lv_ListaGuest.SubItems.Add(guest.GuestName);
                lv_ListaGuest.SubItems.Add(guest.GuestBirth);
                lv_ListaGuest.SubItems.Add(guest.GuestIdentification);
                lv_ListaGuest.SubItems.Add(guest.MothersName);
                lv_ListaGuest.SubItems.Add(guest.Payment.ToString());
                lvListarGuests.Items.Add(lv_ListaGuest);
            }
            //
            // lvListarGuests
            this.lvListarGuests.MultiSelect = false;
            this.lvListarGuests.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lvListarGuests.Columns.Add("Hóspede", -2, HorizontalAlignment.Left);
            this.lvListarGuests.Columns.Add("Data de Nascimento", -2, HorizontalAlignment.Center);
            this.lvListarGuests.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lvListarGuests.Columns.Add("Nome da Mãe", -2, HorizontalAlignment.Center);
            this.lvListarGuests.Columns.Add("Pagamento", -2, HorizontalAlignment.Center);
            //
            // lblRoom
            this.lblRoom.Text = "Selecione um Quarto Para Registrar a Reserva!";
            this.lblRoom.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblRoom.ForeColor = ColorTranslator.FromHtml("#8492A6");
            this.lblRoom.Location = new Point(247, 335);
            //
            // lvlListarRooms
            this.lvlListarRooms.Location = new Point(250, 360);
            this.lvlListarRooms.Size = new Size(620, 200);
            // this.lvlListarRooms.MultiSelect = true;
            this.lvlListarRooms.CheckBoxes = true;
            List<Model.Room> listaRooms = Controller.Room.GetRooms();
            foreach (Model.Room room in listaRooms)
            {
                ListViewItem lv_ListaRoom = new ListViewItem(room.IdRoom.ToString());
                lv_ListaRoom.SubItems.Add(room.RoomFloor.ToString());
                lv_ListaRoom.SubItems.Add(room.RoomNumber);
                lv_ListaRoom.SubItems.Add(room.RoomDescription);
                lv_ListaRoom.SubItems.Add(room.RoomValue.ToString("C2"));
                lvlListarRooms.Items.Add(lv_ListaRoom);
            }
            //
            // lvlListarRooms
            this.lvlListarRooms.MultiSelect = false;
            this.lvlListarRooms.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lvlListarRooms.Columns.Add("Andar", -2, HorizontalAlignment.Center);
            this.lvlListarRooms.Columns.Add("Número do Quarto", -2, HorizontalAlignment.Center);
            this.lvlListarRooms.Columns.Add("Descrição", -2, HorizontalAlignment.Center);
            this.lvlListarRooms.Columns.Add("Valor da Diária", -2, HorizontalAlignment.Center);
            // 
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvListarGuests);
            this.Controls.Add(this.lvlListarRooms);
            this.Controls.Add(this.dtCheckIn);
            this.Controls.Add(this.dtCheckOut);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblGuest);
            this.Controls.Add(this.lblRoom);

        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((lvListarGuests.SelectedItems.Count > 0) && (lvlListarRooms.CheckedItems.Count > 0))
                {
                    DateTime convertCheckIn = dtCheckIn.Value.Date;
                    dtCheckIn.Value = convertCheckIn.Date;
                    DateTime convertCheckOut = this.dtCheckOut.Value.Date;
                    this.dtCheckOut.Value = convertCheckOut.Date;
                    string IdGuest = this.lvListarGuests.SelectedItems[0].Text;
                    Model.Guest guest = Controller.Guest.GetGuest(Int32.Parse(IdGuest));
                    Model.Reservation reservation = Controller.Reservation.Add(guest, convertCheckIn, convertCheckOut);

                    foreach (ListViewItem room2 in this.lvlListarRooms.CheckedItems)
                    {
                        Model.Room room = Controller.Room.GetRoom(Int32.Parse(room2.Text));
                        reservation.AddRoom(room);
                    }
                    MessageBox.Show("Cadastrado Com Sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecione o Guest e Pelo Menos Um Room!1111");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Selecione o Guest e Pelo Menos Um Room!22222");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
