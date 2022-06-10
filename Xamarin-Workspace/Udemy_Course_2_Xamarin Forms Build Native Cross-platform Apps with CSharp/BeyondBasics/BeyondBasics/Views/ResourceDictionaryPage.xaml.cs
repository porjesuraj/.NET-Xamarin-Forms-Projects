using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeyondBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceDictionaryPage : ContentPage
    {
        public ResourceDictionaryPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Resources["buttonBackgroundColor"] = Color.Green;
        }
    }
}