using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDeepLinkApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ICommand GoToNewsAppCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GoToNewsAppCommand = new Command(GoToNewsApp);
        }

        [Obsolete]
        private void GoToNewsApp(object obj)
        {
            Device.OpenUri(new Uri("https://xamboy.com/hello/Suraj"));
        }
    }
}
