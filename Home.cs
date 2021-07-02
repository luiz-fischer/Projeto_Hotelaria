using System;
using System.Drawing;
using System.Windows.Forms;


namespace View
{
    public class Home : Form
    {
        public Home()
        {

            MenuStrip ms = new MenuStrip();
            //
            // Homes
            ToolStripMenuItem homeMenuPrincipal = new ToolStripMenuItem("Home");

            ToolStripMenuItem homeMenuDropItem = new ToolStripMenuItem(
                "Home",
                null,
                new EventHandler(this.homeMenuPrincipal_Click)
                );
            ToolStripMenuItem sairMenuDropItem = new ToolStripMenuItem(
                "Sair",
                null,
                new EventHandler(this.sairMenuPrincipal_Click)
                );
            //
            // Create
            ToolStripMenuItem cadastrarMenuPrincipal = new ToolStripMenuItem("Create");
            ToolStripMenuItem cadastrarClienteMenuPrincipal = new ToolStripMenuItem(
                "Cliente",
                null,
                new EventHandler(this.clienteCreateMenuPrincipal_Click)
                );

            ToolStripMenuItem cadastrarLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Locação",
                null,
                new EventHandler(this.locacaoCreateMenuPrincipal_Click)
                );
            ToolStripMenuItem cadastrarVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Veículo",
                null,
                new EventHandler(this.veiculoCreateMenuPrincipal_Click)
                );
            //
            // Pesquisar
            ToolStripMenuItem pesquisarMenuPrincipal = new ToolStripMenuItem("Pesquisar");
            ToolStripMenuItem pesquisarClienteMenuPrincipal = new ToolStripMenuItem(
                "Cliente",
                null,
                new EventHandler(this.clientePesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Locação",
                null,
                new EventHandler(this.locacaoPesquisarMenuPrincipal_Click)
                );
            ToolStripMenuItem pesquisarVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Veículo",
                null,
                new EventHandler(this.veiculoPesquisarMenuPrincipal_Click)
                );
            //
            // Listar
            ToolStripMenuItem listarMenuPrincipal = new ToolStripMenuItem("Listar");
            ToolStripMenuItem listarClienteMenuPrincipal = new ToolStripMenuItem(
                "Clientes",
                null,
                new EventHandler(this.clienteListarMenuPrincipal_Click)
                );

            ToolStripMenuItem listarLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Locações",
                null,
                new EventHandler(this.locacaoListarMenuPrincipal_Click)
                );

            ToolStripMenuItem listarVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Veículos",
                null,
                new EventHandler(this.veiculoListarMenuPrincipal_Click)
                );
            //
            // Windows
            ToolStripMenuItem windowsMenuPrincipal = new ToolStripMenuItem("Windows");
            // Home
            homeMenuPrincipal.DropDownItems.Add(homeMenuDropItem);
            homeMenuPrincipal.DropDownItems.Add(sairMenuDropItem);
            // Create
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarClienteMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarLocacaoMenuPrincipal);
            cadastrarMenuPrincipal.DropDownItems.Add(cadastrarVeiculoMenuPrincipal);
            // Pesquisar
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarClienteMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarLocacaoMenuPrincipal);
            pesquisarMenuPrincipal.DropDownItems.Add(pesquisarVeiculoMenuPrincipal);
            // Listar
            listarMenuPrincipal.DropDownItems.Add(listarClienteMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarLocacaoMenuPrincipal);
            listarMenuPrincipal.DropDownItems.Add(listarVeiculoMenuPrincipal);

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
            ms.BackColor = System.Drawing.ColorTranslator.FromHtml("#3C4858");
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Font;
            ms.Font = new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold);
            ms.Renderer = new MyRenderer();
            this.Controls.Add(ms);

            this.IsMdiContainer = true;
            // Call the method that changes the background color.
            this.SetBackGroundColorOfMDIForm();


        }
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(40, 105, 85);
                }
            }
        }
        private void homeMenuPrincipal_Click(object sender, EventArgs e)
        {
            Home home = new();
            home.Show();
        }
        private void sairMenuPrincipal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void clienteCreateMenuPrincipal_Click(object sender, EventArgs e)
        {
            CreateClean createClean = new CreateClean();
            createClean.MdiParent = this;
            createClean.Text = "CADASTRAR LIMPEZA DE QUARTO" + this.MdiChildren.Length.ToString();
            createClean.Show();
        }
        private void locacaoCreateMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CriarLocacao criarLocacao = new CriarLocacao();
            // criarLocacao.MdiParent = this;
            // criarLocacao.Text = "CADASTRAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // criarLocacao.Show();
        }
        private void veiculoCreateMenuPrincipal_Click(object sender, EventArgs e)
        {
            // CriarVeiculo criarVeiculo = new CriarVeiculo();
            // criarVeiculo.MdiParent = this;
            // criarVeiculo.Text = "CADASTRAR VEÍCULO " + this.MdiChildren.Length.ToString();
            // criarVeiculo.Show();
        }
        private void clientePesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarCliente consultarCliente = new ConsultarCliente();
            // consultarCliente.MdiParent = this;
            // consultarCliente.Text = "PESQUISAR CLIENTE " + this.MdiChildren.Length.ToString();
            // consultarCliente.Show();
        }
        private void locacaoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarLocacao consultarLocacao = new ConsultarLocacao();
            // consultarLocacao.MdiParent = this;
            // consultarLocacao.Text = "PESQUISAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // consultarLocacao.Show();
        }
        private void veiculoPesquisarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarVeiculo consultarVeiculo = new ConsultarVeiculo();
            // consultarVeiculo.MdiParent = this;
            // consultarVeiculo.Text = "PESQUISAR VEÍCULO " + this.MdiChildren.Length.ToString();
            // consultarVeiculo.Show();
        }
        private void clienteListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarCliente listaCliente = new ListarCliente();
            // listaCliente.MdiParent = this;
            // listaCliente.Text = "LISTAR CLIENTE " + this.MdiChildren.Length.ToString();
            // listaCliente.Show();
        }
        private void locacaoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarLocacoes listaLocacao = new ListarLocacoes();
            // listaLocacao.MdiParent = this;
            // listaLocacao.Text = "LISTAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // listaLocacao.Show();
        }
        private void veiculoListarMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListarVeiculo listaVeiculo = new ListarVeiculo();
            // listaVeiculo.MdiParent = this;
            // listaVeiculo.Text = "LISTAR VEÍCULOS " + this.MdiChildren.Length.ToString();
            // listaVeiculo.Show();
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    e.Item.ForeColor = Color.DarkGray;
                    base.OnRenderMenuItemBackground(e);
                }
                else
                {
                    Pen pen = new(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    SolidBrush solidBrush = new(System.Drawing.ColorTranslator.FromHtml("#3C4858"));//
                    e.Item.Font = new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Bold);
                    e.Item.ForeColor = System.Drawing.ColorTranslator.FromHtml("#8492A6");
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