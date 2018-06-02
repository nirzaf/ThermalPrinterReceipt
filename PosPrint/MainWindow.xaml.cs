using System;
using System.Collections.Generic;
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

            var cart = Order.orders;


       
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8);
            //Draw Boundry
            Rectangle bounds= new Rectangle();
            bounds.X = 10;
            bounds.Y = 10;
            bounds.Offset(10, 10);

            DrawReciept(cart, graphics, font, bounds);
        }


        void DrawReciept(List<Order> cart, Graphics g, Font font, Rectangle bounds)
        {
            foreach (var item in cart)
            {
                LineDisplay display = new LineDisplay(g, font, bounds);
                display.WriteTwoColumnLine("User Name:", item.ProductName);
                display.WriteTwoColumnLine("Full Name:", item.ProductDescribtion);
                display.WriteTwoColumnLine("E-mail:", item.Quantity.ToString());
                display.WriteTwoColumnLine("Phone:", item.Price.ToString());
                display.WriteTwoColumnLine("Phone:", item.Amount.ToString());
            }
        }

    }
}
