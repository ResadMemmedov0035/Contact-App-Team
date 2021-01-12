using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace MainApp.Services
{
    public class LocalStorage : IStorage
    {
        private ObservableCollection<Contact> contacts { get; set; }

        public LocalStorage()
        {
            GetAllInformationFromFile();
        }

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

           File.WriteAllText("../../../ContactData.json", text);
        }

        public void GetAllInformationFromFile()
        {
            var text = File.ReadAllText("../../../ContactData.json");
            contacts = JsonSerializer.Deserialize<ObservableCollection<Contact>>(text);
        }

    }
}
