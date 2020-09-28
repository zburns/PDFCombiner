using System;
using System.Collections.Generic;
using System.Text;

namespace PDFCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null)
            {
                if (args.Length > 0)
                {
                    CombineMultiplePDFs(args, "Combined.pdf");
                }
            }
        }

        private static void CombineMultiplePDFs(string[] args, string outFile)
        {
            PdfSharp.Pdf.PdfDocument pdfdocument = new PdfSharp.Pdf.PdfDocument();
            foreach (string str in args)
            { 
                PdfSharp.Pdf.PdfDocument inputDocument = PdfSharp.Pdf.IO.PdfReader.Open(str, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfSharp.Pdf.PdfPage page = inputDocument.Pages[idx];
                    pdfdocument.AddPage(page);
                }
            }
            pdfdocument.Save(outFile);
        }
    }
}
