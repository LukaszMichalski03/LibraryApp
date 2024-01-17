using LibraryApp.Data;

using LibraryApp.Interfaces;
using LibraryApp.Repositories;
using LibraryApp.Stores;
using LibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .Build();

        }



        protected override void OnStartup(StartupEventArgs e)
        {
            //SQLitePCL.Batteries.Init();
            _host.Start();
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new HomeBooksViewModel(navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
