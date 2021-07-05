using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace Model
{
    public class ReportGuest
    {
        public static void ReportGuestPdf()
        {
            var path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Hospedes.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(5);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("Nome Completo", fonte);
            Paragraph coluna2 = new Paragraph("Data Nascimento", fonte);
            Paragraph coluna3 = new Paragraph("CPF", fonte);
            Paragraph coluna4 = new Paragraph("Método Pagamento", fonte);
            Paragraph coluna5 = new Paragraph("Nome Mãe", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();
            var cell3 = new PdfPCell();
            var cell4 = new PdfPCell();
            var cell5 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);
            cell3.AddElement(coluna3);
            cell4.AddElement(coluna4);
            cell5.AddElement(coluna5);

            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);

            try
            {

                List<Model.Guest> guestList = Controller.Guest.GetGuests();
                foreach (var guest in guestList)
                {
                    Phrase guestName = new Phrase(guest.GuestName, fonte);
                    var cell = new PdfPCell(guestName);
                    table.AddCell(cell);

                    Phrase guestBirth = new Phrase(guest.GuestBirth, fonte);
                    cell = new PdfPCell(guestBirth);
                    table.AddCell(cell);

                    Phrase guestIdentification = new Phrase(guest.GuestIdentification, fonte);
                    cell = new PdfPCell(guestIdentification);
                    table.AddCell(cell);

                    // var ConvertPayment = Convert.ToSingle(guest.Payment).ToString();
                    Phrase guestPayment = new Phrase(guest.Payment.ToString(), fonte);
                    cell = new PdfPCell(guestPayment);
                    table.AddCell(cell);

                    Phrase motherName = new Phrase(guest.GuestIdentification, fonte);
                    cell = new PdfPCell(motherName);
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
