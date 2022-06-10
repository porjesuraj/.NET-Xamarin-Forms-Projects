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
    /// Interaction logic for DependencyPropertiesDemo.xaml
    /// </summary>
    public partial class DependencyPropertiesDemo : Page
    {

        public int MyProperty
        {
            get { return (int)GetValue(dependencyProperty);  }
            set { SetValue(dependencyProperty, value); }
        }

        public static readonly DependencyProperty dependencyProperty = DependencyProperty.Register("MyProperty", typeof(int), typeof(DependencyPropertiesDemo),new PropertyMetadata(0));

        public DependencyPropertiesDemo()
        {
            InitializeComponent();
        }
    }
}
