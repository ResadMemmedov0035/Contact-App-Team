using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.Messengers
{
    public class IndexMessage : INavigationMessage
    {
         public int SelectedIndex { get; set; }
    }
}
