using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ExpenseTrackingApp.Droid.Effects;
using System.ComponentModel;
using Android.Graphics.Drawables;

[assembly: ResolutionGroupName("LPA")]
[assembly : ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpenseTrackingApp.Droid.Effects
{
    class SelectedEffect : PlatformEffect
    {
        Android.Graphics.Color selectedColor;

        public SelectedEffect()
        {

        }

        protected override void OnAttached()
        {
            selectedColor = new Android.Graphics.Color(176, 152, 164);
            

            
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable)Control.Background).Color != selectedColor)
                    {
                        Control.SetBackgroundColor(selectedColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.White);
                    }
                }
            }
            catch (Exception)
            {

                Control.SetBackgroundColor(selectedColor);
            }

         
        }


        protected override void OnDetached()
        {
            
        }
    }
}