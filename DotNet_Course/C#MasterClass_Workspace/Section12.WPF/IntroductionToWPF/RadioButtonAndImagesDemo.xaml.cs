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
    /// Interaction logic for RadioButtonAndImagesDemo.xaml
    /// </summary>
    public partial class RadioButtonAndImagesDemo : Page
    {
        public RadioButtonAndImagesDemo()
        {
            InitializeComponent();
        }

        private void Maybe_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" maybe is Selected");
        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" No is Selected");

        }

        private void Yes_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Yes is Selected");

        }
    }
}
