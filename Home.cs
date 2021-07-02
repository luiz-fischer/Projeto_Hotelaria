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
            ToolStripMenuItem exitMenuDropItem = new ToolStripMenuItem(
                "Exit",
                null,
                new EventHandler(this.exitMenuPrincipal_Click)
                );
            //
            // Create
            ToolStripMenuItem createMenuPrincipal = new ToolStripMenuItem("Create");
            ToolStripMenuItem createGuestMenuPrincipal = new ToolStripMenuItem(
                "Guest",
                null,
                new EventHandler(this.guestCreateMenuPrincipal_Click)
                );

            ToolStripMenuItem createLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Reservation",
                null,
                new EventHandler(this.locacaoCreateMenuPrincipal_Click)
                );
            ToolStripMenuItem createVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Room",
                null,
                new EventHandler(this.veiculoCreateMenuPrincipal_Click)
                );
            //
            // Search
            ToolStripMenuItem searchMenuPrincipal = new ToolStripMenuItem("Search");
            ToolStripMenuItem searchGuestMenuPrincipal = new ToolStripMenuItem(
                "Guest",
                null,
                new EventHandler(this.guestSearchMenuPrincipal_Click)
                );
            ToolStripMenuItem searchLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Reservation",
                null,
                new EventHandler(this.locacaoSearchMenuPrincipal_Click)
                );
            ToolStripMenuItem searchVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Room",
                null,
                new EventHandler(this.veiculoSearchMenuPrincipal_Click)
                );
            //
            // List
            ToolStripMenuItem listMenuPrincipal = new ToolStripMenuItem("List");
            ToolStripMenuItem listGuestMenuPrincipal = new ToolStripMenuItem(
                "Guests",
                null,
                new EventHandler(this.guestListMenuPrincipal_Click)
                );

            ToolStripMenuItem listLocacaoMenuPrincipal = new ToolStripMenuItem(
                "Locações",
                null,
                new EventHandler(this.locacaoListMenuPrincipal_Click)
                );

            ToolStripMenuItem listVeiculoMenuPrincipal = new ToolStripMenuItem(
                "Rooms",
                null,
                new EventHandler(this.veiculoListMenuPrincipal_Click)
                );
            //
            // Windows
            ToolStripMenuItem windowsMenuPrincipal = new ToolStripMenuItem("Windows");
            // Home
            homeMenuPrincipal.DropDownItems.Add(homeMenuDropItem);
            homeMenuPrincipal.DropDownItems.Add(exitMenuDropItem);
            // Create
            createMenuPrincipal.DropDownItems.Add(createGuestMenuPrincipal);
            createMenuPrincipal.DropDownItems.Add(createLocacaoMenuPrincipal);
            createMenuPrincipal.DropDownItems.Add(createVeiculoMenuPrincipal);
            // Search
            searchMenuPrincipal.DropDownItems.Add(searchGuestMenuPrincipal);
            searchMenuPrincipal.DropDownItems.Add(searchLocacaoMenuPrincipal);
            searchMenuPrincipal.DropDownItems.Add(searchVeiculoMenuPrincipal);
            // List
            listMenuPrincipal.DropDownItems.Add(listGuestMenuPrincipal);
            listMenuPrincipal.DropDownItems.Add(listLocacaoMenuPrincipal);
            listMenuPrincipal.DropDownItems.Add(listVeiculoMenuPrincipal);

            ms.MdiWindowListItem = windowsMenuPrincipal;

            ms.Items.Add(homeMenuPrincipal);
            ms.Items.Add(createMenuPrincipal);
            ms.Items.Add(searchMenuPrincipal);
            ms.Items.Add(listMenuPrincipal);
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
            // Call the method that changes the background color.
            this.SetBackGroundColorOfMDIForm();


        }
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = ColorTranslator.FromHtml("#748E83");
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
        private void guestCreateMenuPrincipal_Click(object sender, EventArgs e)
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
        private void guestSearchMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarGuest consultarGuest = new ConsultarGuest();
            // consultarGuest.MdiParent = this;
            // consultarGuest.Text = "PESQUISAR CLIENTE " + this.MdiChildren.Length.ToString();
            // consultarGuest.Show();
        }
        private void locacaoSearchMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarLocacao consultarLocacao = new ConsultarLocacao();
            // consultarLocacao.MdiParent = this;
            // consultarLocacao.Text = "PESQUISAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // consultarLocacao.Show();
        }
        private void veiculoSearchMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ConsultarVeiculo consultarVeiculo = new ConsultarVeiculo();
            // consultarVeiculo.MdiParent = this;
            // consultarVeiculo.Text = "PESQUISAR VEÍCULO " + this.MdiChildren.Length.ToString();
            // consultarVeiculo.Show();
        }
        private void guestListMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListGuest listaGuest = new ListGuest();
            // listaGuest.MdiParent = this;
            // listaGuest.Text = "LISTAR CLIENTE " + this.MdiChildren.Length.ToString();
            // listaGuest.Show();
        }
        private void locacaoListMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListLocacoes listaLocacao = new ListLocacoes();
            // listaLocacao.MdiParent = this;
            // listaLocacao.Text = "LISTAR LOCAÇÃO " + this.MdiChildren.Length.ToString();
            // listaLocacao.Show();
        }
        private void veiculoListMenuPrincipal_Click(object sender, EventArgs e)
        {
            // ListVeiculo listaVeiculo = new ListVeiculo();
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