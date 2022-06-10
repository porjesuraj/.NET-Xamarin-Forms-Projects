using MVVMExercise.Model;
using MVVMExercise.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMExercise.ViewModels;
namespace MVVMExercise.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
       

        public ContactDetailsPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
         
        }




      
    }
}