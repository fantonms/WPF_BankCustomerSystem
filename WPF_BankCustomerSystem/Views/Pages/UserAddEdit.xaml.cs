using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_BankCustomerSystem.Repositories;
using WPF_BankCustomerSystem.ViewModels.Pages;

namespace WPF_BankCustomerSystem.Views.Pages
{
    /// <summary>
    /// UserAddEdit.xaml 的交互逻辑
    /// </summary>
    public partial class UserAddEdit : Window
    {
        public UserAddEdit(int editId)
        {
            InitializeComponent();
            this.DataContext = new UserAddEditViewModel(new UserInfoRepository(), this, editId);
        }
    }
}
