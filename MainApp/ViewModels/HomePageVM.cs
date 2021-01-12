using GalaSoft.MvvmLight;
using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainApp.ViewModels
{
    class HomePageVM : ViewModelBase
    {
        private ObservableCollection<Contact> tempContacts;

        public ObservableCollection<Contact> TempContacts { get => tempContacts; set => Set(ref tempContacts, value); }

        public HomePageVM()
        {
            TempContacts = new ObservableCollection<Contact>
            {
                new Contact()
                {
                    ID = 0,
                    FirstName = "Resad",
                    LastName = "Mmdv",
                    PhoneNumber ="055 123 45 67",
                    EmailAdress = "RM@gmail.com",
                    Favorite = true,
                    Job = "Programmer"
                },
                new Contact()
                {
                    ID = 1,
                    FirstName = "Rasim",
                    LastName = "Aliyew",
                    PhoneNumber ="055 123 32 12",
                    EmailAdress = "RA@gmail.com",
                    Favorite = true,
                    Job = "Programmer"
                }
            };
        }
    }
}
