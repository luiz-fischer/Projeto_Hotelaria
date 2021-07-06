using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;

namespace View
{
    public partial class ListGuests : Form
    {
        private Library.Button btnCancel;
        private Library.Button btnConfirm;
        private Library.Button btnReport;
        private Library.Label lblTitle;
        private Library.Label lblTableGuest;
        private Library.ListView lvGuest;

        public ListGuests()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.btnCancel = new Library.Button("btnCancel");
            this.btnConfirm = new Library.Button("btnConfirm");
            this.btnReport = new Library.Button("btnReport");
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
            this.Controls.Add(this.lvGuest);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTableGuest);
            this.Text = "       LISTAR HÓSPEDES";

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportGuest.ReportGuestPdf();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

 