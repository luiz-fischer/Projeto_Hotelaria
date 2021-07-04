using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Home : Form
    {
        public Home()
        {

            MenuStrip ms = new();
            //
            // Home
            ToolStripMenuItem homeMenuPrincipal = new("Home");

            ToolStripMenuItem homeMenuDropItem = new(
                "Home",
                null,
                new EventHandler(this.homeMenuPrincipal_Click)
                );
            ToolStripMenuItem exitMenuDropItem = new(
                "Sair",
                null,
                new EventHandler(this.exitMenuPrincipal_Click)
                );
            //
            // Cadastrar
            ToolStripMenuItem cadastrarMenuPrincipal = new("Cadastrar");
            ToolStripMenuItem cadastrarHospedeMenuPrincipal = new(
                "Hospede",
                null,
                new EventHandler(this.hospedeCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarEmpregadoMenuPrincipal = new(
                "Empregado",
                null,
                new EventHandler(this.empregadoCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarProdutoMenuPrincipal = new(
                "Produto",
                null,
                new EventHandler(this.produtoCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarDespesasMenuPrincipal = new(
                "Despesas",
                null,
                new EventHandler(this.despesasCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarReservasMenuPrincipal = new(
                "Reservas",
                null,
                new EventHandler(this.reservasCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarLimpezaMenuPrincipal = new(
                "Limpeza",
                null,
                new EventHandler(this.limpezaCadastrarMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarQuartoMenuPrincipal = new(
                "Quarto",
                null,
                new EventHandler(this.quartoCadastrarMenuPrincipal_Click)
                );
            //
            // Pesquisar
            ToolStripMenuItem pesquisarMenuPrincipal = new("Pesquisar");
            ToolStripMenuItem pesquisarHospedeMenuPrincipal = new(
                "Hospede",
                null,
                new EventHandler(this.hospedePesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarEmpregadoMenuPrincipal = new(
                "Empregado",
                null,
                new EventHandler(this.empregadoPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarProdutoMenuPrincipal = new(
                "Produto",
                null,
                new EventHandler(this.produtoPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarDespesasMenuPrincipal = new(
                "Despesas",
                null,
                new EventHandler(this.despesasPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarReservasMenuPrincipal = new(
                "Reservas",
                null,
                new EventHandler(this.reservasPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarLimpezaMenuPrincipal = new(
                "Limpeza",
                null,
                new EventHandler(this.limpezaPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarQuartoMenuPrincipal = new(
                "Quarto",
                null,
                new EventHandler(this.quartoPesquisarMenuPrincipal_Click)
                );
            //
            // Listar
            ToolStripMenuItem listarMenuPrincipal = new("Listar");
            ToolStripMenuItem listarHospedeMenuPrincipal = new(
                "Hospede",
                null,
                new EventHandler(this.hospedeListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarEmpregadoMenuPrincipal = new(
                "Empregado",
                null,
                new EventHandler(this.empregadoListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarProdutoMenuPrincipal = new(
                "Produto",
                null,
                new EventHandler(this.produtoListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarDespesasMenuPrincipal = new(
                "Despesas",
                null,
                new EventHandler(this.despesasListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarReservasMenuPrincipal = new(
                "Reservas",
                null,
                new EventHandler(this.reservasListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarLimpezaMenuPrincipal = new(
                "Limpeza",
                null,
                new EventHandler(this.limpezaListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarQuartoMenuPrincipal = new(
                "Quarto",
                null,
                new EventHandler(this.quartoListarMenuPrincipal_Click)
                );
            //
            // Windows
            ToolStripMenuItem windowsMenuPrincipal = new("Windows");
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
            // Pesquisar
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarHospedeMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarEmpregadoMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarProdutoMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarDespesasMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarLimpezaMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarReservasMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarQuartoMenuPrincipal);
            // Listar
            listarMenuPrincipal.DropDownItems.Add(listarHospedeMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarEmpregadoMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarProdutoMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarDespesasMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarLimpezaMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarReservasMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarQuartoMenuPrincipal);

            ms.MdiWindowListItem = windowsMenuPrincipal;

            ms.Items.Add(homeMenuPrincipal);
            ms.Items.Add(cadastrarMenuPrincipal);
            ms.Items.Add(pesquisarMenuPrincipal);
            ms.Items.Add(listarMenuPrincipal);
            ms.Items.Add(windowsMenuPrincipal);
            ms.Dock = DockStyle.Top;
            this.MainMenuStrip = ms;

            this.SetBounds(
                0,
                0,
                Screen.PrimaryScreen.WorkingArea.Width,
                Screen.PrimaryScreen.WorkingArea.Height
            );
            ms.BackColor = ColorTranslator.FromHtml("#C0CCDA");
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Font;
            ms.Font = new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold);
            ms.Renderer = new MyRenderer();
            this.Controls.Add(ms);
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
            Home home = new();
            home.Show();
        }
        private void exitMenuPrincipal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void hospedeCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new();
            createGuest.MdiParent = this;
            createGuest.Text = "CADASTRAR HÓSPEDE" + this.MdiChildren.Length.ToString();
            createGuest.Show();
        }
        private void empregadoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateEmployee createEmployee = new();
            createEmployee.MdiParent = this;
            createEmployee.Text = "CADASTRAR EMPREGADO " + this.MdiChildren.Length.ToString();
            createEmployee.Show();
        }

        private void produtoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new();
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
            CreateClean createClean = new();
            createClean.MdiParent = this;
            createClean.Text = "CADASTRAR LIMPEZA " + this.MdiChildren.Length.ToString();
            createClean.Show();
        }
        private void reservasCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateReservation createReservation = new();
            createReservation.MdiParent = this;
            createReservation.Text = "CADASTRAR RESERVA " + this.MdiChildren.Length.ToString();
            createReservation.Show();
        }
        private void quartoCadastrarMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new();
            createRoom.MdiParent = this;
            createRoom.Text = "CADASTRAR QUARTO " + this.MdiChildren.Length.ToString();
            createRoom.Show();
        }

         private void hospedePesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateGuest createGuest = new();
            // createGuest.MdiParent = this;
            // createGuest.Text = "CADASTRAR HÓSPEDE" + this.MdiChildren.Length.ToString();
            // createGuest.Show();
        }
        private void empregadoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateEmployee createEmployee = new();
            // createEmployee.MdiParent = this;
            // createEmployee.Text = "CADASTRAR EMPREGADO " + this.MdiChildren.Length.ToString();
            // createEmployee.Show();
        }

        private void produtoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateProduct createProduct = new();
            // createProduct.MdiParent = this;
            // createProduct.Text = "CADASTRAR PRODUTO " + this.MdiChildren.Length.ToString();
            // createProduct.Show();
        }
        private void despesasPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateExpense createExpense = new CreateExpense();
            // createExpense.MdiParent = this;
            // createExpense.Text = "CADASTRAR DESPESA " + this.MdiChildren.Length.ToString();
            // createExpense.Show();
        }
        private void limpezaPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateClean createClean = new();
            // createClean.MdiParent = this;
            // createClean.Text = "CADASTRAR LIMPEZA " + this.MdiChildren.Length.ToString();
            // createClean.Show();
        }
        private void reservasPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateReservation createReservation = new();
            // createReservation.MdiParent = this;
            // createReservation.Text = "CADASTRAR RESERVA " + this.MdiChildren.Length.ToString();
            // createReservation.Show();
        }
        private void quartoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateRoom createRoom = new();
            // createRoom.MdiParent = this;
            // createRoom.Text = "CADASTRAR QUARTO " + this.MdiChildren.Length.ToString();
            // createRoom.Show();
        } 
        private void hospedeListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListGuests listGuests = new();
            listGuests.MdiParent = this;
            listGuests.Text = "LISTAR HÓSPEDE" + this.MdiChildren.Length.ToString();
            listGuests.Show();
        }
        private void empregadoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListEmployees listEmployees = new();
            listEmployees.MdiParent = this;
            listEmployees.Text = "LISTR EMPREGADO " + this.MdiChildren.Length.ToString();
            listEmployees.Show();
        }

        private void produtoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListProducts listProducts = new();
            listProducts.MdiParent = this;
            listProducts.Text = "LISTAR PRODUTO " + this.MdiChildren.Length.ToString();
            listProducts.Show();
        }
        private void despesasListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateExpense createExpense = new CreateExpense();
            // createExpense.MdiParent = this;
            // createExpense.Text = "CADASTRAR DESPESA " + this.MdiChildren.Length.ToString();
            // createExpense.Show();
        }
        private void limpezaListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CreateClean createClean = new();
            // createClean.MdiParent = this;
            // createClean.Text = "CADASTRAR LIMPEZA " + this.MdiChildren.Length.ToString();
            // createClean.Show();
        }
        private void reservasListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListReservation listReservation = new();
            listReservation.MdiParent = this;
            listReservation.Text = "CADASTRAR RESERVA " + this.MdiChildren.Length.ToString();
            listReservation.Show();
        }
        private void quartoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            ListRoom listRooms = new();
            listRooms.MdiParent = this;
            listRooms.Text = "CADASTRAR QUARTO " + this.MdiChildren.Length.ToString();
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
                    Pen pen = new(ColorTranslator.FromHtml("#F9FAFC"));
                    SolidBrush solidBrush = new(ColorTranslator.FromHtml("#3C4858"));//
                    e.Item.Font = new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Bold);
                    e.Item.ForeColor = ColorTranslator.FromHtml("#D3DCE6");
                    Rectangle rectangle = new(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(solidBrush, rectangle);
                    e.Graphics.DrawRectangle(pen, 0, 0, rectangle.Width, rectangle.Height);
                    pen.Dispose();
                    solidBrush.Dispose();
                }

            }

        }
    }
}