using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        List<Order> cart = new List<Order>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            cart.Add(new Order
            {
                ProductName = txtProduct.Text,
                Quantity = Decimal.Parse(txtQuantity.Text),
                Price= Decimal.Parse(txtPrice.Text),
                ProductDescribtion = txtDescription.Text
            });

           dgCart.ItemsSource = cart;
           dgCart.Items.Refresh();

           var total = cart.Sum(x => x.Amount);
           lbTotal.Content = total;

           txtDescription.Clear();
           txtPrice.Clear();
           txtProduct.Clear();

          //dgCart.DataContext = cart;
            
        }
    }
}
