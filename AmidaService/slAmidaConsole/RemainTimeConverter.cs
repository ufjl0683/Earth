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

namespace slAmidaConsole
{
    public class RemainTimeConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value==null)
                return "NA";
            int rmin = System.Convert.ToInt32(value);
            if (rmin <= 0)
                return "NA";
            int day, hour, min;
            day = rmin / (24 * 60);
            rmin %= 24 * 60;
            hour = rmin / 60;
            rmin = rmin % 60;
            min = rmin % 60;
            return (day > 0 ? day + "d" : "") + (hour > 0 ? hour + "h" : "") + (min > 0 ? min + "m" : "");


            
           // throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
