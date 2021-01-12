using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainApp.Services
{
    interface IStorage
    {
        public void Add(Contact contact);
        public void Remove(Contact contact);
        public ObservableCollection<Contact> GetAll();
    }
}
