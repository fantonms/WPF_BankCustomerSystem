using SqlSugar;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Models
{
    public class UserInfo : ModelBase
    {
        private int userId;
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserId
        {
            get { return userId; }
            set
            {
                if (userId != value)
                {
                    userId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set
            {
                if (account != value)
                {
                    account = value;
                    OnPropertyChanged();
                }
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
