using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MainApp.Services
{
    class LocalStorage : IStorage
    {
        private ObservableCollection<IStorage> contacts { get; set; }

        public void Add(IStorage contact)
        {
            contacts.Add(contact);
        }
        public void Remove(IStorage contact)
        {
            contacts.Remove(contact);
        }
        public ObservableCollection<IStorage> GetAll()
        {
            return contacts;
        }
        public void WriteToFile()
        {
           var text = JsonSerializer.Serialize(contacts);
            File.WriteAllText("UserInformation",text);
        }
        public void GetAllInformationFromFile()
        {
            var text = File.ReadAllText("UserInformation");
            contacts = JsonSerializer.Deserialize<ObservableCollection<IStorage>>(text);
        }

    }
}
