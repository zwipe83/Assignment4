using Assignment4;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly FormMain formMain = new FormMain();
        private readonly MainWindow mainWindow = new MainWindow();

        public App()
        {
            formMain.Show();
            mainWindow.Show();
        }
    }
}
