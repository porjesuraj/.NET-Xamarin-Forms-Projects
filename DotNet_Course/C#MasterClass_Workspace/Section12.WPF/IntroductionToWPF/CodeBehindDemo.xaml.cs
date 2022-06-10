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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CodeBehindDemo : Page
    {
        public CodeBehindDemo()
        {
            InitializeComponent();

            Grid grid = new Grid();
            this.Content = grid;

            Button btn1 = new Button();
            btn1.FontSize = 26;
            btn1.Width = 300;
            btn1.Height = 150;
            WrapPanel wrapPanel = new WrapPanel();
            TextBlock txt = new TextBlock();
            txt.Text = "Multi";
            txt.Foreground = Brushes.DodgerBlue;

            wrapPanel.Children.Add(txt);
            txt = new TextBlock();
            txt.Text = "Color";
            txt.Foreground = Brushes.Red;

            wrapPanel.Children.Add(txt);

            txt = new TextBlock();
            txt.Text = "Button";
            txt.Foreground = Brushes.Orange;

            wrapPanel.Children.Add(txt);

            btn1.Content = wrapPanel;

            grid.Children.Add(btn1);




        }
    }
}
