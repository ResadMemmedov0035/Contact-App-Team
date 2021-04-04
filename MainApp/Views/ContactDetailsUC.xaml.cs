using GalaSoft.MvvmLight.Messaging;
using MainApp.Messengers;
using MainApp.Models;
using MainApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApp.Views
{
    /// <summary>
    /// Interaction logic for ContactDetailsUC.xaml
    /// </summary>
    public partial class ContactDetailsUC : UserControl
    {
        public ContactDetailsUC()
        {
            ItemSourceMessage.action = RefreshItem;      
            InitializeComponent();
        }
         
        public void RefreshItem()
        {
            Dispatcher.Invoke(() =>
            {
                ListBox2.Items.Refresh();
            });
        }
    }
}
