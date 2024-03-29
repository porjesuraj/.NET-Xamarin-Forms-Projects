﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ExpenseTrackingApp.iOS.Effects;
using System.ComponentModel;

[assembly: ResolutionGroupName("LPA") ]
[assembly : ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpenseTrackingApp.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new UIColor(176/255, 152/255, 164/255, 255/255);
            
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == "IsFocused")
            {
                if(Control.BackgroundColor != selectedColor)
                {
                    Control.BackgroundColor = selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White; 
                }
            }
        }

        protected override void OnDetached()
        {
           
        }
    }
}