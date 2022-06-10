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
    public partial class ExerciseApp : ContentPage
    {
        int count = 0; 

        public ExerciseApp()
        {
            InitializeComponent();
           
        }

      
       
        private void Button_Clicked(object sender, EventArgs e)
        {
            ++ count;

            switch (count)
            {
                case 1:
                    quotes.Text = "“If you don’t build your dream, someone else will hire you to help them build theirs.” " + "\n\n" + "- Dhirubhai Ambani";
                    break;
                case 2:
                    quotes.Text = " “The first step toward success is taken when you refuse to be a captive of the environment in which you first find yourself” " + "\n\n" + "- Mark Caine";

                    break;

                case 3:
                    quotes.Text = " “Really it comes down to your philosophy. Do you want to play it safe and be good or do you want to take a chance and be great?” " + "\n\n" + " - Jimmy J";
                    break;

                case 4:

                    quotes.Text = "“Take up one idea. Make that one idea your life – think of it, dream of it, live on that idea. Let the brain, muscles, nerves, every part of your body, be full of that idea, and just leave every other idea alone. This is the way to success.”  " + "\n\n" + " -Swami Vivekananda";
                    count = 0;
                    break;


                default:

                    break;
            }
        }
    }
}