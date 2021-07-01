using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class PictureBox : System.Windows.Forms.PictureBox
    {
        public PictureBox(string caseSwitch)
        {
            this.BorderStyle = BorderStyle.Fixed3D;
            this.ImeMode = ImeMode.NoControl;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.TabIndex = 41;
            this.TabStop = false;

            switch (caseSwitch)
            {
                case "imagemTitle":
                    // ImagemTitle
                    // this.Load("C:\\LocaCar\\Imagens\\imagemTitle.jpg");
                    this.Location = new Point(230, 10);
                    this.Size = new Size(900, 102);
                    this.Name = "imagemTitle";
                    break;

                case "imagemLogo": 
                    // ImagemLogo
                    // this.Load("C:\\LocaCar\\Imagens\\imagemLogo.jpg");
                    this.Location = new Point(12, 550);
                    this.Size = new Size(130, 120);
                    this.Name = "imagemLogo";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}