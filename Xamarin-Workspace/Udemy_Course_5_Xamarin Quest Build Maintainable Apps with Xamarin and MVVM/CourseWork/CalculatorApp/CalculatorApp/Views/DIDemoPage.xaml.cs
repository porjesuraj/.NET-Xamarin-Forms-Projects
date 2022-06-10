using CalculatorApp.DependencyClasses;
using CalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DIDemoPage : ContentPage
    {
        public DIDemoPage()
        {
         BindingContext = new DIDemoPageViewModel(new DialogMessage());

           
            InitializeComponent();
        }
    }
}