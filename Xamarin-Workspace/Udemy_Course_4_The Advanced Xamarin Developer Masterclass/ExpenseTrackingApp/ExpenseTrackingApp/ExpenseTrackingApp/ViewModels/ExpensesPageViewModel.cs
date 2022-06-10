using ExpenseTrackingApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Prism.AppModel;
using ExpenseTrackingApp.Interfaces;
using Xamarin.Forms;

namespace ExpenseTrackingApp.ViewModels
{
    public class ExpensesPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        public ObservableCollection<Expense> Expenses { get; set; } = new ObservableCollection<Expense>();

        public INavigationService navigationservice { get; private set; }


        private Expense selectedExpense;
        public Expense SelectedExpense
        {
            get { return selectedExpense; }
            set { SetProperty(ref selectedExpense, value); }
        }


        public DelegateCommand ItemSelectedCommand { get; private set; }

        public ExpensesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            navigationservice = navigationService;

            ItemSelectedCommand = new DelegateCommand(ListItemSelected); 
        }

        private void ListItemSelected()
        {
            var navparam = new NavigationParameters
            {
                {"expense",SelectedExpense }

            };

            navigationservice.NavigateAsync("ExpenseDetailPage", navparam);
        }

        private async void GetExpenses()
        {
            try
            {
                var exp = await Expense.GetExpenses();

                if (exp != null)
                {
                    Expenses.Clear();
                    foreach (var e in exp)
                    {
                        Expenses.Add(e);
                    }
                }


            }
            catch (NullReferenceException)
            {


            }


        }

        public void AddExpenses()
        {
            navigationservice.NavigateAsync("NewExpensePage");
        }

        public void OnAppearing()
        {
            GetExpenses();
        }

        public void OnDisappearing()
        {

        }


      
    }
}
