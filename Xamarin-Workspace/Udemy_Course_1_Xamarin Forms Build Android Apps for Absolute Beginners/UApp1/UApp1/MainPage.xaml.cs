using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 1; 
         void OnButtonClicked(object sender, EventArgs args)
        {
            button.Text = string.Format("{0} clicks!", count++);
        }
    }


    

}
