using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace list.listPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listPage1 : ContentPage
    {
        public listPage1()
        {
            InitializeComponent();

            var names = new List<string>
            {
                "Sunday", "Monday","Tuesday",
                "Wednesday","Thursday","Friday",
                "Saturday","Sunday"
            };

            listview.ItemsSource = names; 
          

        }
    }
}