using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Model
{
    public class ReportEmployee
    {
        public static void ReportEmployeePdf()
        {
            string path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            string localDate = DateTime.Now.ToString();
            string dateConverted = DateTime.Parse(localDate).ToString("dddd_d_MMMM_yyyy, HH;mm;ss");
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Empregados_" + dateConverted + ".pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(2);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            Font fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("ID Empregado", fonte);
            Paragraph coluna2 = new Paragraph("Nome Completo", fonte);

            PdfPCell cell1 = new PdfPCell();
            PdfPCell cell2 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);

            table.AddCell(cell1);
            table.AddCell(cell2);

            try
            {

                List<Employee> employeeEmployee = Controller.Employee.GetEmployees();
                foreach (Employee employee in employeeEmployee)
                {
                    Phrase employeeId = new Phrase(employee.EmployeeId.ToString(), fonte);
                    PdfPCell cell = new PdfPCell(employeeId);
                    table.AddCell(cell);

                    Phrase employeeName = new Phrase(employee.EmployeeName, fonte);
                    cell = new PdfPCell(employeeName);
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
