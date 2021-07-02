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
                    this.Location = new Point(550, 430);
                    this.Name = "btnConfirmar";
                    this.UseVisualStyleBackColor = false;
                    this.Text = "Confirmar";
                    break;

                case "btnCancelar":
                    this.DialogResult = DialogResult.Cancel;
                    this.BackColor = ColorTranslator.FromHtml("#BA0B0B");
                    this.Location = new Point(730, 430);
                    this.Name = "btnCancelar";
                    this.Text = "Cancelar";
                    break;

                case "btnDeletar":
                    this.Location = new Point(1100, 635);
                    this.Name = "btnDeletar";
                    this.Text = "Deletar";
                    break;

                case "btnAlterar":
                    this.Location = new Point(1000, 635);
                    this.Name = "btnAlterar";
                    this.Text = "Alterar";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}