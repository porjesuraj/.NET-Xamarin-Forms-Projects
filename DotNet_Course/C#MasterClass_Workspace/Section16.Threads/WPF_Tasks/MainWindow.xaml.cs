using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WPF_Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html", typeof(string), typeof(MainWindow), new FrameworkPropertyMetadata(OnHtmlChanged));
        

        public MainWindow()
        {
            InitializeComponent();

        }

        private void TaskButton_Clicked(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"THread Number {Thread.CurrentThread.ManagedThreadId}");


                HttpClient webClient = new HttpClient();

                string html = webClient.GetStringAsync("https://google.com").Result;
                // string html2 = webClient.GetStringAsync("https://ipv4.download.thinkbroadband.com/5MB.zip").Result;

                // go to main thread for UI operation
                myButton.Dispatcher.Invoke(() =>
                {
                    myButton.Content = "Done";
                    Debug.WriteLine($"THread Number {Thread.CurrentThread.ManagedThreadId} owns myButton");

                    // downloadedTextBox.Text = html;


                });

            });
          
           // MessageBox.Show("Hi World");


        }

        private async void TaskButton_Clicked2(object sender, RoutedEventArgs e)
        {
            string myHtml = "Blank";
            Debug.WriteLine($"Thread Number {Thread.CurrentThread.ManagedThreadId} before awaiting task ");

           await Task.Run(async () =>
            {


                HttpClient webClient = new HttpClient();

                string html = webClient.GetStringAsync("https://google.com").Result;
                myHtml = html;
                Debug.WriteLine($"Thread Number {Thread.CurrentThread.ManagedThreadId} while awaiting task");


            });

            // go to main thread for UI operation
            myButton.Content = "Done";
            Debug.WriteLine($"Thread Number {Thread.CurrentThread.ManagedThreadId} after await task");

            myWebBrowser.SetValue(HtmlProperty,myHtml);
           


        }


        static void OnHtmlChanged(DependencyObject dependencyObject,DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
                webBrowser.NavigateToString(e.NewValue as string);
        }
    }

}

