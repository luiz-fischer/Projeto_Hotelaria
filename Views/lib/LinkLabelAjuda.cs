using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Library
{
    public class LinkLabelAjuda : System.Windows.Forms.LinkLabel
    {
        public LinkLabelAjuda()
        {
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.ImeMode = ImeMode.NoControl;
            this.Location = new Point(1283, 646);
            this.Size = new Size(41, 15);
            this.TabIndex = 38;
            this.TabStop = true;
            this.Name = "linkAjuda";
            this.Text = "Ajuda";
            this.LinkClicked += new LinkLabelLinkClickedEventHandler(this.ajudaMenuPrincipal_Click);
        }
        private void ajudaMenuPrincipal_Click(object sender, EventArgs e)
        {
            Process processoLink = new Process();
            try
            {
                processoLink.StartInfo.UseShellExecute = true;
                processoLink.StartInfo.FileName = "https://portal.sc.senac.br/";
                processoLink.Start();
            }
            catch (Exception error)
            {
                Console.WriteLine("Erro Link: " + error.Message);
            }
        }
    }
}