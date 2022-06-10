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
    public partial class ImagePage1 : ContentPage
    {
        public ImagePage1()
        {
            InitializeComponent();

            #region Images from URi

            #endregion
            // image1.Source

            // var imagesource = (UriImageSource)    ImageSource.FromUri(new Uri(" "));

            var imageS2 = new UriImageSource { Uri = new Uri("https://getwallpapers.com/wallpaper/full/c/0/9/300909.jpg") };
           imageS2.CachingEnabled = false;

            imageS2.CacheValidity = TimeSpan.FromHours(1);

            image1.Source = imageS2;
           // image1.Aspect = Aspect.Fill; 

            //image1.Source = "http://...";
        
        }
        
        
        }
    }
