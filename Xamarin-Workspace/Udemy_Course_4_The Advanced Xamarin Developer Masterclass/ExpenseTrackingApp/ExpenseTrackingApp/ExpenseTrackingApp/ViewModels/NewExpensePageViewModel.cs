using ExpenseTrackingApp.Models;
using ExpenseTrackingApp.Resources;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ExpenseTrackingApp.ViewModels
{
    public class NewExpensePageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set { SetProperty(ref expenseName, value); }
        }


        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set { SetProperty(ref expenseDescription, value); }
        }


        private float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set { SetProperty(ref expenseAmount, value); }
        }


        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set { SetProperty(ref expenseCategory, value); }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set { SetProperty(ref expenseDate, value); }
        }


        private DelegateCommand saveExpense;
        public DelegateCommand SaveExpense =>
            saveExpense ?? (saveExpense = new DelegateCommand(InsertExpense));

        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<ExpenseStatus> ExpenseStatuseCollection { get; set; } = new ObservableCollection<ExpenseStatus>();


        public INavigationService navigationservice { get; set; }

        public IPageDialogService pageDialogService { get; set; }

        public NewExpensePageViewModel(INavigationService navigationService, IPageDialogService pageDialog):base(navigationService)
        {
            navigationservice = navigationService;
            pageDialogService = pageDialog;

            ExpenseDate = DateTime.Today;
            GetCategories();
        }

        public async void InsertExpense()
        {
            Expense exp = new Expense()
            {
                Name = ExpenseName,
                Description = ExpenseDescription,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate
            };

         int row =  await  Expense.InsertExpense(exp);

            if(row > 0)
            {
                await navigationservice.GoBackAsync();

            }else
            {
               await pageDialogService.DisplayAlertAsync("Error", "No items were inserted", "OK");
            }
        }


      

        /*private void GetCategories()
        {
            Categories.Clear();

            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");


        }*/

        public void GetCategories()
        {
            Categories.Clear();

            Categories.Add(AppResources.housingCategory);
            Categories.Add(AppResources.debtCategory);
            Categories.Add(AppResources.healthCategory);
            Categories.Add(AppResources.foodCategory);
            Categories.Add(AppResources.personalCategory);
            Categories.Add(AppResources.travelCategory);
            Categories.Add(AppResources.otherCategory);


        }

        public void GetExpenseStatus()
        {
            ExpenseStatuseCollection.Clear();

            ExpenseStatuseCollection.Add(new ExpenseStatus() { Name = "Working", Status = true });
            ExpenseStatuseCollection.Add(new ExpenseStatus() { Name = "Random", Status = true });
            ExpenseStatuseCollection.Add(new ExpenseStatus() { Name = "Wasteful", Status = false });
        }

        public void OnAppearing()
        {
            GetExpenseStatus();
            int count = 0;
            foreach(var es in ExpenseStatuseCollection)
            {
                var cell = new SwitchCell { Text = es.Name };
                Binding binding = new Binding();
                binding.Source = ExpenseStatuseCollection[count];

                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;

                cell.SetBinding(SwitchCell.OnProperty, binding);

                var section = new TableSection();
                section.Add(cell);

                TableView tv = new TableView();


                tv.Root.Add(section);               
                count++;
            }
        }

        public void OnDisappearing()
        {
           
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }

            public bool Status { get; set; }
        }
    }
}
