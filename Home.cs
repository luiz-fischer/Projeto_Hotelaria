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
            
            ToolStripMenuItem pesquisarReservasMenuPrincipal = new(
                "Reservas",
                null,
                new EventHandler(this.reservasPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarQuartoMenuPrincipal = new(
                "Quarto",
                null,
                new EventHandler(this.veiculoPesquisarMenuPrincipal_Click)
                );
            //
            // Listar
            ToolStripMenuItem listarMenuPrincipal = new("Listar");
            ToolStripMenuItem listarHospedeMenuPrincipal = new(
                "Hospedes",
                null,
                new EventHandler(this.hospedeListarMenuPrincipal_Click)
                );
            ToolStripMenuItem listarReservasMenuPrincipal = new(
                "Locações",
                null,
                new EventHandler(this.reservasListarMenuPrincipal_Click)
                );

            ToolStripMenuItem listarQuartoMenuPrincipal = new(
                "Quartos",
                null,
                new EventHandler(this.veiculoListarMenuPrincipal_Click)
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
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarReservasMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarQuartoMenuPrincipal);
            // Listar
            listarMenuPrincipal.DropDownItems.Add(listarHospedeMenuPrincipal);
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
            // CriarReservas criarReservas = new CriarReservas();
            // criarReservas.MdiParent = this;
            // criarReservas.Text = "CADASTRAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // criarReservas.Show();
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
            // CriarQuarto criarQuarto = new CriarQuarto();
            // criarQuarto.MdiParent = this;
            // criarQuarto.Text = "CADASTRAR VEÍCULO " + this.MdiChildren.Length.ToString();
            // criarQuarto.Show();
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
            // ConsultarHospede consultarHospede = new ConsultarHospede();
            // consultarHospede.MdiParent = this;
            // consultarHospede.Text = "PESQUISAR CLIENTE " + this.MdiChildren.Length.ToString();
            // consultarHospede.Show();
        }
        private void empregadoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CriarReservas criarReservas = new CriarReservas();
            // criarReservas.MdiParent = this;
            // criarReservas.Text = "CADASTRAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // criarReservas.Show();
        }

        private void reservasPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarReservas consultarReservas = new ConsultarReservas();
            // consultarReservas.MdiParent = this;
            // consultarReservas.Text = "PESQUISAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // consultarReservas.Show();
        }
        private void veiculoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarQuarto consultarQuarto = new ConsultarQuarto();
            // consultarQuarto.MdiParent = this;
            // consultarQuarto.Text = "PESQUISAR VEÍCULO " + this.MdiChildren.Length.ToString();
            // consultarQuarto.Show();
        }
        private void hospedeListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarHospede listaraHospede = new ListarHospede();
            // listaraHospede.MdiParent = this;
            // listaraHospede.Text = "LISTAR CLIENTE " + this.MdiChildren.Length.ToString();
            // listaraHospede.Show();
        }
        private void empregadoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CriarReservas criarReservas = new CriarReservas();
            // criarReservas.MdiParent = this;
            // criarReservas.Text = "CADASTRAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // criarReservas.Show();
        }
        private void reservasListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarLocacoes listaraReservas = new ListarLocacoes();
            // listaraReservas.MdiParent = this;
            // listaraReservas.Text = "LISTAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // listaraReservas.Show();
        }
        private void veiculoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarQuarto listaraQuarto = new ListarQuarto();
            // listaraQuarto.MdiParent = this;
            // listaraQuarto.Text = "LISTAR VEÍCULOS " + this.MdiChildren.Length.ToString();
            // listaraQuarto.Show();
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