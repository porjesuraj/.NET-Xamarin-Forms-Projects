using ContactsXamarinApp.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Contact))]
namespace ContactsXamarinApp.iOS
{
    class Contact : IContact
    {
        public Contact()
        {

        }

        public string ByeContanct()
        {

          //  NativeLibrary.ContactsApp contact = new NativeLibrary.ContactsApp((Foundation.NSString)"Suraj", (Foundation.NSString)"Porje", (Foundation.NSString)"surajporje@gmail.com");
           // return contact.ByeContact();
            return null;
          
        }

        public string HelloContanct()
        {
           // NativeLibrary.ContactsApp contact = new NativeLibrary.ContactsApp((Foundation.NSString)"Suraj", (Foundation.NSString)"Porje", (Foundation.NSString)"surajporje@gmail.com");
          //  return contact.GreetContact();
            return null;

        }
    }
}