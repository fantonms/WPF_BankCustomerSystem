using System.Windows;
using WPF_BankCustomerSystem.ViewModels;

namespace WPF_BankCustomerSystem.Views
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        
    }
}
