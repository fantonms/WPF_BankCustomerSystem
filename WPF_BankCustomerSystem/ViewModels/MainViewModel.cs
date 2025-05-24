using System;
using System.Timers;
using System.Windows;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        Timer timer = new Timer(1000);
        public MainViewModel()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string currentTime = DateTime.Now.ToString("yy-MM-dd HH-mm-ss");

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged();
                }
            }
        }



        private string currentUser = LoginInfo.CurrentUser.Account;

        public string CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnPropertyChanged();
                }
            }
        }

        private string currentPage = "Pages/UserList.Xaml";

        public string CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged();
                }
            }
        }


        public RelayCommand OpenPageCommand
        {
            get
            {
                return new RelayCommand((page) =>
                {
                    CurrentPage = page.ToString();
                });
            }
        }

        public RelayCommand UnLoadedCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    timer.Stop();
                    Application.Current.Shutdown();
                });
            }
        }


    }
}
