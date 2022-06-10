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
    public partial class ImageExercise : ContentPage
    {
        int count; 
        public ImageExercise()
        {
            InitializeComponent();

            count = 0;



            var imagesource = new UriImageSource { Uri = new Uri("https://picsum.photos/200/300?random=1") };

            imagesource.CachingEnabled = false;

            images.Source = imagesource;



        }
       
        private void Left_Clicked(object sender, EventArgs e)
        {
            --count;

           
            var imagesource = new UriImageSource { Uri = new Uri("https://picsum.photos/200/300?random={count}") };

            imagesource.CachingEnabled = false;

            images.Source = imagesource;

          
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            ++count;
          
            var imagesource = new UriImageSource { Uri = new Uri("https://picsum.photos/200/300?random={count}") };

            imagesource.CachingEnabled = false;

            images.Source = imagesource;
           
        }
    }
}