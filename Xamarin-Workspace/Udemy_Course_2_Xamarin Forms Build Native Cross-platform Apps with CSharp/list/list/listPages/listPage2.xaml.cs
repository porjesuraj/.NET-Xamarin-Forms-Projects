using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using list.Models; 
namespace list.listPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listPage2 : ContentPage
    {
        public listPage2()
        {
            InitializeComponent();

            /* list.ItemsSource = new List<Contact>
             {
                 new Contact{Name="Sunday", Status="Holiday on this day",ImageUrl="https://picsum.photos/200/300?random=1"},
                 new Contact{Name="Monday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=2"},
                 new Contact{Name="Tuesday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=3"},
                 new Contact{Name="Wednesday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=4"},
                 new Contact{Name="Thursday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=5"},
                 new Contact{Name="Friday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=6"},

                 new Contact{Name="Saturday", Status="Holiday on this day",ImageUrl="https://picsum.photos/200/300?random=7"},



             };*/

            list.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup("Weekand","S")
                {
                 new Contact{Name="Saturday", Status="Holiday on this day",ImageUrl="https://picsum.photos/200/300?random=7"},
                  new Contact{Name="Sunday", Status="Holiday on this day",ImageUrl="https://picsum.photos/200/300?random=1"}
                },

                new ContactGroup("Weekdays","W")
                {
                     new Contact{Name="Monday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=2"},
                 new Contact{Name="Tuesday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=3"},
                 new Contact{Name="Wednesday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=4"},
                 new Contact{Name="Thursday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=5"},
                 new Contact{Name="Friday", Status="Working on this day",ImageUrl="https://picsum.photos/200/300?random=6"}

                }

            };
        }
    }
}