using DinkToPdf;
using DinkToPdf.Contracts;
namespace BlueStone_Admin.Components.Account
{
   
    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public void GeneratePdf(string htmlContent, string filePath)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4Plus,
            },
                Objects = {
                new ObjectSettings()
                {
                    HtmlContent = htmlContent,
                }
            }
            };

            byte[] pdfBytes = _converter.Convert(doc);
            File.WriteAllBytes(filePath, pdfBytes);
        }
    }
}