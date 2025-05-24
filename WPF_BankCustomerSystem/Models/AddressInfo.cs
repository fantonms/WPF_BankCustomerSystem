using SqlSugar;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Models
{
    public class AddressInfo : ModelBase
    {
        private int addressId;
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]

        public int AddressId
        {
            get { return addressId; }
            set
            {
                if (addressId != value)
                {
                    addressId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string provinceName;

        public string ProvinceName
        {
            get { return provinceName; }
            set
            {
                if (provinceName != value)
                {
                    provinceName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged();
                }
            }
        }

        private string area;

        public string Area
        {
            get { return area; }
            set
            {
                if (area != value)
                {
                    area = value;
                    OnPropertyChanged();
                }
            }
        }

        private string detailAddress;

        public string DetailAddress
        {
            get { return detailAddress; }
            set
            {
                if (detailAddress != value)
                {
                    detailAddress = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
