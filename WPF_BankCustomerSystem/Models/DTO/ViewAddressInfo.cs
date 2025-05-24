using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BankCustomerSystem.Models.DTO
{
    [SugarTable("V_AddressInfo")]
    public class ViewAddressInfo : AddressInfo
    {
		private string  fullAddress;

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
