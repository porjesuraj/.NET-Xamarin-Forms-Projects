using MVVMExercise.Model;
using MVVMExercise.Persistence;
using MVVMExercise.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMExercise.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
       
        public ContactPage()
        {
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
           ViewModel = new ConactsPageViewModel(contactStore, pageService);

           
            InitializeComponent();

          
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        public ConactsPageViewModel ViewModel
        {
            get { return BindingContext as ConactsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}