using SqlSugar;
using System;
using System.Linq;
using System.Windows;
using WPF_BankCustomerSystem.Models;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Repositories;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.ViewModels.Pages
{
    public class UserAddEditViewModel : ViewModelBase
    {
        private readonly UserInfoRepository repository;
        private readonly Window win;
        private readonly int editId;
        public UserAddEditViewModel(UserInfoRepository repository, Window win, int editId)
        {
            this.repository = repository;
            this.win = win;
            this.editId = editId;
            if (editId > 0)
            {
                WindowTitle = "编辑用户信息";
                ButtonText = "修改";
                User = repository.GetModel(editId);
            }
            else
            {
                WindowTitle = "添加用户信息";
                ButtonText = "添加";
                User = new UserInfo();
            }
        }

        private string windowTitle = "添加";

        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                if (windowTitle != value)
                {
                    windowTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        private string buttonText = "添加";

        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                if (buttonText != value)
                {
                    buttonText = value;
                    OnPropertyChanged();
                }
            }
        }

        private UserInfo user;

        public UserInfo User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
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

        public RelayCommand SaveCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (string.IsNullOrWhiteSpace(User.Account))
                    {
                        MessageBox.Show("账号不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(User.Password))
                    {
                        MessageBox.Show("密码不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                    if (editId > 0)
                    {
                        var exp = Expressionable.Create<ViewUserInfo>();
                        exp.And(x => x.Account == User.Account);
                        exp.And(x => x.UserId != editId);
                        exp.And(x => x.Status == 0);
                        if (repository.GetList(exp).Count > 0)
                        {
                            MessageBox.Show("用户名已存在", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (!repository.Update(User))
                        {
                            MessageBox.Show("更新失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                        var exp = Expressionable.Create<ViewUserInfo>();
                        exp.And(x => x.Account == User.Account);
                        exp.And(x => x.Status == 0);

                        if (repository.GetList(exp).Count > 0)
                        {
                            MessageBox.Show("添加的账号已经存在！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (!repository.Add(User))
                        {
                            MessageBox.Show("添加失败！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }


                    }
                    win.DialogResult  = true;

                });
            }
        }
    }
}
