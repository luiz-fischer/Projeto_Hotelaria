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
        private Library.Button btnRelatorio;
        private Library.Label lblTitle;
        private Library.ListView lvGuest;

        public ListGuests()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.menu_side = new Library.PictureBox("menu_side");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.btnRelatorio = new Library.Button("btnRelatorio");

            this.lvGuest = new Library.ListView();
            this.lblTitle = new();
            //
            // btnCancelar
            
            //
            // lblTitle
            this.lblTitle.Text = "Lista de Hóspedes";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lvGuest
            this.lvGuest.Size = new Size(1050, 400);
            this.lvGuest.Location = new Point(250, 100);

            List<Model.Guest> guestList = Controller.Guest.GetGuests();
            foreach (var guest in guestList)
            {
                ListViewItem lvListGuest = new(guest.IdGuest.ToString());
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
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lvGuest);
            this.Text = "       LISTAR HÓSPEDES";
            //
            // btnCancelar
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Location = new Point(780, 620);
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
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.lblTitle);

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            ReportGuest.ReportGuestPdf();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
 