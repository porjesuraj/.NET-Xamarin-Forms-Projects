using ExpenseTrackingApp.Models;
using ExpenseTrackingApp.Views;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpenseTrackingApp.Behaviors
{
    public class ListViewBehavior : Behavior<ListView>
    {

        public INavigationService navigationService1 { get; set; }
        public ListViewBehavior(INavigationService navigationService)
        {
            navigationService1 = navigationService;
        }

        ListView listView;



        public ListViewBehavior()
        {

        }



        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            listView = bindable;

            listView.ItemSelected += ListView_ItemSelected;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Expense selectedExpense = (listView.SelectedItem) as Expense;

            //Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailPage(selectedExpense));

            var navparam = new NavigationParameters
            {
                {"expense",selectedExpense }

            };


         //   Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailPage());
           // navigationService1.NavigateAsync("ExpenseDetailPage",navparam);
            
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
