using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace CanvasTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\이재헌\Documents\제혁.png";
        int Size_X = 593;
        int Size_Y = 404;
        int Size_R = 30;
        int Count_X;
        int Count_Y;
        
        Ellipse[,] ellipse;

        public MainWindow()
        {
            InitializeComponent();
            ellipse = new Ellipse[Size_X / Size_R, Size_Y / Size_R];
            Count_X = (int)(Size_X / Size_R);
            Count_Y = (int)(Size_Y / Size_R);
        }

        void toCircle(Bitmap bitmap)
        {
            int Charge = 0;
            int Max_Charge = Count_X * Count_Y;
            int[] amountRGB = new int[] { 0, 0, 0 };
            //Count_X,Y는 이미지의 가로와 세로길이를 묶을 픽셀로 나눈값
            for (int i = 0; i < Count_Y; i++)
            {
                for (int j = 0; j < Count_X; j++)
                {
                    int _x = (j * Size_R);
                    int _y = (i * Size_R);

                    //RGB
                    int _r = 0;//Red
                    int _g = 0;//Greem
                    int _b = 0;//Blue

                    //n×n안에 있는 픽셀들의 RGB의 합계
                    for (int p = 0; p < Size_R; p++)
                    {
                        for (int q = 0; q < Size_R; q++)
                        {
                            Color _c = bitmap.GetPixel(_x + p, _y + q);
                            _r += _c.R;
                            _g += _c.G;
                            _b += _c.B;
                        }
                    }

                    amountRGB[0] += _r;
                    amountRGB[1] += _g;
                    amountRGB[2] += _b;

                    //n×n의 RGB 평균
                    int divid = Size_R * Size_R;
                    _r = _r / divid;
                    _g = _g / divid;
                    _b = _b / divid;

                    //255초과시 보정
                    if (_r > 255)
                    {
                        _r = 255;
                    }
                    if (_g > 255)
                    {
                        _g = 255;
                    }
                    if (_b > 255)
                    {
                        _b = 255;
                    }
                    try//RGB 평균으로 픽셀 생성
                    {
                        ellipse[j, i] = new Ellipse();
                        try
                        {
                            ellipse[j, i].Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, (byte)_r, (byte)_g, (byte)_b));
                        }
                        catch
                        {
                            ellipse[j, i].Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                        }
                        ellipse[j, i].Width = Size_R;
                        ellipse[j, i].Height = Size_R;
                        ellipse[j, i].VerticalAlignment = VerticalAlignment.Top;
                        ellipse[j, i].HorizontalAlignment = HorizontalAlignment.Left;
                        ellipse[j, i].Margin = new Thickness(j * Size_R, i * Size_R, 0, 0);
                        MainGrid.Children.Add(ellipse[j, i]);
                        Console.WriteLine($"element[{j},{i}] = RGB({_r},{_g},{_b}) Pos({i * Size_R},{j * Size_R})\t [{Charge}/{Max_Charge}]");
                    }
                    catch
                    {
                        Console.WriteLine($"element[{j},{i}] = Error");
                    }
                    Charge++;
                }
            }
            try
            {
                byte[] resultRGB = new byte[] { 0, 0, 0 };
                resultRGB[0] = (byte)(amountRGB[0] / Max_Charge);
                resultRGB[1] = (byte)(amountRGB[1] / Max_Charge);
                resultRGB[2] = (byte)(amountRGB[2] / Max_Charge);
                BGColorRect.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, resultRGB[0], resultRGB[1], resultRGB[2]));
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bitmap img = new Bitmap(path);
            
                int s_x = img.Width;
                int s_y = img.Height;
                if (s_x > 1000)
                {
                    s_x = 1000;
                }
                if (s_y > 1000)
                {
                    s_y = 1000;
                }

                Width = img.Width;
                Height = img.Height + 50;
                Size_X = (int)img.Width;
                Size_Y = (int)img.Height;
           

                MainGrid.Children.Clear();
                Size_R = Convert.ToInt32(Size_Box.Text);
                Count_X = (int)(Size_X / Size_R);
                Count_Y = (int)(Size_Y / Size_R);
                ellipse = new Ellipse[Count_X, Count_Y];
                Console.WriteLine($"Start : Count({Count_X},{Count_Y})");
                toCircle(img);
                Console.WriteLine("Finish");
            }
            catch
            {
                Log_Box.Text = "사진 이름이 맞는지 확인해주세요.";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            path = path_tb.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //path_tb.Text = path;
        }
    }
}
