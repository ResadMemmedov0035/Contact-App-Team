﻿using GalaSoft.MvvmLight.Messaging;
using MainApp.Messengers;
using MainApp.Services;
using MainApp.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
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
        static Mutex mutex = new Mutex();
        protected override void OnStartup(StartupEventArgs e)
        {
            if(Mutex.TryOpenExisting("FirstMutex", out Mutex m))
            {
                MessageBox.Show("The program is already open","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                Environment.Exit(0);
            }
            mutex = new Mutex(true, "FirstMutex");
            Container = new Container();

            Container.RegisterSingleton<MainVM>();
            Container.Register<AddContactVM>();
            Container.RegisterSingleton<HomePageVM>();
            Container.RegisterSingleton<ContactDetailsVM>();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IStorage, LocalStorage>();
            Container.RegisterSingleton<MainWindow>();
            var Window = Container.GetInstance<MainWindow>();
            Window.Show();
             base.OnStartup(e);
        }
    }
}
