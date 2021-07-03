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
            this.AutoCompleteMode = AutoCompleteMode.Append;
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
                    this.Location = new Point(600, 345);
                    this.Size = new Size(330, 35);
                    this.Text = "    Pagamento";
                    break;

                case "cbPreco":
                    // cbPreco
                    this.Items.Add("R$ 50,00");
                    this.Items.Add("R$ 100,00");
                    this.Items.Add("R$ 150,00");
                    this.Items.Add("R$ 200,00");
                    this.Items.Add("R$ 250,00");
                    this.Location = new Point(955, 380);
                    this.Size = new Size(170, 20);
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }


    }
}