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
                    Job = "Programmer",
                    PhotoURL = "https://i.pinimg.com/originals/26/76/3d/26763d481172f5dc599d151570b38ded.png"
                },
                new Contact()
                {
                    ID = 1,
                    FirstName = "Rasim",
                    LastName = "Aliyew",
                    PhoneNumber ="055 123 32 12",
                    EmailAdress = "RA@gmail.com",
                    Favorite = true,
                    Job = "Programmer",
                    PhotoURL = "https://i.pinimg.com/originals/26/76/3d/26763d481172f5dc599d151570b38ded.png"
                }
            };
        }
    }
}
