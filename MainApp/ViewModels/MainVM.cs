using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MainApp.Messengers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.ViewModels
{
    public class MainVM : ViewModelBase
    {

        private ViewModelBase currentViewModel;
        private int selectedIndex = 0;
        private GridLength columnWidth;
        private bool isCheckedHamgurber;
        public IMessenger Messenger { get; set; }
        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }
        public int SelectedIndex { get => selectedIndex;
            set
            {
                Set(ref selectedIndex, value);

                if (selectedIndex == 0)
                {
                    ContactDetailsVM.Deactivate();
                    CurrentViewModel = App.Container.GetInstance<HomePageVM>();
                }
                if (selectedIndex == 1)
                {
                    ContactDetailsVM.Deactivate();
                    CurrentViewModel = App.Container.GetInstance<AddContactVM>();
                }
                if (selectedIndex == 2)
                {
                    CurrentViewModel = App.Container.GetInstance<ContactDetailsVM>();

                    Task.Run(() =>
                    {
                       (CurrentViewModel as ContactDetailsVM).Activate();
                    });
                }
            }
        }
        public GridLength ColumnWidth 
        {
            get => columnWidth; 
            set => Set(ref columnWidth, value); 
        }
        public bool IsCheckedHamgurber { get => isCheckedHamgurber;
            set
            {
                isCheckedHamgurber = value;

                if (isCheckedHamgurber)
                    ColumnWidth = new GridLength(200);
                else
                    ColumnWidth = new GridLength(40);
            }
        }

        public MainVM(IMessenger messenger)
        {
            Messenger = messenger;
            ColumnWidth = new GridLength(40);
            CurrentViewModel = App.Container.GetInstance<HomePageVM>();
            Messenger.Register<IndexMessage>(this, x => { this.SelectedIndex = x.SelectedIndex; });
            SelectedIndex = 2;
        }
    }
}
