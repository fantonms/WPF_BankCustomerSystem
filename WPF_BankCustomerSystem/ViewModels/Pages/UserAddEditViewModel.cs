using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_BankCustomerSystem.Models;
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
                ButtonText  = "修改";
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

	}
}
