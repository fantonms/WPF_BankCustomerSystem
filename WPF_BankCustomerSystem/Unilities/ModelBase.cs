using System;

namespace WPF_BankCustomerSystem.Unilities
{
    public class ModelBase : ViewModelBase
    {
        private int createUserId = LoginInfo.CurrentUser != null ? LoginInfo.CurrentUser.UserId : 0;

        public int CreateUserId
        {
            get { return createUserId; }
            set
            {
                if (createUserId != value)
                {
                    createUserId = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime createTime = DateTime.Now;

        public DateTime CreateTime
        {
            get { return createTime; }
            set
            {
                if (createTime != value)
                {
                    createTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private int? lastUpdateUserId;

        public int? LastUpdateUserId
        {
            get { return lastUpdateUserId; }
            set
            {
                if (lastUpdateUserId != value)
                {
                    lastUpdateUserId = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? lastUpdateTime;

        public DateTime? LastUpdateTime
        {
            get { return lastUpdateTime; }
            set
            {
                if (lastUpdateTime != value)
                {
                    lastUpdateTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private int status = 0;

        public int Status
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

    }
}
