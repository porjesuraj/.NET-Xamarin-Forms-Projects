﻿using moviesApp.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace moviesApp.Modules.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView(MainViewViewModel viewModel)        {
            InitializeComponent();

            BindingContext =viewModel;
        }
    }
}