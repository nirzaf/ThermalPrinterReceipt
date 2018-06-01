using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PosPrint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Order.orders.Add(new Order
            {
                ProductName = txtProduct.Text,
                Quantity = Decimal.Parse(txtQuantity.Text),
                Price = Decimal.Parse(txtPrice.Text),
                ProductDescribtion = txtDescription.Text
            });

            dgCart.ItemsSource = Order.orders;
            dgCart.Items.Refresh();

            var total = Order.orders.Sum(x => x.Amount);
            lbTotal.Content = total;

            txtDescription.Clear();
            txtPrice.Clear();
            txtProduct.Clear();

            //dgCart.DataContext = cart;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Print();
        }


        public void Print()
        {
            var doc = new PrintDocument();
            var paperSize = new PaperSize("Custom", 520, 820);
            doc.DefaultPageSettings.PaperSize = paperSize;
            //doc.DefaultPageSettings.PaperSize.Kind = PaperKind.Custom;
            //doc.DefaultPageSettings.PaperSize.Height = 820;
            //doc.DefaultPageSettings.PaperSize.Width = 520;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            //var pd = new PrintDialog();
            //pd.ShowDialog();
            doc.Print(); 
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {

            decimal total = decimal.Parse(lbTotal.Content.ToString());
            var receiptItems = Order.orders;
            const int FIRST_COL_PAD = 5;
            const int SECOND_COL_PAD = 7;
            const int THIRD_COL_PAD = 8;


            var sb = new StringBuilder();
            //replace with item.Branch
            sb.AppendLine(("BARCELOS JUNCTION MA"));
            sb.AppendLine(" ");
            sb.AppendLine(("TAX INVOICE:  "));
            sb.AppendLine(" ");
            sb.AppendLine(("ACCRA GHANA").PadLeft(20));
            sb.AppendLine(("Vat Reg. No.:  "));
            sb.AppendLine(("TEL: 0204355610 & 0204355608 "));
            sb.AppendLine(" ");
            sb.Append(("DATE").PadRight(8));
            sb.AppendLine(": "+DateTime.Now);
            sb.Append(("CASHIER").PadRight(8));
            sb.AppendLine((": "));
            sb.AppendLine(" ");
            //sb.AppendLine("=".PadRight(35,'='));
            sb.Append(("ITEM").PadLeft(13));
            sb.Append(("QTY").PadLeft(FIRST_COL_PAD));
            sb.Append(("PRICE").PadLeft(SECOND_COL_PAD));
            sb.AppendLine(("GH₵").PadLeft(THIRD_COL_PAD));
            sb.AppendLine("-".PadRight(60, '-'));
           

            foreach (var item in receiptItems)
            {
               
                string pd = "";
                if (item.ProductName.Length > 15)
                {
                  
                    pd = item.ProductName.Substring(0, 15);

                    
                }
                else
                {
                   
                    pd = item.ProductName;
                }
                sb.Append(pd.PadLeft(13));
                sb.Append(item.Quantity.ToString().PadLeft(FIRST_COL_PAD));
                sb.Append((item.Price).ToString("F",CultureInfo.InvariantCulture).PadLeft(SECOND_COL_PAD));
                sb.AppendLine((string.Format("{0:0.00}", item.Amount)).ToString().PadLeft(THIRD_COL_PAD));
            }
            sb.AppendLine("-".PadRight(60, '-'));
            sb.Append("Sub Total:".PadLeft(13+FIRST_COL_PAD+ SECOND_COL_PAD));
            sb.AppendLine(string.Format("{0:0.00}",total));
            sb.AppendLine("VAT @ 17.50%: ".PadLeft(13+FIRST_COL_PAD + SECOND_COL_PAD));
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine("Bill Total:".PadLeft(15+FIRST_COL_PAD + SECOND_COL_PAD));

            sb.AppendLine("=".PadRight(50, '='));


            var printText = new PrintText(sb.ToString(), new Font(System.Drawing.FontFamily.GenericMonospace, 9,System.Drawing.FontStyle.Bold));
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 20;

            graphics.DrawString(printText.Text, new Font(System.Drawing.FontFamily.GenericMonospace, 9, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
        }

       
        

    }
}
