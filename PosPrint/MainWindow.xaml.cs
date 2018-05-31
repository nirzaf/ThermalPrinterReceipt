using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows;

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
            doc.DefaultPageSettings.PaperSize= paperSize;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            doc.Print(); ;
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {

            var receiptItems = Order.orders;
            const int FIRST_COL_PAD = 20;
            const int SECOND_COL_PAD = 7;
            const int THIRD_COL_PAD = 20;

           
            var sb = new StringBuilder();
            sb.AppendLine("PosPrint Receipt Sample");
            sb.AppendLine("==========================");

            foreach (var item in receiptItems)
            {
                sb.Append(item.ProductName.PadRight(FIRST_COL_PAD));
                sb.AppendLine((item.Quantity.ToString()).PadLeft(SECOND_COL_PAD));
                sb.AppendLine(string.Format("GHC {0:0.00}", item.Price).PadLeft(THIRD_COL_PAD));
            }

            sb.AppendLine("=======================================================================");

           var printText = new PrintText(sb.ToString(), new Font("Monospace Please...", 8));
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 20;

            graphics.DrawString(printText.Text, new Font("Courier New", 8),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
        }



    

    }
}
