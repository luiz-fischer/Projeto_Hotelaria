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
            var path = Directory.GetCurrentDirectory();
            Document document = new(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Hospedes.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new(2);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new("ID Empregado", fonte);
            Paragraph coluna2 = new("Nome Completo", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);

            table.AddCell(cell1);
            table.AddCell(cell2);

            try
            {

                List<Model.Employee> employeeEmployee = Controller.Employee.GetEmployees();
                foreach (var employee in employeeEmployee)
                {
                    Phrase employeeId = new(employee.EmployeeId.ToString(), fonte);
                    var cell = new PdfPCell(employeeId);
                    table.AddCell(cell);

                    Phrase employeeName = new(employee.EmployeeName, fonte);
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