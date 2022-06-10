using CalculatorApp.DependencyClasses;
using CalculatorApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorApp.ViewModels
{
   public class MainPageViewModel : BindableObject
    {



        private readonly INavigationService navigate;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigate = navigationService;
        }


        

        public ICommand DIPageCommand => new Command(async () => { await GoToDiPage(); });

        public ICommand CalcualtorPageCommand => new Command(async () => { await GoToNavigatePage(); });

        private async Task GoToNavigatePage()
        {
            // await this.navigate.NavigationAsync(new CalculatorPage());

           await this.navigate.PushAsync<CalculatorPageViewModel>();
        }

        private async Task GoToDiPage()
        {
          await  this.navigate.NavigationAsync(new DIDemoPage());
        }
    }
}
