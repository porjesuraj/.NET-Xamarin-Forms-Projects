﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms.FormPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage1 : ContentPage
    {
        public ListView ContactMethods { get { return lists; } }

        public ListPage1()
        {
            InitializeComponent();

            lists.ItemsSource = new List<string>
         {
             "None",
             "Email",
             "SMS"
         };

          
        }

      
    }
}