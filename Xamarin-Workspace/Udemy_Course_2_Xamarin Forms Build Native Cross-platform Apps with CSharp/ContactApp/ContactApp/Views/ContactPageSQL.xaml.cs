using ContactApp.Models;
using ContactApp.Persistence;
using SQLite;
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
    public partial class ContactPageSQL : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        private SQLiteAsyncConnection _connection;

        private bool _isDataLoaded;
        public ContactPageSQL()
        {
            InitializeComponent();

          _connection =  DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();


            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Contact>();

            var contacts = await _connection.Table<Contact>().ToListAsync();

            _contacts = new ObservableCollection<Contact>(contacts);

            contactList.ItemsSource = _contacts;
        }

        private async void AddContact(object sender, EventArgs e)
        {
            var page = new ContactDetailsPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);

            };

            await Navigation.PushAsync(page);

        }

        private async void OnDeleteContact(object sender, EventArgs e)
        {

            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
            {
                _contacts.Remove(contact);

                await _connection.DeleteAsync(contact);
            }

        }

        private async void contactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (contactList.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contactList.SelectedItem = null;

            var page = new ContactDetailsPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.Blocked = contact.Blocked;
            };

            await Navigation.PushAsync(page);

        }
    }
}