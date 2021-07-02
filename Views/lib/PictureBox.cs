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
                case "logo_size_full":
                    // logo_size_full
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\menu_side.png");
                    this.Location = new Point(10, 10);
                    this.Size = new Size(200, 800);
                    this.Name = "logo_size_full";
                    break;

                case "logo_image": 
                    // logo_image
                    // this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\logo_image.png");
                    this.Location = new Point(900, 475);
                    this.Size = new Size(350, 350);
                    this.Name = "logo_image";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}