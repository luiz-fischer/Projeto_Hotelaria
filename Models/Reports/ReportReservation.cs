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
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Reservas.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(4);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("Nome Completo", fonte);
            Paragraph coluna2 = new Paragraph("CPF", fonte);
            Paragraph coluna3 = new Paragraph("Data do CheckIn", fonte);
            Paragraph coluna4 = new Paragraph("Data do CheckOut", fonte);

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

                List<Reservation> reservationList = Controller.Reservation.GetReservations();
                foreach (var reservation in reservationList)
                {   
                    Guest guest = Controller.Guest.GetGuest(reservation.IdGuest);
                    Phrase reservationName = new Phrase(guest.GuestName, fonte);
                    var cell = new PdfPCell(reservationName);
                    table.AddCell(cell);

                    Phrase reservationBirth = new Phrase(guest.GuestBirth, fonte);
                    cell = new PdfPCell(reservationBirth);
                    table.AddCell(cell);

                    Phrase reservationCheckIn = new Phrase(reservation.CheckIn.ToShortDateString(), fonte);
                    cell = new PdfPCell(reservationCheckIn);
                    table.AddCell(cell);

                    Phrase reservationCheckOut = new Phrase(reservation.CheckOut.ToShortDateString(), fonte);
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
