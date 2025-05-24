using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BankCustomerSystem.Models.DTO
{
    
    [SugarTable("V_UserInfo")]
    public class ViewUserInfo : UserInfo
    {
        private string createUserName;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserName
        {
            get { return createUserName; }
            set
            {
                if (createUserName != value)
                {
                    createUserName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lastUpdateUserName;
        /// <summary>
        /// 最后一次修改人
        /// </summary>
        public string LastUpdateUserName
        {
            get { return lastUpdateUserName; }
            set
            {
                if (lastUpdateUserName != value)
                {
                    lastUpdateUserName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? lastUpdateTime;
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
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

        private string statusName;
        /// <summary>
        /// 状态
        /// </summary>
        public string StatusName
        {
            get { return statusName; }
            set
            {
                if (statusName != value)
                {
                    statusName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
    
}
