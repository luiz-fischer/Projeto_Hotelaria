using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace View
{
    partial class EditClean : Form
    {
        private Library.Button btnDelete;
        private Library.Button btnEdit;
        private Library.Button btnCancel;
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

            this.btnDelete = new Library.Button("btnDelete");
            this.btnEdit = new Library.Button("btnEdit");
            this.btnCancel = new Library.Button("btnCancel");;
            this.lblDataClean = new Library.Label();
            this.richTextBoxClean = new Library.RichTextBox();
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
            this.lblTitle.Text = "EDITAR LIMPEZA";
            this.lblTitle.Location = new Point(600, 10);
            this.btnCancel.Location = new Point(810, 510);
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
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDataClean);
            this.Controls.Add(this.richTextBoxClean);
            this.Controls.Add(this.lblTitle);
            this.Text = "       EDITAR LIMPEZA";
            this.idClean = clean.CleanId;
            this.Clean = clean;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest(idClean);
            createGuest.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
