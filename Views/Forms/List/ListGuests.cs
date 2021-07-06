using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListGuests : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnCancelar;
        private Library.Button btnConfirmar;
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.Label lblTableGuest;
        private Library.ListView lvGuest;

        public ListGuests()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnRelatorio = new Library.Button("btnRelatorio");
            this.lvGuest = new Library.ListView();
            this.lblTitle = new Library.Label();
            this.lblTableGuest = new Library.Label();
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Hóspedes";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblTableGuest
            this.lblTableGuest.Text = "Selecione um Hóspede para Consultar, Exlcuir ou Alterar!";
            this.lblTableGuest.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblTableGuest.Location = new Point(500, 70);
            this.lblTableGuest.Size = new Size(700, 30);
            //
            // lvGuest
            this.lvGuest.Size = new Size(1050, 400);
            this.lvGuest.Location = new Point(250, 100);
 
            List<Guest> guestList = Controller.Guest.GetGuests();
            foreach (Guest guest in guestList)
            {
                ListViewItem lvListGuest = new ListViewItem(guest.IdGuest.ToString());
                lvListGuest.SubItems.Add(guest.GuestName);
                lvListGuest.SubItems.Add(guest.GuestBirth);
                lvListGuest.SubItems.Add(guest.GuestIdentification);
                lvListGuest.SubItems.Add(guest.MothersName.ToString());
                lvGuest.Items.Add(lvListGuest);
            }

            this.lvGuest.MultiSelect = false;
            this.lvGuest.Columns.Add("ID Guest", -2, HorizontalAlignment.Center);
            this.lvGuest.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
            this.lvGuest.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            this.lvGuest.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lvGuest.Columns.Add("Nome da Mãe", -2, HorizontalAlignment.Center);
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
            this.Controls.Add(this.lvGuest);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTableGuest);
            this.Text = "       LISTAR HÓSPEDES";

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportGuest.ReportGuestPdf();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdGuest = this.lvGuest.SelectedItems[0].Text;
                Guest guest = Controller.Guest.GetGuest(Int32.Parse(IdGuest));
                EditGuest editGuest = new EditGuest(guest);
                editGuest.Show();
            }
            catch
            {
                MessageBox.Show("Selecionar um Hóspede!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

 