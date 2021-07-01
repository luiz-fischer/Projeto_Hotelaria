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
            this.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FlatAppearance.BorderSize = 3;
            this.ImeMode = ImeMode.NoControl;
            this.Size = new System.Drawing.Size(90, 33);
            this.TabIndex = 39;
            this.UseVisualStyleBackColor = true;
            this.FlatStyle = FlatStyle.System;
            this.UseVisualStyleBackColor = true;
            this.Size = new System.Drawing.Size(90, 33);


            switch (caseSwitch)
            {
                case "btnConfirmar":
                    this.Location = new System.Drawing.Point(1100, 635);
                    this.Name = "btnConfirmar";
                    this.Text = "Confirmar";
                    break;

                case "btnCancelar":
                    this.DialogResult = DialogResult.Cancel;
                    this.Location = new System.Drawing.Point(1195, 635);
                    this.Name = "btnCancelar";
                    this.Text = "Cancelar";
                    break;
                case "btnDeletar":
                    this.Location = new System.Drawing.Point(1100, 635);
                    this.Name = "btnDeletar";
                    this.Text = "Deletar";
                    break;
                case "btnAlterar":
                    this.Location = new System.Drawing.Point(1000, 635);
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