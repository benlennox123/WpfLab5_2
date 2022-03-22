using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace WpfLab5_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (inkImage != null)
            {
            inkImage.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (inkImage != null)
            {
                inkImage.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (inkImage != null)
            {
                inkImage.DefaultDrawingAttributes.Color = Colors.Black;
            }
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            if (inkImage != null)
            {
                inkImage.DefaultDrawingAttributes.Color = Colors.Red;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Графические файлы (*.gif)|*.gif|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                inkImage.Background = imageBrush;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string imgPath = "file.gif";
            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream(imgPath, FileMode.Create);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkImage.ActualWidth, (int)inkImage.ActualHeight, 96, 96, PixelFormats.Default);
            rtb.Render(inkImage);
            GifBitmapEncoder gifEnc = new GifBitmapEncoder();
            gifEnc.Frames.Add(BitmapFrame.Create(rtb));
            gifEnc.Save(fs);
            fs.Close();
            MessageBox.Show("Готово!");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
