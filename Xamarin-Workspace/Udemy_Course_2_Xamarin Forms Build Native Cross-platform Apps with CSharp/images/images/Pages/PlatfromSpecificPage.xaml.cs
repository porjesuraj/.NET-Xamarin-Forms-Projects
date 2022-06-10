using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace images.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatfromSpecificPage : ContentPage
    {
        public PlatfromSpecificPage()
        {
            InitializeComponent();

         /*   btn.ImageSource = (FileImageSource) ImageSource.FromFile(

          Device.OnPlatform(

                iOS: "clock.png",
                Android: "clock.png"
                ));
            }*/

        }
    }
}