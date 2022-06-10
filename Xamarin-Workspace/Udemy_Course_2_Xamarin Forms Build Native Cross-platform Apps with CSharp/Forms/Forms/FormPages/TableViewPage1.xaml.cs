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
    public partial class TableViewPage1 : ContentPage
    {
        public TableViewPage1()
        {
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var page = new ListPage1();


            page.ContactMethods.ItemSelected += (s, a) =>
            {
                contactMethod.Text = a.SelectedItem.ToString();
                Navigation.PopAsync();
            };



            Navigation.PushAsync(page);
        }
    }
}