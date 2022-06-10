using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlEssential
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class oneGreetings : ContentPage
    {
        public oneGreetings()
        {
            InitializeComponent();


            /*  Content = new Label
              {
                  HorizontalOptions = LayoutOptions.Center,
                  VerticalOptions = LayoutOptions.Center,
                  Text = "hello World",
                  TextColor = Color.Red

              };*/

            slider.Value = 50; 
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Value is {0:F2}", e.NewValue); 

        }
    }
}