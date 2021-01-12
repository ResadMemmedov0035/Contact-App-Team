using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainApp.Services
{
    interface IStorage
    {
        public void Add(IStorage contact);
        public void Remove(IStorage contact);
        public ObservableCollection<IStorage> GetAll();
        public void GetAllInformationFromFile();
        public void WriteToFile();
    }
}
