using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace MainApp.ViewModels
{
    class HomePageVM : ViewModelBase
    {
        private IStorage Storage;
        private IEnumerable<Contact> contacts;
        private RelayCommand searchCommand;
        private string search;

        public IEnumerable<Contact> Contacts { get => contacts; set => Set(ref contacts, value); } /*=> Storage.GetAll();*/
        public string Search
        { get => search;
            set
            {
                search = value;
                SearchCommand.RaiseCanExecuteChanged();
            }
        }
        
        public RelayCommand SearchCommand => searchCommand ??= new RelayCommand(() =>
        {
            Contacts = Storage.GetAll();
            Contacts = Contacts.Where(x =>
            {
                return
                x.FirstName.Contains(Search) ||
                x.LastName.Contains(Search) ||
                x.PhoneNumber.Contains(Search) ||
                x.Job.Contains(Search) ||
                x.EmailAdress.Contains(Search);
            });
        },
        () => !string.IsNullOrWhiteSpace(Search));

        public HomePageVM(IStorage storage)
        {
            Storage = storage;
            Contacts = Storage.GetAll();
        }
    }
}
