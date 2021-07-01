using System;
using System.Drawing;
using System.Windows.Forms;
 
namespace Library
{
    public class ComboBox : System.Windows.Forms.ComboBox
    {

        public ComboBox(string caseSwitch)
        {

            switch (caseSwitch)
            {
                case "cbDiasDevolucao":
                    // cbDiasDevolucao
                    this.Items.Add("1 Dia");
                    this.Items.Add("5 Dias");
                    this.Items.Add("10 Dias");
                    this.Items.Add("15 Dias");
                    this.Items.Add("20 Dias");
                    this.AutoCompleteMode = AutoCompleteMode.Append;
                    this.Location = new Point(955, 300);
                    this.Size = new Size(170, 20);
                    break;

                case "cbPreco":
                    // cbPreco
                    this.Items.Add("R$ 50,00");
                    this.Items.Add("R$ 100,00");
                    this.Items.Add("R$ 150,00");
                    this.Items.Add("R$ 200,00");
                    this.Items.Add("R$ 250,00");
                    this.AutoCompleteMode = AutoCompleteMode.Append;
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