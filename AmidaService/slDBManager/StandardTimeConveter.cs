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
using System.ServiceModel.DomainServices.Client;

namespace slDBManager
{
    public class StandardTimeConveter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           // throw new NotImplementedException();
            
            DateTime dt = System.Convert.ToDateTime(value);
            if (dt == DateTime.MinValue)
                return "NA";
            return string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}",dt.Year,dt.Month,dt.Day,dt.Hour,dt.Minute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EntityStateToReadOnlyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            EntityState state =( EntityState) value   ;
            if (state == EntityState.New)
                return false;
            else
                return true;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReadOnlyToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? new SolidColorBrush(Colors.Brown) : new SolidColorBrush(Colors.Black);
           // throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   

}
