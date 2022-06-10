﻿using CalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {

      


      

        public HistoryPage(HistoryPageViewModel viewModel)
        {
            //  BindingContext = new HistoryPageViewModel();

            BindingContext = viewModel;

            InitializeComponent();


        }


    }

   
}