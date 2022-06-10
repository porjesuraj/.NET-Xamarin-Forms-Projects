using System;
using System.Collections.Generic;
using System.ComponentModel;
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

   public class Sum : INotifyPropertyChanged
    {
        private string num1;

        public string Num1
        {
            get { return num1; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num1 = value;
                OnPropertyChanged("Num1");
                OnPropertyChanged("Result");
            }
        }

        private string num2;

        public string Num2
        {
            get { return num2; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num2 = value;
                OnPropertyChanged("Num2");
                OnPropertyChanged("Result");
            }
        }

        private string result;

        public string Result
        {
            get {
                int res = int.Parse(Num1) + int.Parse(Num2);

                return res.ToString();
            }
            set {
                int res = int.Parse(Num1) + int.Parse(Num2);

               result = res.ToString();
                OnPropertyChanged("Result");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    /// <summary>
    /// Interaction logic for INotifyPCDemo.xaml
    /// </summary>
    public partial class INotifyPCDemo : Page
    {

        public Sum SumObj { get; set; }

        public INotifyPCDemo()
        {
            InitializeComponent();

            SumObj = new Sum { Num1 = "1", Num2 = "2", Result = "3" };

            this.DataContext = SumObj;
        }
    }
}
