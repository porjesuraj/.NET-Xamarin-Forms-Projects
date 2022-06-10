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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void GoToPage(string uri)
        {

            NavigationWindow window = new NavigationWindow
            {
                Source = new Uri(uri, UriKind.Relative),

                
                ShowsNavigationUI = false
            };
            window.Show();

          
        }


        #region Navigation to pages 
        private void GoToXamlDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("XamlDemo.xaml");

        }

        private void GoToCodeBehindDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("CodeBehindDemo.xaml");
        }

        private void GoToStackpanelDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("StackPanelDemo.xaml");
        }

        private void GoToRoutedEventDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("RoutedEventDemo.xaml");
        }

        private void GridDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("GridDemo.xaml");
        }

        private void GoToGridExerciseDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("GridExercise.xaml");
        }

        private void GoToDependencyPropDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("DependencyPropertiesDemo.xaml");
        }

        private void GoToDataBindingDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("DataBindingDemo.xaml");
        }

        private void GoToINotifyDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("INotifyPCDemo.xaml");
        }

        private void GoToListBoxDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("ListBoxDemo.xaml");
        }

        private void GoToComboBoxDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("ComboBoxDemo.xaml");
        }

        private void GoToCheckBoxDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("CheckBoxDemo.xaml");
        }

        private void GoToRadioButtonDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("RadioButtonAndImagesDemo.xaml");
        }

        private void GoToTriggersDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("EventTriggerDemo.xaml");
        }

        private void GoToPasswordBoxDemo(object sender, RoutedEventArgs e)
        {
            GoToPage("PasswordBoxDemo.xaml");
        }
        #endregion


    }
}
