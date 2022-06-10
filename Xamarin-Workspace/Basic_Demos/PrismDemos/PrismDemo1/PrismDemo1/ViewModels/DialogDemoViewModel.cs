using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

using PrismDemo1.Dialogs;
using Prism.Services.Dialogs;
using Prism.Navigation;

namespace PrismDemo1.ViewModels
{
    public class DialogDemoViewModel : BindableBase
    {
        private IDialogService _dialogService { get;  }

        private INavigationService _navigationService;



        private DelegateCommand _dialog;
        public DelegateCommand DialogCommand =>
            _dialog ?? (_dialog = new DelegateCommand(ExecuteDialogCommand, CanExecuteDialogCommand));

        void ExecuteDialogCommand()
        {
            _dialogService.ShowDialog("PopUpDialog", new DialogParameters
            {
                {"message","Welcome to Prism" },
                {"detail","Today we are implementing dialogs " }
            }
               );
        }

        bool CanExecuteDialogCommand()
        {
            return true;
        }


        public DialogDemoViewModel(IDialogService dialogService, INavigationService navigationService)
        {

            _dialogService = dialogService;
            _navigationService = navigationService;
        }



        private DelegateCommand delegateCommand;
        public DelegateCommand GoBackCommand =>
            delegateCommand ?? (delegateCommand = new DelegateCommand(ExecuteGoBackCommand));

       async void ExecuteGoBackCommand()
        {
            await _navigationService.GoBackAsync();

        }










    }
}
