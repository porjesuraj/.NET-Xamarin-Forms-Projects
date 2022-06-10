using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPageViewModel ViewModel
        {
            get { return BindingContext as ToDoPageViewModel; }
            set { BindingContext = value; }
        }
        public ToDoPage()
        {

           
            ToDoPageViewModel toDoPageView = new ToDoPageViewModel();
            BindingContext = toDoPageView;

            InitializeComponent();

            toDoPageView.UpdateProgressBar += ToDoPageView_UpdateProgressBar;

           
          
        }

        private async void ToDoPageView_UpdateProgressBar(object sender, double e)
        {
           await listProgressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}