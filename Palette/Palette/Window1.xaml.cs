using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Palette
{      
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void FileOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();

            if (Dialog.ShowDialog() == true)
            {
                Palette.Source = new BitmapImage(new Uri(Dialog.FileName));
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Memo_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Memo.EditingMode == System.Windows.Controls.InkCanvasEditingMode.Ink)
            {
                Memo.EditingMode = System.Windows.Controls.InkCanvasEditingMode.EraseByPoint;
            }
            else
            {
                Memo.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Ink;
            }
        }
    }

    [ValueConversion(typeof(Color), typeof(Brush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(Color), typeof(DrawingAttributes))]
    public class InkColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DrawingAttributes attribute = new DrawingAttributes();
            attribute.Color = (Color)value;
            return attribute;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
