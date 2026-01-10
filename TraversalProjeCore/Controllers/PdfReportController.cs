using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");

            using (var stream = new FileStream(path, FileMode.Create)) 
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, stream);

                document.Open();

                Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

                document.Add(paragraph);
                document.Close();
            } // <<<< Dosya kilidi serbest bırakıldı.

            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf"); //dosya yolu belirlendi
                                                                                                               
            using (var stream = new FileStream(path, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, stream);

                document.Open();

                PdfPTable pdfPTable = new PdfPTable(3);
                pdfPTable.AddCell("Misafir Adı");
                pdfPTable.AddCell("Misafir Soyadı");
                pdfPTable.AddCell("Misafir TC");

                pdfPTable.AddCell("Eylül");
                pdfPTable.AddCell("Yücedağ");
                pdfPTable.AddCell("12345678901011");

                pdfPTable.AddCell("Kemal");
                pdfPTable.AddCell("Yıldırım");
                pdfPTable.AddCell("12345678901012");

                pdfPTable.AddCell("Mehmet");
                pdfPTable.AddCell("Arslan");
                pdfPTable.AddCell("12345678901013");

                document.Add(pdfPTable);
                document.Close(); // document.Close() çağrıldıktan hemen sonra using bloğu stream'i serbest bırakır.
            } // <<<<<< Bu noktada dosya kilidi serbest bırakıldı.

            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
