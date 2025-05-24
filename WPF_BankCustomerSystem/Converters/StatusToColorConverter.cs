using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_BankCustomerSystem.Converters
{
    
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new SolidColorBrush(Colors.Black);

            bool success = int.TryParse(value.ToString(), out int status);
            if (!success) return new SolidColorBrush(Colors.Black);

            return status == 1 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);  // 数据状态为0表示正常，1表示删除，删除的数据标记红色
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
}
