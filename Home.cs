using System;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace pig202101_hotel
{
    public class Home : Form
    {
        private readonly Library.PictureBox menu_side;
        private readonly Library.Button btnCreateGuest;
        private readonly Library.Button btnCreateEmployee;
        private readonly Library.Button btnCreateReservation;
        private readonly Library.Button btnCreateRoom;

        public Home()
        {

            MenuStrip menuStrip = new MenuStrip();
            //
            // Home
            ToolStripMenuItem homeMenuPrincipal = new ToolStripMenuItem("Home");

            ToolStripMenuItem homeMenuDropItem = new ToolStripMenuItem(
                "Home",
                null,
                new EventHandler(this.homeMenuPrincipal_Click)
                );
            ToolStripMenuItem exitMenuDropItem = new ToolStripMenuItem(
                "Sair",
                null,
                new EventHandler(this.exitMenuPrincipal_Click)
                );
            //
            // Cadastrar
            ToolStripMenuItem cadastrarMenuPrincipal = new ToolStripMenuItem("Cadastrar");
            ToolStripMenuItem cadastrarHospedeMenuPrincipal = new ToolStripMenuItem(
                "Hospede",
                null,
                new EventHandler(this.hospedeCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarEmpregadoMenuPrincipal = new ToolStripMenuItem(
                "Empregado",
                null,
                new EventHandler(this.empregadoCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarProdutoMenuPrincipal = new ToolStripMenuItem(
                "Produto",
                null,
                new EventHandler(this.produtoCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarDespesasMenuPrincipal = new ToolStripMenuItem(
                "Despesas",
                null,
                new EventHandler(this.despesasCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarReservasMenuPrincipal = new ToolStripMenuItem(
                "Reservas",
                null,
                new EventHandler(this.reservasCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarLimpezaMenuPrincipal = new ToolStripMenuItem(
                "Limpeza",
                null,
                new EventHandler(this.limpezaCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarQuartoMenuPrincipal = new ToolStripMenuItem(
                "Quarto",
                null,
                new EventHandler(this.quartoCadastrarMenuPrincipal_Click)
                );
            //
            // Listar
            ToolStripMenuItem listarMenuPrincipal = new ToolStripMenuItem("Listar");
            ToolStripMenuItem listarHospedeMenuPrincipal = new ToolStripMenuItem(
                "Hospede",
                null,
                new EventHandler(this.hospedeListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarEmpregadoMenuPrincipal = new ToolStripMenuItem(
                "Empregado",
                null,
                new EventHandler(this.empregadoListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarProdutoMenuPrincipal = new ToolStripMenuItem(
                "Produto",
                null,
                new EventHandler(this.produtoListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarDespesasMenuPrincipal = new ToolStripMenuItem(
                "Despesas",
                null,
                new EventHandler(this.despesasListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarReservasMenuPrincipal = new ToolStripMenuItem(
                "Reservas",
                null,
                new EventHandler(this.reservasListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarLimpezaMenuPrincipal = new ToolStripMenuItem(
                "Limpeza",
                null,
                new EventHandler(this.limpezaListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarQuartoMenuPrincipal = new ToolStripMenuItem(
                "Quarto",
                null,
                new EventHandler(this.quartoListarMenuPrincipal_Click)
                );
            //
            // Windows
            ToolStripMenuItem windowsMenuPrincipal = new ToolStripMenuItem("Windows");
            //
            // menu_side
            this.menu_side = new Library.PictureBox("menu_side");
            this.menu_side.Location = new Point(10, 35);
            //
            // btnCreateGuest 
            this.btnCreateGuest = new Library.Button("btnMenu");
            this.btnCreateGuest.Location = new Point(34, 250);
            this.btnCreateGuest.Text = "Cadastro de Hóspede";
            this.btnCreateGuest.Click += new EventHandler(this.hospedeCadastrarMenuPrincipal_Click);
            //
            // btnCreateEmployee 
            this.btnCreateEmployee = new Library.Button("btnMenu");
            this.btnCreateEmployee.Location = new Point(34, 310);
            this.btnCreateEmployee.Text = "Cadastro de Empregado";
            this.btnCreateEmployee.Click += new EventHandler(this.empregadoCadastrarMenuPrincipal_Click);
            //
            // btnCreateReservation 
            this.btnCreateReservation = new Library.Button("btnMenu");
            this.btnCreateReservation.Location = new Point(34, 370);
            this.btnCreateReservation.Text = "Cadastro de Reservas";
            this.btnCreateReservation.Click += new EventHandler(this.reservasCadastrarMenuPrincipal_Click);
            //
            // btnCreateRoom 
            this.btnCreateRoom = new Library.Button("btnMenu");
            this.btnCreateRoom.Location = new Point(34, 430);
            this.btnCreateRoom.Text = "Cadastro de Quartos";
            this.btnCreateRoom.Click += new EventHandler(this.quartoCadastrarMenuPrincipal_Click);
           
            // Home
            homeMenuPrincipal.DropDownItems.Add(homeMenuDropItem);
            homeMenuPrincipal.DropDownItems.Add(exitMenuDropItem);
            // Cadastrar
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarHospedeMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarEmpregadoMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarProdutoMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarDespesasMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarLimpezaMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarReservasMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarQuartoMenuPrincipal);
            // Listar
            listarMenuPrincipal.DropDownItems.Add(listarHospedeMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarEmpregadoMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarProdutoMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarDespesasMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarLimpezaMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarReservasMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarQuartoMenuPrincipal);

            menuStrip.MdiWindowListItem = windowsMenuPrincipal;

            menuStrip.Items.Add(homeMenuPrincipal);
            menuStrip.Items.Add(cadastrarMenuPrincipal);
            menuStrip.Items.Add(listarMenuPrincipal);
            menuStrip.Items.Add(windowsMenuPrincipal);
            menuStrip.Dock = DockStyle.Top;
            this.MainMenuStrip = menuStrip;
            this.IsMdiContainer = true;

            this.SetBounds(
                0,
                0,
                Screen.PrimaryScreen.WorkingArea.Width,
                Screen.PrimaryScreen.WorkingArea.Height
            );
            menuStrip.BackColor = ColorTranslator.FromHtml("#C0CCDA");
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Font;
            menuStrip.Font = new Font("Roboto", 8F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip.Renderer = new MyRenderer();
            this.Controls.Add(menuStrip);
            this.Controls.Add(this.btnCreateGuest);
            this.Controls.Add(this.btnCreateEmployee);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.menu_side);
            this.IsMdiContainer = true;

            this.SetBackGroundColorOfMDIForm();


        }
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = ColorTranslator.FromHtml("#E0E6ED");
                }
            }
        }
        private void homeMenuPrincipal_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }
        private void exitMenuPrincipal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void hospedeCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest();
            createGuest.MdiParent = this;
            createGuest.Text = "CADASTRAR HÓSPEDE" + this.MdiChildren.Length.ToString();
            createGuest.Show();
        }
        private void empregadoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee();
            createEmployee.MdiParent = this;
            createEmployee.Text = "CADASTRAR EMPREGADO " + this.MdiChildren.Length.ToString();
            createEmployee.Show();
        }

        private void produtoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.MdiParent = this;
            createProduct.Text = "CADASTRAR PRODUTO " + this.MdiChildren.Length.ToString();
            createProduct.Show();
        }
        private void despesasCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateExpense createExpense = new CreateExpense();
            // createExpense.MdiParent = this;
            // createExpense.Text = "CADASTRAR DESPESA " + this.MdiChildren.Length.ToString();
            // createExpense.Show();
        }
        private void limpezaCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateClean createClean = new CreateClean();
            createClean.MdiParent = this;
            createClean.Text = "CADASTRAR LIMPEZA " + this.MdiChildren.Length.ToString();
            createClean.Show();
        }
        private void reservasCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateReservation createReservation = new CreateReservation();
            createReservation.MdiParent = this;
            createReservation.Text = "CADASTRAR RESERVA " + this.MdiChildren.Length.ToString();
            createReservation.Show();
        }
        private void quartoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom();
            createRoom.MdiParent = this;
            createRoom.Text = "CADASTRAR QUARTO " + this.MdiChildren.Length.ToString();
            createRoom.Show();
        }

        private void hospedeListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListGuests listGuests = new ListGuests();
            listGuests.MdiParent = this;
            listGuests.Text = "LISTAR HÓSPEDE" + this.MdiChildren.Length.ToString();
            listGuests.Show();
        }
        private void empregadoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListEmployees listEmployees = new ListEmployees();
            listEmployees.MdiParent = this;
            listEmployees.Text = "LISTR EMPREGADO " + this.MdiChildren.Length.ToString();
            listEmployees.Show();
        }

        private void produtoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListProducts listProducts = new ListProducts();
            listProducts.MdiParent = this;
            listProducts.Text = "LISTAR PRODUTO " + this.MdiChildren.Length.ToString();
            listProducts.Show();
        }
        private void despesasListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateExpense createExpense = new CreateExpense();
            // createExpense.MdiParent = this;
            // createExpense.Text = "LISTAR DESPESA " + this.MdiChildren.Length.ToString();
            // createExpense.Show();
        }
        private void limpezaListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListCleans listCleans = new ListCleans();
            listCleans.MdiParent = this;
            listCleans.Text = "LISTAR LIMPEZA " + this.MdiChildren.Length.ToString();
            listCleans.Show();
        }
        private void reservasListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListReservation listReservation = new ListReservation();
            listReservation.MdiParent = this;
            listReservation.Text = "LISTAR RESERVA " + this.MdiChildren.Length.ToString();
            listReservation.Show();
        }
        private void quartoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListRoom listRooms = new ListRoom();
            listRooms.MdiParent = this;
            listRooms.Text = "LISTAR QUARTO " + this.MdiChildren.Length.ToString();
            listRooms.Show();
        }
        
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    e.Item.ForeColor = ColorTranslator.FromHtml("#1F2D3D");//
                    base.OnRenderMenuItemBackground(e);
                }
                else
                {
                    Pen pen = new Pen(ColorTranslator.FromHtml("#F9FAFC"));
                    SolidBrush solidBrush = new SolidBrush(ColorTranslator.FromHtml("#3C4858"));//
                    e.Item.Font = new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Bold);
                    e.Item.ForeColor = ColorTranslator.FromHtml("#D3DCE6");
                    Rectangle rectangle = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(solidBrush, rectangle);
                    e.Graphics.DrawRectangle(pen, 0, 0, rectangle.Width, rectangle.Height);
                    pen.Dispose();
                    solidBrush.Dispose();
                }

            }

        }
    }
}