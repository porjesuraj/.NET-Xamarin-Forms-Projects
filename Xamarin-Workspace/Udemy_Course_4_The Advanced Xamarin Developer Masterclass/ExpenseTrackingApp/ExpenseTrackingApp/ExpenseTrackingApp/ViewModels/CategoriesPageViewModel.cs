using ExpenseTrackingApp.Interfaces;
using ExpenseTrackingApp.Models;
using ExpenseTrackingApp.Resources;
using PCLStorage;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace ExpenseTrackingApp.ViewModels
{
    public class CategoriesPageViewModel : BindableBase, IPageLifecycleAware
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; } = new ObservableCollection<CategoryExpenses>();

        private DelegateCommand _exportCommand;
        public DelegateCommand ExportCommand =>
            _exportCommand ?? (_exportCommand = new DelegateCommand(ShareReport));

       
        public CategoriesPageViewModel()
        {
            //Categories = new ObservableCollection<string>();
           
        }

        /*   public void GetCategories()
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

        public async void GetExpensePerCategory()
        {
            float totalExpensesAmount = await Expense.TotalExpensesAmount();

            foreach (string c in Categories)
            {
                var expenses = await Expense.GetExpensesPerCategory(c);

                float expenseAmountInCategory = expenses.Sum(e => e.Amount);

                CategoryExpenses ce = new CategoryExpenses()
                {
                    Category = c,
                    ExpensePercentage = expenseAmountInCategory / totalExpensesAmount

                };

                CategoryExpensesCollection.Add(ce);
            }
        }

          
        

        public void OnAppearing()
        {
            GetCategories();
            GetExpensePerCategory();
        }

        public void OnDisappearing()
        {
            CategoryExpensesCollection.Clear();
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }

            public float ExpensePercentage { get; set; }
        }

        public async void ShareReport()
        {
            try
            {
                IFileSystem fileSystem = FileSystem.Current;

                IFolder rootFolder = fileSystem.LocalStorage;

                IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports",CreationCollisionOption.OpenIfExists);

                var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

                using(StreamWriter sw = new StreamWriter(txtFile.Path))
                {
                    foreach(var ce in CategoryExpensesCollection)
                    {
                        sw.WriteLine($"{ce.Category} - {ce.ExpensePercentage:p}");
                    }
                }

                IShare shareDependency = DependencyService.Get<IShare>();

             await   shareDependency.Show("Expense Report", "Here is your expense report", txtFile.Path);

            }
            catch (NullReferenceException)
            {

                throw;
            }

        }
    }

}
