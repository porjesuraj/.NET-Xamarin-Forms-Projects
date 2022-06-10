using navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace navigation.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        ObservableCollection<Contact> GetContacts()
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

        public ContactPage()
        {
            InitializeComponent();
            _contacts = GetContacts();

            list.ItemsSource = _contacts;

           
        }

        

        private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;


            var contact = e.SelectedItem as Contact;

           await Navigation.PushAsync(new ContactDetailPage(contact));
            list.SelectedItem = null;
           
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

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

        private void list_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
          await  DisplayAlert("Response", "Add new Contact", "OK");
        }
    }
}