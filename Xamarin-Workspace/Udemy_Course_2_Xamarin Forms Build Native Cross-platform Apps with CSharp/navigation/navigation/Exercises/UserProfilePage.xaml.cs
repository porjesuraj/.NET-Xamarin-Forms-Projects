using navigation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace navigation.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {

        private UserService service = new UserService();
        public UserProfilePage(int UserId)
        {
            

            BindingContext = service.getUser(UserId);

            InitializeComponent();
        }
        public UserProfilePage()
        {
            BindingContext = service.getUser(1);
            InitializeComponent();
        }
    }
}