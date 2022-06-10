using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismDemo1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        
        private INavigationService _navigation { get; }
        public ICommand PopUpPageCommand { get; private set; }

        public ICommand PostPageCommand { get; private set; }


        private string _labelMessage = "Prism Demo";

        public string LabelMessage
        {
            get => _labelMessage;
            set => SetProperty(ref _labelMessage, value);
        }



        private DelegateCommand _dialogPage;
        public DelegateCommand DialogPageCommand =>
            _dialogPage ?? (_dialogPage = new DelegateCommand(ExecuteDialogPageCommand, CanExecuteDialogPageCommand));

        async void  ExecuteDialogPageCommand()
        {
            await _navigation.NavigateAsync("DialogDemo");
        }

        bool CanExecuteDialogPageCommand()
        {
            return true;
        }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";

            _navigation = navigationService;
           

            PopUpPageCommand = new Command(PopUpPage);

            PostPageCommand = new Command(GetPostPage);
          
        }

        private async void GetPostPage(object obj)
        {
            await _navigation.NavigateAsync("PostPage");
        }

        private async void PopUpPage(object obj)
        {
           await _navigation.NavigateAsync("PopUpDemo");
        }

        private DelegateCommand _restPageCommand;
        public DelegateCommand RestPageCommand =>
            _restPageCommand ?? (_restPageCommand = new DelegateCommand(ExecuteRestPageCommand));

       async void ExecuteRestPageCommand()
        {
            await _navigation.NavigateAsync("RestPage");

        }

    }
}
