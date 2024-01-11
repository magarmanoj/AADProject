using AAD.ImmoWin.Data.Enumerations;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AAD.ImmoWin.Data.Converter
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = 0;
            foreach (Huistype item in Enum.GetValues(typeof(Huistype)))
            {
                if (item == (Huistype)value)
                    break;
                ++index;
            }
            return Enums.GetDescriptions<Huistype>()[index];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetValues(typeof(Huistype)).GetValue(Enums.GetDescriptions<Huistype>().IndexOf(value.ToString()));
        }
    }
}
