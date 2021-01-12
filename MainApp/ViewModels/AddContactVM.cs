using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.ViewModels
{
    class AddContactVM : ViewModelBase
    {
        private RelayCommand addButtonCommand;

        IStorage storage;

        private static int Count = 0;

        public string FirstNameProp { get; set; }

        public string LastNameProp { get; set; }

        public string PhoneNumberProp { get; set; }

        public string EmailAdressProp { get; set; }

        public string PhotoProp { get; set; }

        public bool FavoriteProp { get; set; }

        public string JobProp { get; set; }

        public RelayCommand AddButtonCommand => addButtonCommand ?? (addButtonCommand = new RelayCommand(() => Add()));

        public AddContactVM(IStorage storage)
        {
            this.storage = storage;
        }
        public void Add()
        {
            storage.Add(new Contact()
            {
                FirstName = FirstNameProp,
                LastName = LastNameProp,
                ID = ++Count,
                PhotoURL = PhotoProp,
                PhoneNumber = PhoneNumberProp,
                EmailAdress = EmailAdressProp,
                Job = JobProp,
                Favorite = FavoriteProp
            }) ;
        }
    }
}
