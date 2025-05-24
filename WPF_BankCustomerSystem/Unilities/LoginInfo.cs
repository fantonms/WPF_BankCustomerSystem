using System;
using WPF_BankCustomerSystem.Models;

namespace WPF_BankCustomerSystem.Unilities
{
    public static class LoginInfo
    {
        public static UserInfo CurrentUser { get; set; }
        public static DateTime CurrentTime { get; set; }
    }
}
