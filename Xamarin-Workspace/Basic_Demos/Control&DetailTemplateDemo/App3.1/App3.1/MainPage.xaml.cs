using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3._1
{
    public class ImageCell : ViewCell
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ImageSource OneImage { get; set; }

        public bool smallSize { get; set; }


    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            var images = new List<ImageCell>
            {
                new ImageCell { Title="one", Description="Xamarin is a software company ",smallSize = true, OneImage =ImageSource.FromResource("App3.1.Pictures.smallXam.png")  },
               new ImageCell { Title="two", Description="Xamarin is a software company ",smallSize = false,OneImage =ImageSource.FromResource("App3.1.Pictures.largeXam.png")  },
                 new ImageCell { Title="three", Description="Xamarin is a software company ",smallSize = true, OneImage =ImageSource.FromResource("App3.1.Pictures.smallXam.png")  },
               new ImageCell { Title="four", Description="Xamarin is a software company ",smallSize = false,OneImage =ImageSource.FromResource("App3.1.Pictures.largeXam.png")  },
                     new ImageCell { Title="five", Description="Xamarin is a software company ",smallSize = true, OneImage =ImageSource.FromResource("App3.1.Pictures.smallXam.png")  },
               new ImageCell { Title="six", Description="Xamarin is a software company ",smallSize = false,OneImage =ImageSource.FromResource("App3.1.Pictures.largeXam.png")  },
                  new ImageCell { Title="seven", Description="Xamarin is a software company ",smallSize = true, OneImage =ImageSource.FromResource("App3.1.Pictures.smallXam.png")  },
               new ImageCell { Title="eight", Description="Xamarin is a software company ",smallSize = false,OneImage =ImageSource.FromResource("App3.1.Pictures.largeXam.png")  },

            };

            listView.ItemsSource = images;

        }

       




    }




    public class ImageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LargeImageTemplate { get; set; }
        public DataTemplate ImageWithDetailTemplate { get; set; }


    

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
          



            return ((ImageCell)item).smallSize ? ImageWithDetailTemplate : LargeImageTemplate ; 
           // return ImageWithDetailTemplate;
        }
    }

}
