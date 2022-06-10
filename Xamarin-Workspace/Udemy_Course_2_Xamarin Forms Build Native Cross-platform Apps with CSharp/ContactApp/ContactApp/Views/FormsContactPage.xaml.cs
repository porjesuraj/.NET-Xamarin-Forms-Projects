using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormsContactPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        public FormsContactPage()
        {
            InitializeComponent();
        }


        public FormsContactPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(Contact));

            InitializeComponent();
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

            if(String.IsNullOrWhiteSpace(contacts.FullName))
            {
                await DisplayAlert("Error", "Please ente the full name", "OK");

            }


            if(contacts.Id == 0)
            {
                contacts.Id = 1;

                ContactAdded?.Invoke(this, contacts);
            } else
            {
                ContactUpdated?.Invoke(this, contacts);
            }

            await Navigation.PopAsync();



            
        }
    }
}