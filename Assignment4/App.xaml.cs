﻿namespace Assignment4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly FormMain formMain = new FormMain();
        //private readonly MainWindow mainWindow = new MainWindow(); //Wpf not implemented due to time constraints

        public App()
        {
            formMain.Show();
            //mainWindow.Show();
        }
    }
}
