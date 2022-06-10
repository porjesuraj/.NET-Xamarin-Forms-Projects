using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactApp.Services
{
  public  class ContactService
    {

        public ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>()
        {
          new Contact{Id = 1, FirstName="Suraj",LastName="Porje",Phone="0",Email="suraj@gmail.com",Blocked = false},
          new Contact{Id = 2, FirstName="raj",LastName="Porje",Phone="0",Email="suraj@gmail.com",Blocked = false},
          new Contact{Id = 3, FirstName="Shiv",LastName="Porje",Phone="0",Email="suraj@gmail.com",Blocked = false}


        };



    }
}
