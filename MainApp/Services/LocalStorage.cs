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
        private ObservableCollection<Contact> contacts { get; set; }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
            WriteToFile();
        }
        public void Remove(Contact contact)
        {
            contacts.Remove(contact);
            WriteToFile();
        }
        public ObservableCollection<Contact> GetAll() => contacts;
        public void WriteToFile()
        {
           var text = JsonSerializer.Serialize(contacts);
            File.WriteAllText("UserInformation.json",text);
        }
        public void GetAllInformationFromFile()
        {
            var text = File.ReadAllText("UserInformation.json");
            contacts = JsonSerializer.Deserialize<ObservableCollection<Contact>>(text);
        }

    }
}
