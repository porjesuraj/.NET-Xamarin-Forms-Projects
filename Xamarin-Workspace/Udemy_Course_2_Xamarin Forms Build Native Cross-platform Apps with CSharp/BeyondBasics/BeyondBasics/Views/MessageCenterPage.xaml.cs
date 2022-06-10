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
    public partial class MessageCenterPage : ContentPage
    {

       // public event EventHandler<double> SliderValueChanged;
        public MessageCenterPage()
        {
            InitializeComponent();
        }

       

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {

            MessagingCenter.Send(this, Events.SliderValueChanged, e.NewValue);

            
          //  SliderValueChanged?.Invoke(this, e.NewValue);
        }
    }
}