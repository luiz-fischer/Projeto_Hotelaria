using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class ComboBox : System.Windows.Forms.ComboBox
    {

        public ComboBox(string caseSwitch)
        {
            this.Font = new Font("Roboto", 20F, GraphicsUnit.Point);
            this.ForeColor = ColorTranslator.FromHtml("#8492A6");

            switch (caseSwitch)
            {
                case "cbPayment":
                    // cbPayment
                    this.Items.Add("Em dinheiro");
                    this.Items.Add("Débito");
                    this.Items.Add("Crédito - 1x");
                    this.Items.Add("Crédito - 2x");
                    this.Items.Add("Crédito - 3x");
                    this.AutoCompleteMode = AutoCompleteMode.Append;
                    this.Location = new Point(600, 345);
                    this.Size = new Size(330, 35);
                    this.Text = "    Pagamento";
                    break;

                case "cbRoomFloor":
                    // cbPreco
                    this.Items.Add("1º Andar");
                    this.Items.Add("2º Andar");
                    this.Items.Add("3º Andar");
                    this.Items.Add("4º Andar");
                    this.Items.Add("5º Andar");
                    this.AutoCompleteMode = AutoCompleteMode.Append;
                    this.Location = new Point(600, 150);
                    this.Size = new Size(330, 35);
                    this.Text = "    Numero do Andar";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }


    }
}