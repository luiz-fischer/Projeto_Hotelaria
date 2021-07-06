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
            string path = Directory.GetCurrentDirectory();
            Document document = new Document(PageSize.A4.Rotate());
            string localDate = DateTime.Now.ToString();
            string dateConverted = DateTime.Parse(localDate).ToString("dddd_d_MMMM_yyyy, HH;mm;ss");
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
                path + "\\Relatorios\\Produtos_" + dateConverted + ".pdf", FileMode.Create
            ));
            document.Open();
            PdfPTable table = new PdfPTable(3);

            FontFactory.RegisterDirectory("C:\\Projeto_Hotelaria\\lib\\Fonts");
            Font fonte = FontFactory.GetFont("Roboto", 14);

            Paragraph coluna1 = new Paragraph("ID Produto", fonte);
            Paragraph coluna2 = new Paragraph("Nome do Produto", fonte);
            Paragraph coluna3 = new Paragraph("Valor", fonte);

            PdfPCell cell1 = new PdfPCell();
            PdfPCell cell2 = new PdfPCell();
            PdfPCell cell3 = new PdfPCell();

            cell1.AddElement(coluna1);
            cell2.AddElement(coluna2);
            cell3.AddElement(coluna3);

            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);

            try
            {

                List<Product> productProduct = Controller.Product.GetProducts();
                foreach (Product product in productProduct)
                {
                    Phrase productId = new Phrase(product.ProductId.ToString(), fonte);
                    PdfPCell cell = new PdfPCell(productId);
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
