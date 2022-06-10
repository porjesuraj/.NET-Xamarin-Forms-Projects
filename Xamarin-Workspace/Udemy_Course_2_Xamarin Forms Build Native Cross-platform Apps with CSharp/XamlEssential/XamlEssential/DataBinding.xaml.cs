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
    public partial class DataBinding : ContentPage
    {
        [Obsolete]
        public DataBinding()
        {
            InitializeComponent();

            #region Device Difference code using switch case 

            /*  switch (Device.RuntimePlatform)

              {
                  case Device.iOS:
                      Padding = new Thickness(0, 20, 0, 0);
                      break;

                  case Device.Android:
                      Padding = new Thickness(10, 20, 0, 0);

                      break;

                  default:
                      break;
              }
  */

            double top = 0; 

            switch (Device.RuntimePlatform)

            {
                case Device.iOS:
                    top = 0;
                
                    break;

                case Device.Android:
                    top = 10;

                    break;

                default:
                    break;
            }

            layout.Margin = new Thickness(top, 20, 0, 0); 



            if(Device.Idiom == TargetIdiom.Phone)
            {

            }else
            {

            }



            #endregion

            #region Obslete method
            // need to use  [Obsolete] attribute on class
         /*   Padding = Device.OnPlatform<Thickness>(
            iOS: new Thickness(0, 20, 0, 0),
            Android: new Thickness(0),
            WinPhone: new Thickness(0));

            Device.OnPlatform(
            iOS: () =>
            {
                //	code	to	run	in	iOS	only	
            });
*/
            #endregion

        }


    }
}