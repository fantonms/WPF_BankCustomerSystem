using System;
using System.Windows;
using SqlSugar;
using WPF_BankCustomerSystem.Models;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Repositories;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly UserInfoRepository repository;
        private readonly Window loginWindow;

        // 用于设计时支持


        public LoginViewModel(UserInfoRepository repository, Window loginWindow)
        {
            this.repository = repository;
            this.loginWindow = loginWindow;
        }


        private string account = "admin";

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

        private string password = "admin";

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


        public RelayCommand LoginCommand
        {
            get
            {
                
                return new RelayCommand((obj) =>
                {
                    if (string.IsNullOrEmpty(Account))
                    {
                        MessageBox.Show("账号不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(Password))
                    {
                        MessageBox.Show("密码不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var exp = Expressionable.Create<ViewUserInfo>();
                    exp.And(x => x.Account == Account);
                    exp.And(x => x.Password == Password);
                    exp.And(x => x.Status == 0);
                    var userInfo = repository.GetList(exp);
                    if (userInfo.Count > 1)
                    {
                        MessageBox.Show("账号重复！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else if (userInfo.Count < 1)
                    {
                        MessageBox.Show("账号或密码有误！或账号已被禁用！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        LoginInfo.CurrentUser = userInfo[0];
                        loginWindow.DialogResult = true;

                    }




                });
            }
        }
    }
}
