using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using slAmidaConsole.AmidaService;

namespace slAmidaConsole
{
    public class YieldToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            double yield = System.Convert.ToDouble(value);
            //RegisterDeviceInfo info = parameter as RegisterDeviceInfo;
            if (yield == 0)
                return "NA";
            return string.Format("{0:0.0}%", yield);
            
            // throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
