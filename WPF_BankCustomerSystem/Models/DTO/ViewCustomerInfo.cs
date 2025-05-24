using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BankCustomerSystem.Models.DTO
{
    [SugarTable("V_CustomerInfo")]
    public class ViewCustomerInfo : CustomerInfo
    {
        private string sexName;

        public string SexName
        {
            get { return sexName; }
            set
            {
                if (sexName != value)
                {
                    sexName = value;
                    OnPropertyChanged();
                }
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }

        private string fullAddress;
        /// <summary>
        /// 完整的客户地址
        /// </summary>
        public string FullAddress
        {
            get { return fullAddress; }
            set
            {
                if (fullAddress != value)
                {
                    fullAddress = value;
                    OnPropertyChanged();
                }
            }
        }

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


        private string statusName;

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
