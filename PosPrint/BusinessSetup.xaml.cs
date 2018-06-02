using PosPrint.Model;
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
using System.Windows.Shapes;

namespace PosPrint
{
    /// <summary>
    /// Interaction logic for BusinessSetup.xaml
    /// </summary>
    public partial class BusinessSetup : Window
    {
        public BusinessSetup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Business.Businesses.Add(new Business
            {
                BusinessName = txtBUsinessName.Text,
                Branch = txtBranch.Text,
                Location= txtLocation.Text,
                Phone = txtPhone.Text
            
            });
            MessageBox.Show("Business Setup Successfully");
            this.Hide();
            var main = new MainWindow();
            main.Show();
        }
    }
}
