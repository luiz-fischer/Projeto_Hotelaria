using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    partial class EditGuest : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.RichTextBox richTextBoxGuest;
        private Library.Label lblDataGuest;
        private Library.Label lblTitle;

        private int idGuest;
        protected Guest Guest;

        public EditGuest(Guest guest)
        {
            InitializeComponent(guest);
        }

        public void InitializeComponent(Guest guest)
        {
            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.menu_side = new Library.PictureBox("menu_side");
            this.richTextBoxGuest = new Library.RichTextBox();
            this.lblDataGuest = new Library.Label();
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
            this.lblTitle.Text = "EDITAR HÓSPEDE";
            this.lblTitle.Location = new Point(600, 10);
            // 
            // lblDataGuest
            this.lblDataGuest.Text = "DADOS DO HÓSPEDE";
            this.lblDataGuest.Location = new Point(600, 220);
            this.lblDataGuest.Size = new Size(420, 25);
            this.lblDataGuest.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxGuest
            this.richTextBoxGuest.Location = new Point(500, 250);
            this.richTextBoxGuest.Size = new Size(430, 200);
            this.richTextBoxGuest.Text =
                "\n\n ID do Guest:                "         + guest.IdGuest +
                "\n Nome:                           "       + guest.GuestName +
                "\n Data Nascimento:      "                 + guest.GuestBirth +
                "\n CPF:                               "    + guest.GuestIdentification +
                "\n Nome Mãe:                  "            + guest.MothersName;
            //
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.richTextBoxGuest);
            this.Controls.Add(this.lblDataGuest);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR HÓSPEDE";
            this.idGuest = guest.IdGuest;
            this.Guest = guest;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest(idGuest);
            createGuest.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Hóspede?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Guest.DeleteGuest(idGuest);
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
