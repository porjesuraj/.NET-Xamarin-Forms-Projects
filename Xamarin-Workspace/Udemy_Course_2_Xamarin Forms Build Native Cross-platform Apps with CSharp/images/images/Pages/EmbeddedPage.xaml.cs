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
    public partial class EmbeddedPage : ContentPage
    {
        public EmbeddedPage()
        {
            InitializeComponent();

            image.Source = ImageSource.FromResource("images.images.background.jpg");
        }
    }
}