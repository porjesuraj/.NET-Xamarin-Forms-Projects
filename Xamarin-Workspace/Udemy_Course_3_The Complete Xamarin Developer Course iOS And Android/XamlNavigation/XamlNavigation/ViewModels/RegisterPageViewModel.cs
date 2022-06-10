using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using XamlNavigation.Models;
using XamlNavigation.Services;

namespace XamlNavigation.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        private IPageDialogService _pageDialogService;
        private INavigationService _navigationService;

        public ISQLService _sqlService { get; private set; }
        public RegisterPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, ISQLService SQLService)
        {
            _pageDialogService = pageDialogService;
          

            _navigationService = navigationService;
            _sqlService = SQLService;
        }

        private string email;

        public string Email { get => email; set => SetProperty(ref email, value); }

        private string confirmPassword;

        public string ConfirmPassword { get => confirmPassword; set => SetProperty(ref confirmPassword, value); }

        private string password;

        public string Password { get => password; set => SetProperty(ref password, value); }

        private ICommand registerCommand;

        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new DelegateCommand(Register);
                }

                return registerCommand;
            }
        }

        private async void Register()
        {
            if(Password == ConfirmPassword && Email != string.Empty )
            {
                Users user = new Users
                {
                    Email = Email,
                    Password = ConfirmPassword
                    
                };

            
               await Users.Insert(user);

                App.users = user;

                
                await  _pageDialogService.DisplayAlertAsync("SUCCESS", $"Welcome {Email}", "OK");

            }
            else
            {
              await  _pageDialogService.DisplayAlertAsync("Error", "Password don't match", "OK");
            }
        }

       
    }
}
