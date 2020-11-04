using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace testGadget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            
            this.Left = 
                SystemParameters.VirtualScreenWidth - 1000;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Func);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            Image img = new Image();
            string dir = "file://" + Directory.GetCurrentDirectory() + "\\check.png";
            img.Source = new BitmapImage(new Uri(dir));
            img.Width = 35;
            img.Height = 35;
            btnClose.Content = img;
            btnClose.BorderBrush = null;
        }
        void Func(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string h = (time.Hour < 10)? "0"+time.Hour:""+time.Hour;
            string m = (time.Minute < 10)? "0"+time.Minute:""+time.Minute;
            string s = (time.Second < 10)? "0"+time.Second:""+time.Second;
            string str_time = h + ":" + m + ":" + s;
            txtBlock.Text = str_time;
            txtBlock_shawdow.Text = str_time;
        }      

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bye bye");
            Application.Current.Shutdown();
        }
    }
}
