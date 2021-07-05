using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Model
{
    public class ReportClean
    {
        public static void ReportCleanPdf()
        {
            var path = Directory.GetCurrentDirectory();
            Document document = new(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Limpezas.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new(5);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new("Nome Completo", fonte);
            Paragraph coluna2 = new("Data Limpeza", fonte);
            Paragraph coluna3 = new("Andar", fonte);
            Paragraph coluna4 = new("Numero Quarto", fonte);
            Paragraph coluna5 = new("Descrição", fonte);

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

                List<Model.Clean> cleanList = Controller.Clean.GetCleans();
                List<Model.Room> roomList = Controller.Room.GetRooms();

                foreach (var clean in cleanList)
                {
                    foreach (var room in roomList)
                    {
                        Model.Employee employee = Controller.Employee.GetEmployee(clean.EmployeeId);
                        Model.Room roomLt = Controller.Room.GetRoom(room.IdRoom);

                        Phrase cleanEmployeeName = new(employee.EmployeeName, fonte);
                        var cell = new PdfPCell(cleanEmployeeName);
                        table.AddCell(cell);

                        Phrase cleanDate = new(clean.Date.ToShortDateString(), fonte);
                        cell = new PdfPCell(cleanDate);
                        table.AddCell(cell);

                        Phrase cleanFloor = new(room.RoomFloor.ToString(), fonte);
                        cell = new PdfPCell(cleanFloor);
                        table.AddCell(cell);

                        Phrase cleanRoomNumber = new(room.RoomNumber.ToString(), fonte);
                        cell = new PdfPCell(cleanRoomNumber);
                        table.AddCell(cell);

                        Phrase cleanRoomDescription = new(room.RoomDescription, fonte);
                        cell = new PdfPCell(cleanRoomDescription);
                        table.AddCell(cell);

                    }

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
