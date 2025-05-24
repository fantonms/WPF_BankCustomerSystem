using System.Windows;
using WPF_BankCustomerSystem.Repositories;
using WPF_BankCustomerSystem.ViewModels;

namespace WPF_BankCustomerSystem.Views
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(new UserInfoRepository(), this);


        }
        
    }
}
