using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMExercise.ViewModels
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task PopAsync()
        {
            await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
