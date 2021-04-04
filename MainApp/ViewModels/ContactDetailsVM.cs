using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MainApp.Messengers;
using MainApp.Models;
using MainApp.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MainApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ContactDetailsVM : ViewModelBase
    {
       // private int numberCount;// = AddContactVM.Count;
        private int selectedInex;
        public static List<Contact> list { get; set; } = new List<Contact>();
        public IStorage Storage { get; set; }
        public int NumberCount { get; set; }
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
        }
        public static void Deactivate()
        {
            list.Clear();
        }
        public  void  Activate()
        {           
            //Task.Run(() =>
           // {
                for (int i = 0; i < Storage.GetAll().Count; i++)
                {
                    list.Add(Storage.GetAll()[i]);
                    IncreaseCount();
                    ItemSourceMessage.action?.Invoke();
                    if(i == 12)
                    Thread.Sleep(30);
                }
            //});
                //foreach (var item in Storage.GetAll())
                //{
                //    //Thread.Sleep(500);
                //    list.Add(item);
                //    IncreaseCount();
                //    ItemSourceMessage.action?.Invoke();
                //}
          //  });
        }
        public void IncreaseCount()
        {
           NumberCount =  list.Count;
        }
    }
}
