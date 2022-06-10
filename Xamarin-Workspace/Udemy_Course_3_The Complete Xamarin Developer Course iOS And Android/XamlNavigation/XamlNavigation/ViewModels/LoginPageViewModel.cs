using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlNavigation.Models;
using XamlNavigation.Services;

namespace XamlNavigation.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {


        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public DelegateCommand LogInCommand { get;  }

        private INavigationService _navigationService;

        private IPageDialogService _pageDialogService;

        public ISQLService _sqlService { get; private set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ISQLService SQLService) :base(navigationService)
        {
            _navigationService = navigationService;

            _pageDialogService = pageDialogService;
            LogInCommand = new DelegateCommand(ExecuteLogIn);

            _sqlService = SQLService;
        }

        private async void ExecuteLogIn()
        {
            bool isEmailEmpty = string.IsNullOrEmpty(Email);
            bool isPasswordEmpty = string.IsNullOrEmpty(Password);

            if(isEmailEmpty == true || isPasswordEmpty == true)
            {
              await _pageDialogService.DisplayAlertAsync("Warning", "Please Enter Login Details", "OK");
            }else
            {
                var parameter = new NavigationParameters
                {
                    {"email", Email }
                };


              //  SQLiteAsyncConnection conn = App.connect;

              //  await conn.CreateTableAsync<Users>();

               // var user =  await (conn.Table<Users>().Where(u => u.Email == Email ).FirstOrDefaultAsync());
                var user = await Users.GetUser(Email);


 
                if(user != null)
                {
                    if(user.Password == Password)
                    {
                        App.users = user;
                        await _navigationService.NavigateAsync("HomePage", parameter);
                    }else
                    {
                        await _pageDialogService.DisplayAlertAsync("Warning", "Please Enter Correct Password", "OK");

                    }

                }


            }
        }
    }
}
