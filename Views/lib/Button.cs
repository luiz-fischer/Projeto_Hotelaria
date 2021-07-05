using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

namespace Library
{
    public class Button : System.Windows.Forms.Button
    {
        public Button(string caseSwitch)
        {
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 35);
            this.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.FlatStyle = FlatStyle.Flat;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = ColorTranslator.FromHtml("#E5E9F2");
            this.UseVisualStyleBackColor = false;

            switch (caseSwitch)
            {
                case "btnConfirmar":
                    this.BackColor = ColorTranslator.FromHtml("#005E6B");
                    this.Location = new Point(600, 510);
                    this.Name = "btnConfirmar";
                    this.Text = "Confirmar";
                    break;

                case "btnCancelar":
                    this.DialogResult = DialogResult.Cancel;
                    this.BackColor = ColorTranslator.FromHtml("#BA0B0B");
                    this.Location = new Point(780, 510);
                    this.Name = "btnCancelar";
                    this.Text = "Cancelar";
                    break;

                case "btnDeletar":
                    this.Location = new Point(450, 510);
                    this.BackColor = ColorTranslator.FromHtml("#BA0B0B");
                    this.Name = "btnDeletar";
                    this.Text = "Deletar";
                    break;

                case "btnAlterar":
                    this.BackColor = ColorTranslator.FromHtml("#FE4A49");
                    this.Location = new Point(630, 510);
                    this.Name = "btnAlterar";
                    this.Text = "Alterar";
                    break;

                case "btnRelatorio":
                    this.BackColor = ColorTranslator.FromHtml("#503176");
                    this.Location = new Point(420, 510);
                    this.Name = "btnRelatorio";
                    this.Text = "Gerar em PDF";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}