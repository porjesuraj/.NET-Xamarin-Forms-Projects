using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactApp.Persistence;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        private SQLiteAsyncConnection _connection; 

        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            if (contact == null)
                throw new ArgumentNullException(nameof(Contact));

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                Blocked = contact.Blocked
            };
        }
      


        
        async void ContactSaved(object sender, EventArgs e)
        {
            var contacts = BindingContext as Contact;

            if (String.IsNullOrWhiteSpace(contacts.FullName))
            {
                await DisplayAlert("Error", "Please ente the full name", "OK");

            }


            if (contacts.Id == 0)
            {
                await _connection.InsertAsync(contacts);

                ContactAdded?.Invoke(this, contacts);
            }
            else
            {
                await _connection.UpdateAsync(contacts);
                ContactUpdated?.Invoke(this, contacts);
            }

            await Navigation.PopAsync();




        }
    }
}