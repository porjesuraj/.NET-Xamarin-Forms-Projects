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
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            //  BindingContext = new MainPageViewModel(new NavigationService());

            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}