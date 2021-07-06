using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class PictureBox : System.Windows.Forms.PictureBox
    {
        public PictureBox(string caseSwitch)
        {
            // this.BorderStyle = BorderStyle.Fixed3D;
            this.ImeMode = ImeMode.NoControl;
            // this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.TabIndex = 41;
            this.TabStop = false;

            switch (caseSwitch)
            {
                case "menu_side":
                    // menu_side
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\menu_side.png");
                    this.Location = new Point(10, 10);
                    this.Size = new Size(200, 660);
                    this.Name = "menu_side";
                    break;

                case "logo_footer_full": 
                    // logo_footer_full
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\logo_footer_full.jpg");
                    this.Location = new Point(550, 625);
                    this.Size = new Size(480, 80);
                    this.Name = "logo_footer_full";
                    break;
                
                case "hotel_front2": 
                    // hotel_front2
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\hotel_front2.jpg");
                    this.Location = new Point(280, 240);
                    this.Size = new Size(500, 340);
                    this.Name = "hotel_front2";
                    break;
                
                case "hotel_wp": 
                    // hotel_wp
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\hotel_wp.jpg");
                    this.Location = new Point(780, 240);
                    this.Size = new Size(500, 340);
                    this.Name = "hotel_wp";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}