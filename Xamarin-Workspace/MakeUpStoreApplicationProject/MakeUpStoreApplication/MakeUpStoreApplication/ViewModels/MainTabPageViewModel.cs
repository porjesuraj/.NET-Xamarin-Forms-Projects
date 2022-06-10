using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.SQLiteDataBase;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MakeUpStoreApplication.ViewModels
{
    public class MainTabPageViewModel : ViewModelBase, IPageLifecycleAware
    {

        private int cartnumber;
        public int CartNumber
        {
            get { return cartnumber; }
            set { SetProperty(ref cartnumber, value); }
        }

        public ICommand GotoCartCommand { get; set; }

        private readonly INavigationService navigationService1;
        private readonly IRepository<MakeUpProduct> repository;
        public MainTabPageViewModel(INavigationService navigationService, IRepository<MakeUpProduct> repository1) : base(navigationService)
        {
            navigationService1 = navigationService;

            repository = repository1;
            GotoCartCommand = new DelegateCommand(async () => await GoToCartPage());
        }



        private async Task GoToCartPage()
        {

            await navigationService1.NavigateAsync("CartPage");
        }

        public async void OnAppearing()
        {
           int cart =   await repository.GetCountAsync();
            CartNumber = cart; 
        }

        public void OnDisappearing()
        {
            // Method intentionally left empty.
        }
    }

}