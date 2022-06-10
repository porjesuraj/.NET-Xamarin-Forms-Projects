using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp.DependencyClasses
{
    public class DialogMessage : IDialogMessage
    {
        public Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons)
        {
            return Application.Current.MainPage.DisplayActionSheet(title, "Cancel", destruction, buttons);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {

            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public Task<string> DisplayPrompt(string title, string message)
        {
            return Application.Current.MainPage.DisplayPromptAsync(title, message);
        }
    }
}
