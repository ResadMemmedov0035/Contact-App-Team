using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.ViewModels
{
    class ContactDetailsVM : ViewModelBase
    {
        private int numberCount = AddContactVM.Count;

        public int NumberCount { get => numberCount; set => Set(ref numberCount, value); }

        public int FavoriteCount { get; set; }

        public void IncreaseCount()
        {
            NumberCount++;
        }
    }
}
