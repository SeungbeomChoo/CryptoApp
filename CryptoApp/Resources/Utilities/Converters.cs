using CryptoApp.Models;
using System.Globalization;

namespace CryptoApp.Resources.Utilities
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleval = (double)value;

            if (doubleval > 0)
                return Color.FromArgb("#46eb34");
            return Color.FromArgb("#f50202");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class PercentageStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleval = Math.Round((double)value, 2);
            return doubleval.ToString() + '%';
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class MarketCapStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleval = ((double)value);
            var billion = 1000000000;
            var million = 1000000;

            if (doubleval > billion)
            {
                var val = Math.Round((((double)value) / billion), 2);
                return "$" + val.ToString() + "B";
            }
            else
            {
                var intval = (int)(((double)value) / million);
                return "$" + intval.ToString() + "M";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class PriceStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleval = (double)value;
            if (doubleval > 1)
                doubleval = Math.Round(doubleval, 2);
            else
                doubleval = Math.Round(doubleval, 6);
            return "$" + doubleval.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class RankStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "#" + ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            return $"{date.ToString("MMMM dd, yyyy")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
