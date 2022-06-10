using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismDemo1.Dialogs
{
    class PopUpDialogViewModel : BindableBase, IDialogAware
    {

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }



        public DelegateCommand CloseCommand { get; }
       

        public PopUpDialogViewModel()
        {

            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }




        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
          
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           Message =  parameters.GetValue<string>("message");
            Detail = parameters.GetValue<string>("detail");
        }
    }
}
