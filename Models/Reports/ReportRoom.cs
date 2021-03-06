using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Model
{
    public class ReportRoom
    {
        public static void ReportRoomPdf()
        {
            var path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Quartos.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(4);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("Andar", fonte);
            Paragraph coluna2 = new Paragraph("Numero do Quarto", fonte);
            Paragraph coluna3 = new Paragraph("Descrição", fonte);
            Paragraph coluna4 = new Paragraph("Valor do Diaria", fonte);

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

                List<Room> roomList = Controller.Room.GetRooms();
                foreach (var room in roomList)
                {
                    Phrase roomFloor = new Phrase(room.RoomFloor.ToString(), fonte);
                    var cell = new PdfPCell(roomFloor);
                    table.AddCell(cell);

                    Phrase roomNumber = new Phrase(room.RoomNumber, fonte);
                    cell = new PdfPCell(roomNumber);
                    table.AddCell(cell);

                    Phrase roomDescription = new Phrase(room.RoomDescription, fonte);
                    cell = new PdfPCell(roomDescription);
                    table.AddCell(cell);

                    Phrase roomValue = new Phrase(room.RoomValue.ToString("C2"), fonte);
                    cell = new PdfPCell(roomValue);
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
