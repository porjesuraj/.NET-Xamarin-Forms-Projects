using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms.FormPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormPage1 : ContentPage
    {
        public FormPage1()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            elabel.Text = e.NewTextValue; 
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            plabel.Text = "password Entered";
        }
    }
}