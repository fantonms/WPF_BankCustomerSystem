using WPF_BankCustomerSystem.Unilities;
using WPF_BankCustomerSystem.Views;

namespace WPF_BankCustomerSystem.ViewModels
{

    public class DesignTimeLoginViewModel : LoginViewModel
    {
        public DesignTimeLoginViewModel()
            : base(null, new Login()) // 或者传入 mock 的 repository
        {
            Account = "test_user";
            Password = "test_password";
        }
    }

}
