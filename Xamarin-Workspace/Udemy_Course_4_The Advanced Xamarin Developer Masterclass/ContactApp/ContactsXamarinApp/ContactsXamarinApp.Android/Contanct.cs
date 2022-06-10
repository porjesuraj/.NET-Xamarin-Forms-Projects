using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactsXamarinApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Contanct))]
namespace ContactsXamarinApp.Droid
{
    public class Contanct : IContact
    {
        public string ByeContanct()
        {
            Contacts.Contact contact = new Contacts.Contact("Suraj", "Porje", "surajporje@gmail.com");
            return contact.ByeContact();
            
        }

        public string HelloContanct()
        {
            Contacts.Contact contact = new Contacts.Contact("Suraj", "Porje", "surajporje@gmail.com");

            return contact.GreetContact();
            
        }
    }
}