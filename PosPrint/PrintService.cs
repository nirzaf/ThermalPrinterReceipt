using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Controls;

namespace PosPrint
{

 
    public class PrintService
    {
        public void TestPrint()
        {
            PrintDialog printDlg = new PrintDialog();
UserControl uc = new UserControl();
printDlg.PrintVisual(uc, "User Control Printing."); 
        }

        //PrintDocument pdoc;
        //public void print( PrintPageEventHandler args)
        //{
        //    PrintDialog pd = new PrintDialog();
        //    pdoc = new PrintDocument();
        //    PrinterSettings ps = new PrinterSettings();
        //    Font font = new Font("Courier New", 15);

        //    PaperSize psize = new PaperSize("Custom", 100, 200);
        //    pd. = pdoc;
        //    pd.Document.DefaultPageSettings.PaperSize = psize;
        //    pdoc.DefaultPageSettings.PaperSize.Height = 820;

        //    pdoc.DefaultPageSettings.PaperSize.Width = 520;

        //    pdoc.PrintPage += new PrintPageEventHandler(args);

        //    //DialogResult result = pd.ShowDialog();
        //    //if (result == DialogResult.Cancel)
        //    //{
        //    PrintPreviewDialog pp = new PrintPreviewDialog();
        //    pp.Document = pdoc;
        //    pdoc.Print();
        //    //}

        //}


    }
}
