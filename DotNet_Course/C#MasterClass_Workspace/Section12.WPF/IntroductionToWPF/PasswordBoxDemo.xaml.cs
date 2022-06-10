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
    /// Interaction logic for PasswordBoxDemo.xaml
    /// </summary>
    public partial class PasswordBoxDemo : Page
    {
        public PasswordBoxDemo()
        {
            InitializeComponent();
        }

        private void LogInButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome "  +tbUserName.Text);

        }
    }
}
