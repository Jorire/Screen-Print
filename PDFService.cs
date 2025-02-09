using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Screen_Print {
    internal class PDFService {
        private PDFService() {
        }
        internal static void AddImageToPdfDocument(PdfDocument document, string imageFileName) {
            PdfPage page = document.AddPage();
            using (XImage img = XImage.FromFile(imageFileName)) {                
                page.Width = XUnit.FromPoint(img.PointWidth);
                page.Height = XUnit.FromPoint(img.PointHeight);

                XGraphics gfx = XGraphics.FromPdfPage(page);
                gfx.DrawImage(img, 0, 0, page.Width.Point, page.Height.Point);
            }
        }
    }
}
