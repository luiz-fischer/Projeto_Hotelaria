using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace View
{
    public class CreateClean : Form
    {
        private Library.PictureBox logo_size_invert;
        private Library.Button btnConfirmar;
        private Library.Button btnCancelar;
        private Library.Label lblTitle;
        private Library.Label lblEmployee;
        private Library.Label lblRoom;
        private Library.ListView lvEmployee;
        private Library.ListView lvRoom;
        Model.Clean clean;


        public CreateClean(int id = 0)
        {

            try
            {
                clean = Controller.Clean.GetClean(id);
            }
            catch
            {

            }
            InitializeComponent(id > 0);
        }

        public void InitializeComponent(bool isUpdate)
        {
            this.logo_size_invert = new Library.PictureBox("logo_size_full");
            this.btnConfirmar = new Library.Button("btnConfirmar");
            this.btnCancelar = new Library.Button("btnCancelar");
            this.lblEmployee = new Library.Label();
            this.lblRoom = new Library.Label();
            this.lvEmployee = new Library.ListView();
            this.lvRoom = new Library.ListView();
            this.lblTitle = new();
            //
            // btnConfirmar
            this.btnConfirmar.Location = new Point(600, 620);
            //
            // btnCancelar
            this.btnCancelar.Location = new Point(780, 620);
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            //
            // lblTitle
            this.lblTitle.Text = "Cadastro de Limpeza";
            this.lblTitle.Location = new Point(600, 10);
            //
            // lblEmployee
            this.lblEmployee.Text = "Selecione um Empregado";
            this.lblEmployee.Location = new Point(236, 50);
            this.lblEmployee.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblEmployee.Size = new Size(300, 30);
            //
            // lvEmployee
            this.lvEmployee.Location = new Point(240, 80);
            List<Model.Employee> listEmployees = Controller.Employee.GetEmployees();
            foreach (Model.Employee employee in listEmployees)
            {
                ListViewItem lvListEmployee = new(employee.EmployeeId.ToString());
                lvListEmployee.SubItems.Add(employee.EmployeeName);
                lvEmployee.Items.Add(lvListEmployee);
            }
            this.lvEmployee.MultiSelect = false;
            this.lvEmployee.Columns.Add("ID Empregado", -2, HorizontalAlignment.Center);
            this.lvEmployee.Columns.Add("Nome Completo", -2, HorizontalAlignment.Center);
            //
            // lblRoom
            this.lblRoom.Text = "Selecione um Quarto";
            this.lblRoom.Location = new Point(236, 310);
            this.lblRoom.Font = new Font("Roboto", 16F, GraphicsUnit.Point);
            this.lblRoom.Size = new Size(300, 30);
            //
            // lvRoom
            this.lvRoom.Location = new Point(240, 340);

            List<Model.Room> listRooms = Controller.Room.GetRooms();
            foreach (Model.Room room in listRooms)
            {
                ListViewItem lvListRoom = new(room.IdRoom.ToString());
                lvListRoom.SubItems.Add(room.RoomFloor.ToString());
                lvListRoom.SubItems.Add(room.RoomNumber.ToString());
                lvListRoom.SubItems.Add(room.RoomValue.ToString("C2"));
                lvListRoom.SubItems.Add(room.RoomDescription);

                lvRoom.Items.Add(lvListRoom);
            }
            this.lvRoom.MultiSelect = false;
            this.lvRoom.Columns.Add("ID Quarto", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Andar", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Quarto", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Valor", -2, HorizontalAlignment.Center);
            this.lvRoom.Columns.Add("Descrição", -2, HorizontalAlignment.Center);
            //
            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.Controls.Add(this.logo_size_invert);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lvEmployee);
            this.Controls.Add(this.lvRoom);
            this.Controls.Add(this.lblTitle);


        }
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((lvEmployee.SelectedItems.Count > 0) && (lvRoom.CheckedItems.Count > 0))
                {
                    string EmployeeId = this.lvEmployee.SelectedItems[0].Text;
                    Model.Employee employee = Controller.Employee.GetEmployee(Int32.Parse(EmployeeId));
                    Model.Clean clean = Controller.Clean.Add(employee);

                    foreach (ListViewItem Room in this.lvRoom.CheckedItems)
                    {
                        Model.Room room = Controller.Room.GetRoom(Int32.Parse(Room.Text));
                        // clean.AddRoom(room);
                    }
                    MessageBox.Show("Locação Realizada!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecione o Cliente e Pelo Menos Um Veiculo!");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Selecione o Cliente e Pelo Menos Um Veiculo!");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
