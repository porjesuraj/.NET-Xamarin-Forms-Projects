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
    public partial class InfoPage : TabbedPage
    {
        public InfoPage(InfoPageViewModel viewModel,HistoryPage historyPage,AppInformationPage appInformationPage)
        {
            InitializeComponent();


            BindingContext = viewModel;

            historyPage.BindingContext = viewModel.HistoryVM;
            historyPage.IconImageSource = "history.png";

            appInformationPage.IconImageSource = "info.png";
            Children.Add(historyPage);

            Children.Add(appInformationPage);
        }
    }
}