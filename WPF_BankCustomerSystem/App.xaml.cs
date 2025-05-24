using System.Windows;
using WPF_BankCustomerSystem.Views;

namespace WPF_BankCustomerSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Login login = new Login();
            if (login.ShowDialog() == true)
            {
                Main mainWindow = new Main();
                mainWindow.ShowDialog();
                Application.Current.Shutdown();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        
    }
}
