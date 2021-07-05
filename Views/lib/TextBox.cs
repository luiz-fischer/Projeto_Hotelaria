using System.Drawing;
using System;
using System.Windows.Forms;


namespace Library
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        public TextBox(string caseSwitch)
        { 
            this.Font = new Font("Roboto", 20F, GraphicsUnit.Point);
            this.BorderStyle = BorderStyle.None;
            this.AutoSize = false;
            this.Size = new Size(330, 35);
            this.ForeColor = ColorTranslator.FromHtml("#8492A6");

            switch (caseSwitch)
            {
                case "":
                    break;
                    
                case "txtBxName":
                    this.Location = new Point(600, 150);
                    this.Name = "txtBxName";
                    this.PlaceholderText = "    Nome Completo";
                    break;

                case "txtBxBirth":
                    this.Location = new Point(600, 215);
                    this.Name = "txtBxBirth";
                    this.PlaceholderText = "    Data de Nascimento";
                    break;

                case "txtBxIdentification":
                    this.Location = new Point(600, 280);
                    this.Name = "txtBxIdentification";
                    this.PlaceholderText = "    C.P.F.";
                    break;

                case "txtBxPayment":
                    this.Location = new Point(600, 345);
                    this.Name = "txtBxPayment";
                    this.PlaceholderText = "    Pagamento";
                    break;

                case "txtBxMotherName":
                    this.Location = new Point(600, 410);
                    this.Name = "txtBxMotherName";
                    this.PlaceholderText = "    Nome da Mãe";
                    break;
                
                 case "txtBxValue":
                    this.Location = new Point(600, 215);
                    this.Name = "txtBxValue";
                    this.PlaceholderText = "    Valor do Produto";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}