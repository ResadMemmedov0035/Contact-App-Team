using GalaSoft.MvvmLight;
using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainApp.ViewModels
{
    class HomePageVM : ViewModelBase
    {
        private IStorage Storage;

        public ObservableCollection<Contact> TempContacts => Storage.GetAll();

        public HomePageVM(IStorage storage)
        {
            Storage = storage;   
        }
    }
}
