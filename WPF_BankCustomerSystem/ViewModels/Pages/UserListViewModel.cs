using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Repositories;
using WPF_BankCustomerSystem.Unilities;
using WPF_BankCustomerSystem.UserControls;

namespace WPF_BankCustomerSystem.ViewModels.Pages
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly UserInfoRepository repository;
        private readonly Page win;
        public readonly UCPager ucPager;
        public UserListViewModel(UserInfoRepository repository, Page win)
        {
            this.repository = repository;
            this.win = win;
            this.ucPager = win.FindName("ucPage1") as UCPager;
        }

        private int totalPage = 0;

        public int TotalPage
        {
            get { return totalPage; }
            set 
            {
                if (totalPage != value)
                {
                    totalPage = value;
                    OnPropertyChanged();
                }

            }
        }


        private string account = string.Empty;
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

        private string status = "全部";
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? createTimeStart;
        public DateTime? CreateTimeStart
        {
            get { return createTimeStart; }
            set
            {
                if (createTimeStart != value)
                {
                    createTimeStart = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? createTimeEnd;
        public DateTime? CreateTimeEnd
        {
            get { return createTimeEnd; }
            set
            {
                if (createTimeEnd != value)
                {
                    createTimeEnd = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<ViewUserInfo> users;
        public List<ViewUserInfo> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ucPager.Page = 1;
                });
            }
        }

        public RelayCommand PageChangedCommand
        {
            get
            {
                return new RelayCommand((obj) => { GetUsers(); });
            }
        }

        private void GetUsers()
        {
            int totalCount = 0;
            var exp = Expressionable.Create<ViewUserInfo>();
            exp.AndIF(!string.IsNullOrWhiteSpace(Account), it => it.Account.Contains(Account));
            exp.AndIF(!string.IsNullOrWhiteSpace(Status) && Status != "全部", it => it.StatusName.Contains(Status));
            if (CreateTimeStart != null)
            {
                DateTime dt = CreateTimeStart.Value.Date;
                exp.And(it => it.CreateTime >= dt);
            }
            if (CreateTimeEnd != null)
            {
                DateTime dt = CreateTimeEnd.Value.Date.AddDays(1).AddTicks(-1);
                exp.And(it => it.CreateTime <= dt);
            }

            Users = repository.GetListByPage(exp, ucPager.Page, ucPager.PageSize, ref totalCount);

            TotalPage = totalCount % ucPager.PageSize == 0 ? totalCount / ucPager.PageSize : totalCount / ucPager.PageSize + 1;
            ucPager.TotalPage = TotalPage;
        }

        public RelayCommand AddEditCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    bool success = int.TryParse(obj.ToString(), out int editId);
                    if (!success) return;

                    Type type = Type.GetType("WPF_BankCustomerSystem.Views.Pages.UserAddEdit");
                    var win = (Window)Activator.CreateInstance(type, editId);
                    if (win.ShowDialog() == true)
                    {
                        GetUsers();
                    }
                });
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    bool success = int.TryParse(obj.ToString(), out int editId);
                    if (!success) return;

                    MessageBoxResult mbr = MessageBox.Show("你确实要删除此条数据吗？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbr != MessageBoxResult.Yes) return;

                    if (repository.Delete(editId))
                    {
                        GetUsers();
                    }
                });
            }
        }

    }
}
