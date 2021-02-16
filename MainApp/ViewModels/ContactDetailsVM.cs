using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MainApp.Messengers;
using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainApp.ViewModels
{
    class ContactDetailsVM : ViewModelBase
    {
        private int numberCount;// = AddContactVM.Count;
        private int selectedInex;

        public ObservableCollection<Contact> list { get; set; }
        public IStorage Storage { get; set; }
        public int NumberCount { get => numberCount; set => Set(ref numberCount, value); }
        public IMessenger Messenger { get; set; }
        public int SelectedInexs { get => selectedInex;
            set 
            {
                selectedInex = value;
                if (selectedInex == 0)
                {

                }
                if (selectedInex == 2)
                {
                    App.Container.GetInstance<IMessenger>().Send<IndexMessage>(new IndexMessage()
                    {
                        // CurrentVM = App.Container.GetInstance<AddContactVM>(),
                        SelectedIndex = 1

                    });
                    selectedInex = 0;
                }
                
            } 
        }

        public int FavoriteCount { get; set; }

        public ContactDetailsVM(IMessenger messenger,IStorage storage)
        {
            Messenger = messenger;
            Storage = storage;
            list = storage.GetAll();
            IncreaseCount();
        }

        public void IncreaseCount()
        {
           NumberCount =  list.Count;
        }
    }
}
