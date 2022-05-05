using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CanvasTest
{
    class ImagePixelColor : Image
    {
        private static readonly DependencyProperty CurrentColorProperty =
            DependencyProperty.Register("CurrentColor", typeof(Color), typeof(ImagePixelColor),
             new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public Color CurrentColor
        {
            get
            {
                return (Color)GetValue(CurrentColorProperty);
            }
        }

        byte[] Pixels = new byte[4];

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            SetValue(CurrentColorProperty, GetPixelColor(e.GetPosition(this)));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
            {
                SetValue(CurrentColorProperty, GetPixelColor(e.GetPosition(this)));
            }
        }

        public void GetColor(Point pos)
        {
        }


        private Color GetPixelColor(Point CurrentPoint)
        {
            BitmapSource CurrentSource = this.Source as BitmapSource;

            // 비트맵 내의 좌표 값 계산
            CurrentPoint.X *= CurrentSource.PixelWidth / this.ActualWidth;
            CurrentPoint.Y *= CurrentSource.PixelHeight / this.ActualHeight;

            if (CurrentSource.Format == PixelFormats.Bgra32 || CurrentSource.Format == PixelFormats.Bgr32)
            {
                // 32bit stride = (width * bpp + 7) /8
                int Stride = (CurrentSource.PixelWidth * CurrentSource.Format.BitsPerPixel + 7) / 8;
                // 한 픽셀 복사
                CurrentSource.CopyPixels(new Int32Rect((int)CurrentPoint.X, (int)CurrentPoint.Y, 1, 1), Pixels, Stride, 0);

                // 컬러로 변환 후 리턴
                return Color.FromArgb(Pixels[3], Pixels[2], Pixels[1], Pixels[0]);
            }
            else
            {
            }
            // TODO: 다른 포맷 형식 추가

            return Color.FromArgb(Pixels[3], Pixels[2], Pixels[1], Pixels[0]);
        }
    }
}
