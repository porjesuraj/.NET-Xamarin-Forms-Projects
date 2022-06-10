using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dataAccess.DataPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage2 : ContentPage
    {
       
        
      
        public DataPage2()
        {
            
            InitializeComponent();

            #region Using App class property to set control
            /* var app = Application.Current as App;
            title.Text = app.Title;
            notify.On = app.Notification;*/
            #endregion


            BindingContext = Application.Current;

          
        }

        #region using eventhandler to change settings async for multiple pages
        /*  private void OnChange(object sender, System.EventArgs e)
         {
               Application.Current.Properties[TitleKey] = title.Text;
               Application.Current.Properties[NotifyKey] = notify.On;
              Application.Current.SavePropertiesAsync();


             var app = Application.Current as App;

             app.Title = title.Text;
             app.Notification = notify.On;
         }


         protected override void OnDisappearing()
         {
             base.OnDisappearing();
         }
        
         */
        #endregion

    }
}