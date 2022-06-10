using ContactApp.Models;
using ContactApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {

        private ContactService _service = new ContactService();

        private ObservableCollection<Contact> contacts;
        public ContactListPage()
        {
            InitializeComponent();


            contacts = _service._contacts;
            contactList.ItemsSource = contacts;
        }

        private async void AddContact(object sender, EventArgs e)
        {
            var page = new FormsContactPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                contacts.Add(contact);
            };


            await Navigation.PushAsync(page);

        }

        private async void contactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;

            contactList.SelectedItem = null;

            var page = new FormsContactPage(contact);

            page.ContactUpdated += (source, updatedContact) =>
            {
                contact.Id = updatedContact.Id;
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                contact.Blocked = updatedContact.Blocked;

            };

            

            await Navigation.PushAsync(page);
        }

        private async void OnDeleteContact(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;


            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                contacts.Remove(contact);

        }
    }
}