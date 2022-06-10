using CalculatorApp.DependencyClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorApp.ViewModels
{
   public class DIDemoPageViewModel : BindableObject
    {

        private readonly IDialogMessage dialogMessage;

        public DIDemoPageViewModel(IDialogMessage dialogMessage)
        {
            this.dialogMessage = dialogMessage;
        }

        public ICommand DisplayAlertCommand => new Command(async () => { await ShowAlert(); });


        private async Task ShowAlert()
        {
           await dialogMessage.DisplayAlert("Hello", "Have a Great Day", "OK");
        }
    }
}
