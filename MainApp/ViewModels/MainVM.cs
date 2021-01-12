using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.ViewModels
{
    public class MainVM : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private int selectedIndex;

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }
        public int SelectedIndex 
        { get => selectedIndex;
            set 
            { 
                Set(ref selectedIndex, value); 

                if(selectedIndex == 0)
                    CurrentViewModel = App.Container.GetInstance<HomePageVM>();
                if (selectedIndex == 1)
                    CurrentViewModel = App.Container.GetInstance<AddContactVM>();
                if (selectedIndex == 2)
                    CurrentViewModel = App.Container.GetInstance<ContactDetailsVM>();
            }
        }

        public MainVM()
        {
            CurrentViewModel = App.Container.GetInstance<HomePageVM>();
        }
    }
}
