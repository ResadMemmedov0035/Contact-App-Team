using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
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

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }
        public int SelectedIndex { get => selectedIndex;
            set
            {
                Set(ref selectedIndex, value);

                if (selectedIndex == 0)
                    CurrentViewModel = App.Container.GetInstance<HomePageVM>();
                if (selectedIndex == 1)
                    CurrentViewModel = App.Container.GetInstance<AddContactVM>();
                if (selectedIndex == 2)
                    CurrentViewModel = App.Container.GetInstance<ContactDetailsVM>();
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

        public MainVM()
        {
            CurrentViewModel = App.Container.GetInstance<HomePageVM>();
            ColumnWidth = new GridLength(40);
        }
    }
}
