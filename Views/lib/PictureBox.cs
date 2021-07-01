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
                case "imagemSide1":
                    // imagemSide1
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\imagemSide1.jpg");
                    this.Location = new Point(200, 10);
                    this.Size = new Size(300, 121);
                    this.Name = "imagemTitle";
                    break;

                case "imagemSide2": 
                    // imagemSide2
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\imagemSide3.jpg");
                    this.Location = new Point(520, 10);
                    this.Size = new Size(300, 121);
                    this.Name = "imagemLogo";
                    break;

                case "imagemSide3": 
                    // imagemSide3
                    
                    this.Load("C:\\Projeto_Hotelaria\\Views\\Assets\\imagemSide2.jpg");
                    this.Location = new Point(840, 10);
                    this.Size = new Size(300, 121);
                    this.Name = "imagemLogo";
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}