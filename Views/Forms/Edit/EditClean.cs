using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace View
{
    partial class EditClean : Form
    {
        private Library.PictureBox menu_side;
        private Library.Button btnDeletar;
        private Library.Button btnAlterar;
        private Library.Button btnCancelar;
        private Library.Label lblDataClean;
        private Library.RichTextBox richTextBoxClean;
        private Library.Label lblTitle;

        private int idClean;
        protected Clean Clean;

        public EditClean(Clean clean)
        {
            InitializeComponent(clean);
        }
        public void InitializeComponent(Clean clean)
        {

            this.btnDeletar = new Library.Button("btnDeletar");
            this.btnAlterar = new Library.Button("btnAlterar");
            this.btnCancelar = new Library.Button("btnCancelar");;
            this.menu_side = new Library.PictureBox("menu_side");
            this.lblDataClean = new Library.Label();
            this.richTextBoxClean = new Library.RichTextBox();
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
            this.lblTitle.Text = "EDITAR LIMPEZA";
            this.lblTitle.Location = new Point(600, 10);
            this.btnCancelar.Location = new Point(810, 510);
            // 
            // lblDataClean
            this.lblDataClean.Text = "DADOS DA LIMPEZA";
            this.lblDataClean.Location = new Point(600, 145);
            this.lblDataClean.Size = new Size(500, 25);
            this.lblDataClean.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // richTextBoxClean
            this.richTextBoxClean.Location = new Point(410, 170);
            this.richTextBoxClean.Size = new Size(600, 300);
            List<Clean> cleanList = Controller.Clean.GetCleans();
            foreach (var cleanVar in cleanList)
            {
                Employee employee = Controller.Employee.GetEmployee(cleanVar.EmployeeId);
                Room room = Controller.Room.GetRoom(cleanVar.RoomId);

            this.richTextBoxClean.Text =  
                "\n\n ID da Limpeza:                                         "      + cleanVar.CleanId.ToString() +
                "\n Data da Limpeza:                                    "           + cleanVar.Date.ToString("dd/MM/yyyy") +
                "\n ID do Responsável:                                "             + employee.EmployeeId.ToString() +
                "\n Nome do Resonsável:                            "                + employee.EmployeeName +
                "\n Total de Quartos:                                    "          + cleanVar.GetRoomsByEmployee() +
                "\n Andar:                                                        " + room.RoomFloor.ToString() +
                "\n Número do Quarto:                                 "             + room.RoomNumber +
                "\n Descrição do Quarto:                             "              + room.RoomDescription ;
            }
            //      
            // Home
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.menu_side);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblDataClean);
            this.Controls.Add(this.richTextBoxClean);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR LIMPEZA";
            this.idClean = clean.CleanId;
            this.Clean = clean;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new(idClean);
            createGuest.Show();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Essa Limpeza?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Controller.Guest.DeleteGuest(idClean);
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
