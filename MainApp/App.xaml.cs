using GalaSoft.MvvmLight.Messaging;
using MainApp.Services;
using MainApp.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new Container();

            Container.RegisterSingleton<MainVM>();
            Container.Register<AddContactVM>();
            Container.RegisterSingleton<HomePageVM>();
            Container.RegisterSingleton<ContactDetailsVM>();
        


            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IStorage, LocalStorage>();

            base.OnStartup(e);
        }
    }
}
