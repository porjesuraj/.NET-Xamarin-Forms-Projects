﻿using MVVMExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExercise.ViewModels
{
   public interface IContactStore
    {

        Task<IEnumerable<Contact>> GetContactsAsync();

        Task<Contact> GetContact(int id);

        Task AddContact(Contact contact);

        Task UpdateContact(Contact contact);
        Task DeleteContact(Contact contact);
    }
}
