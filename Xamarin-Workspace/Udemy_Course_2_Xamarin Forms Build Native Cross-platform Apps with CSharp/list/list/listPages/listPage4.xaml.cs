using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using list.Models; 
namespace list.listPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listPage4 : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        ObservableCollection<Contact> GetContacts()
        {
          var contacts =  new ObservableCollection<Contact>
             {
               new Contact{Name="Ram ", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=1"},
                 new Contact{Name="Nikita", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=2"},
                 new Contact{Name="Kedar", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=3"},
                 new Contact{Name="Kalyani", Status="Working",ImageUrl="https://picsum.photos/200/300?random=4"},
                 new Contact{Name="Shubham ", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=5"},
                 new Contact{Name="Mayuri", Status="Working",ImageUrl="https://picsum.photos/200/300?random=6"},

                 new Contact{Name="Diksha", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=7"},
                 new Contact{Name="Sam ", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=8"}


             };


            return contacts;            
     }

        IEnumerable<Contact> GetContacts(string searchText)
        {
            var contacts = new ObservableCollection<Contact>
             {
                 new Contact{Name="Ram ", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=1"},
                 new Contact{Name="Nikita", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=2"},
                 new Contact{Name="Kedar", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=3"},
                 new Contact{Name="Kalyani", Status="Working",ImageUrl="https://picsum.photos/200/300?random=4"},
                 new Contact{Name="Shubham ", Status="Working ",ImageUrl="https://picsum.photos/200/300?random=5"},
                 new Contact{Name="Mayuri", Status="Working",ImageUrl="https://picsum.photos/200/300?random=6"},

                 new Contact{Name="Diksha", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=7"},
                 new Contact{Name="Sam ", Status="on Holiday ",ImageUrl="https://picsum.photos/200/300?random=8"}



             };

            if (String.IsNullOrWhiteSpace(searchText))
                return contacts;
            else
            {
                
                return contacts.Where(c => c.Name.StartsWith(searchText));
            }
               
        }

        public listPage4()
        {
            InitializeComponent();




            _contacts = GetContacts();

            list.ItemsSource = _contacts;

           /* list.ItemsSource = new List<ContactGroup>
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

            };*/
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
             var contacttap = e.Item as Contact;
            DisplayAlert("Tapped", contacttap.Name, "OK");
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
         /*   var contact =  e.SelectedItem as Contact;

            DisplayAlert("Selected", contact.Name, "Ok");*/
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
           var contact =  menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            _contacts.Remove(contact); 

        }
      

        private void list_Refreshing(object sender, EventArgs e)
        {
            list.ItemsSource = GetContacts();

            list.EndRefresh();

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            list.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}