using System;
using System.Windows.Forms;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace Model
{
    public class ReportProduct
    {
        public static void ReportProductPdf()
        {
            var path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            document.SetMargins(3, 2, 3, 2);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Hospedes.pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(3);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            var fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("ID Produto", fonte);
            Paragraph coluna2 = new Paragraph("Nome do Produto", fonte);
            Paragraph coluna3 = new Paragraph("Valor", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();
            var cell3 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);
            cell3.AddElement(coluna3);

            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);

            try
            {

                List<Model.Product> productProduct = Controller.Product.GetProducts();
                foreach (var product in productProduct)
                {
                    Phrase productId = new Phrase(product.ProductId.ToString(), fonte);
                    var cell = new PdfPCell(productId);
                    table.AddCell(cell);

                    Phrase productName = new Phrase(product.ProductName, fonte);
                    cell = new PdfPCell(productName);
                    table.AddCell(cell);

                    Phrase productValue = new Phrase(product.ProductValue.ToString(), fonte);
                    cell = new PdfPCell(productValue);
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
