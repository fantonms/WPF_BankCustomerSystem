using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF_BankCustomerSystem.UserControls
{
    /// <summary>
    /// UCPager.xaml 的交互逻辑
    /// </summary>
    public partial class UCPager : UserControl
    {
        public UCPager()
        {
            InitializeComponent();
            cbbPageSize.SelectedIndex = 0;
        }

        public static readonly DependencyProperty PageProperty =
            DependencyProperty.Register("Page", typeof(int), typeof(UCPager), new PropertyMetadata(0));

        public int Page
        {
            get { return (int)GetValue(PageProperty); }
            set
            {
                SetValue(PageProperty, value);
                RaisePageChangedEvent();
                tbPageAndTotakPage.Text = $"{Page}/{TotalPage}";
                txtPage.Text = value.ToString();
                DisableButton();
            }
        }

        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(UCPager), new PropertyMetadata(0));

        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        public static readonly DependencyProperty TotalPageProperty =
            DependencyProperty.Register("TotalPage", typeof(int), typeof(UCPager), new PropertyMetadata(0));

        public int TotalPage
        {
            get { return (int)GetValue(TotalPageProperty); }
            set
            {
                SetValue(TotalPageProperty, value);
                tbPageAndTotakPage.Text = $"{Page}/{TotalPage}";
                DisableButton();
            }
        }

        public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent("PageChanged", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(UCPager));
        public event RoutedEventHandler PageChanged
        {
            add { AddHandler(PageChangedEvent, value); }
            remove { RemoveHandler(PageChangedEvent, value); }
        }
        private void RaisePageChangedEvent()
        {
            RaiseEvent(new RoutedEventArgs(PageChangedEvent));
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1) Page--;

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Page < TotalPage) Page++;
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Page = TotalPage;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtPage.Text, out int page))
            {
                if (page >= 1 && page <= TotalPage)
                {
                    Page = page;
                }
                else
                {
                    MessageBox.Show($"请输入[1,{TotalPage}]范围的值！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入数字！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void txtPage_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$");
        }

        private void cbbPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
            int pageSize = int.Parse(cbItem.Content.ToString().Trim());
            PageSize = pageSize;
            Page = 1;
        }

        private void DisableButton()
        {
            if (Page == 1 && Page != TotalPage)
            {
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = true;
                btnLast.IsEnabled = true;
            }
            else if (Page == TotalPage && Page != 1)
            {
                btnFirst.IsEnabled = true;
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = false;
                btnLast.IsEnabled = false;
            }
            else if (Page > 1 && Page < TotalPage)
            {
                btnFirst.IsEnabled = true;
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = true;
                btnLast.IsEnabled = true;
            }
            else
            {
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = false;
                btnLast.IsEnabled = false;
            }
        }


    }
}
