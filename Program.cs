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
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfCopy copy = new iTextSharp.text.pdf.PdfCopy(document, new System.IO.FileStream(outFile, System.IO.FileMode.Create));
            if (copy != null)
            {
                document.Open();
                foreach (string str in args)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(str);
                        reader.ConsolidateNamedDestinations();
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            iTextSharp.text.pdf.PdfImportedPage importedPage = copy.GetImportedPage(reader, i);
                            copy.AddPage(importedPage);
                        }
                        reader.Close();
                    }
                    catch
                    {
                    }
                }
                copy.Close();
                document.Close();
            }
        }
    }
}
