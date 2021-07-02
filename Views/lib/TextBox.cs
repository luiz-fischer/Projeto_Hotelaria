using System.Drawing;
using System;


namespace Library
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        public TextBox(string caseSwitch)
        {
            this.Font = new Font("Roboto", 20F, GraphicsUnit.Point);
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // this.Name = "guestName";
            this.AutoSize = false;
            this.Size = new Size(330, 35);
            this.ForeColor = ColorTranslator.FromHtml("#8492A6");

            switch (caseSwitch)
            {
                case "txtBxName":
                    this.Location = new Point(550, 50);
                    this.Name = "txtBxName";
                    break;

                case "txtBxBirth":
                    this.Location = new Point(550, 130);
                    this.Name = "txtBxBirth";
                    break;

                case "txtBxIdentification":
                    this.Location = new Point(550, 210);
                    this.Name = "txtBxIdentification";
                    break;

                case "txtBxPayment":
                    this.Location = new Point(550, 290);
                    this.Name = "txtBxPayment";
                    break;

                case "txtBxNameMotherName":
                    this.Location = new Point(550, 370);
                    this.Name = "txtBxNameMotherName";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}