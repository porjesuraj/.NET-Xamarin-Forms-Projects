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

namespace IntroductionToWPF
{
    /// <summary>
    /// Interaction logic for CheckBoxDemo.xaml
    /// </summary>
    public partial class CheckBoxDemo : Page
    {
        public CheckBoxDemo()
        {
            InitializeComponent();
        }

        private void cbAllToppingsCheckChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbAllToppings.IsChecked == true);
            cbSalami.IsChecked = newVal;
            cbMushroom.IsChecked = newVal;
            cbOnion.IsChecked = newVal;
        }

        private void cbSingleCheckChanged(object sender, RoutedEventArgs e)
        {
            cbAllToppings.IsChecked = null;
            if((cbSalami.IsChecked == true) && (cbMushroom.IsChecked == true) && (cbOnion.IsChecked == true))
            {
                cbAllToppings.IsChecked = true;

            }
            else if ((cbSalami.IsChecked == false) && (cbMushroom.IsChecked == false) && (cbOnion.IsChecked == false))
            {
                cbAllToppings.IsChecked = false;

            }
        }
    }
}
