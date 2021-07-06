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
            string path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            string localDate = DateTime.Now.ToString();
            string dateConverted = DateTime.Parse(localDate).ToString("dddd_d_MMMM_yyyy, HH;mm;ss");
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Limpezas_" + dateConverted + ".pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(5);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            Font fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("Nome Completo", fonte);
            Paragraph coluna2 = new Paragraph("Data Limpeza", fonte);
            Paragraph coluna3 = new Paragraph("Andar", fonte);
            Paragraph coluna4 = new Paragraph("Numero Quarto", fonte);
            Paragraph coluna5 = new Paragraph("Descrição", fonte);

            PdfPCell cell1 = new PdfPCell();
            PdfPCell cell2 = new PdfPCell();
            PdfPCell cell3 = new PdfPCell();
            PdfPCell cell4 = new PdfPCell();
            PdfPCell cell5 = new PdfPCell();

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

                List<Clean> cleanList = Controller.Clean.GetCleans();
                List<Room> roomList = Controller.Room.GetRooms();

                foreach (Clean clean in cleanList)
                {
                    foreach (Room room in roomList)
                    {
                        Employee employee = Controller.Employee.GetEmployee(clean.EmployeeId);
                        Room roomLt = Controller.Room.GetRoom(room.IdRoom);

                        Phrase cleanEmployeeName = new Phrase(employee.EmployeeName, fonte);
                        PdfPCell cell = new PdfPCell(cleanEmployeeName);
                        table.AddCell(cell);

                        Phrase cleanDate = new Phrase(clean.Date.ToShortDateString(), fonte);
                        cell = new PdfPCell(cleanDate);
                        table.AddCell(cell);

                        Phrase cleanFloor = new Phrase(room.RoomFloor.ToString(), fonte);
                        cell = new PdfPCell(cleanFloor);
                        table.AddCell(cell);

                        Phrase cleanRoomNumber = new Phrase(room.RoomNumber.ToString(), fonte);
                        cell = new PdfPCell(cleanRoomNumber);
                        table.AddCell(cell);

                        Phrase cleanRoomDescription = new Phrase(room.RoomDescription, fonte);
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
