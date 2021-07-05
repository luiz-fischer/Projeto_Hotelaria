using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Model
{
    public class ReportReservation
    {
        public static void ReportReservationPdf()
        {
            var path = Directory.GetCurrentDirectory();
            Document document = new(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Reservas.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new(4);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new("Nome Completo", fonte);
            Paragraph coluna2 = new("CPF", fonte);
            Paragraph coluna3 = new("Data do CheckIn", fonte);
            Paragraph coluna4 = new("Data do CheckOut", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();
            var cell3 = new PdfPCell();
            var cell4 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);
            cell3.AddElement(coluna3);
            cell4.AddElement(coluna4);

            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);

            try
            {

                List<Model.Reservation> reservationList = Controller.Reservation.GetReservations();
                foreach (var reservation in reservationList)
                {   
                    Model.Guest guest = Controller.Guest.GetGuest(reservation.IdGuest);
                    Phrase reservationName = new(guest.GuestName, fonte);
                    var cell = new PdfPCell(reservationName);
                    table.AddCell(cell);

                    Phrase reservationBirth = new(guest.GuestBirth, fonte);
                    cell = new PdfPCell(reservationBirth);
                    table.AddCell(cell);

                    Phrase reservationCheckIn = new(reservation.CheckIn.ToShortDateString(), fonte);
                    cell = new PdfPCell(reservationCheckIn);
                    table.AddCell(cell);

                    Phrase reservationCheckOut = new(reservation.CheckOut.ToShortDateString(), fonte);
                    cell = new PdfPCell(reservationCheckOut);
                    table.AddCell(cell);
                }
                document.Add(table);
                document.Close();
                MessageBox.Show("Documento PDF Gerato em: " + path + "\\Relatorios\\");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());

            }
        }
    }
}