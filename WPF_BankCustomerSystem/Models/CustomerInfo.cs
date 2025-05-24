using System;
using SqlSugar;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Models
{
    public class CustomerInfo : ModelBase
    {
        private int customerId;
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]

        public int CustomerId
        {
            get { return customerId; }
            set
            {
                if (customerId != value)
                {
                    customerId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool sex;

        public bool Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    sex = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    OnPropertyChanged();
                }
            }
        }


        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged();
                }
            }
        }

        private int addressId;
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
    }
}
