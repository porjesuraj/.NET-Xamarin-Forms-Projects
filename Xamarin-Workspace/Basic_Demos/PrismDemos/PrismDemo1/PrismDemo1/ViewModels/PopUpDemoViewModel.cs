using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismDemo1.ViewModels
{
   public class PopUpDemoViewModel : ViewModelBase

    { 
     private IPageDialogService _dialogService { get; }

    public ICommand AlertUserCommand { get; private set; }


    public ICommand DisplayAlertCommand { get; private set; }

    public ICommand DisplayActionSheetCommand { get; private set; }

    public ICommand DisplayActionButtonsCommand { get; private set; }



    private string _labelMessage = "Coming Soon";

    public string LabelMessage
    {
        get => _labelMessage;
        set => SetProperty(ref _labelMessage, value);
    }







    public PopUpDemoViewModel(INavigationService navigationService, IPageDialogService dialogService)
        : base(navigationService)
    {
        Title = "Main Page";
        _dialogService = dialogService;

        AlertUserCommand = new DelegateCommand(AlertUser);

        DisplayAlertCommand = new Command(DisplayAlert);

        DisplayActionSheetCommand = new Command(DisplayActionSheet);


        DisplayActionButtonsCommand = new Command(DisplayActionButtons);

    }

    private async void DisplayActionButtons(object obj)
    {
        var buttons = new IActionSheetButton[]
        {
                ActionSheetButton.CreateButton("Option1",WriteLine,"Option 1"),
                ActionSheetButton.CreateButton("Option3",WriteLine,"Option 2"),
                ActionSheetButton.CreateButton("Cancel",WriteLine,"Cancel"),
                ActionSheetButton.CreateButton("Destroy",WriteLine,"Destroy"),

        };

        await _dialogService.DisplayActionSheetAsync("ActionSheetbuttons", buttons);
    }

    private void WriteLine(string message)
    {
        Trace.WriteLine(message);
    }

    private async void DisplayActionSheet(object obj)
    {
        var result = await _dialogService.DisplayActionSheetAsync("Actions", "Cancel", "Destroy", "Option1", "Option2");


        Trace.WriteLine(result);
    }

    private async void DisplayAlert(object obj)
    {
        await _dialogService.DisplayAlertAsync("Alert", "Working on prism", "Accept");


    }

    private async void AlertUser()
    {

        var result = await _dialogService.DisplayAlertAsync("Alert", "Working on prism", "Accept", "Cancel");

        Trace.WriteLine(result);

    }

}
}
