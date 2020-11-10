using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        List<Brush> br = new List<Brush>();
        static int indexOfColor = 0;
        static string regState;
        const int NUM_OF_COLOR = 7;
        public MainWindow()
        {
            string[] checkReg = File.ReadAllLines("RunOnStartupState.csv");
            //regState = checkReg[0];
            //if (regState.Equals("0"))
            //{
            //    InstallMeOnStartUp();
            //    File.WriteAllText("RunOnStartupState.csv", "1");
            //}
            indexOfColor = int.Parse(checkReg[1]);

            InitializeComponent();

            br.Add(Brushes.Red);
            br.Add(Brushes.White);
            br.Add(Brushes.Orange);
            br.Add(Brushes.Yellow);
            br.Add(Brushes.Pink);
            br.Add(Brushes.Blue);
            br.Add(Brushes.Gold);
            txtBlock.Foreground = br.ElementAt(indexOfColor);

            this.Left = SystemParameters.VirtualScreenWidth - 1000;

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
            //SetBottom(this);
        }
        //private void InstallMeOnStartUp()
        //{
        //    try
        //    {
        //        //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
        //        RegistryKey key =
        //            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        //        Assembly curAssembly = Assembly.GetExecutingAssembly();
        //        key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
        //    }
        //    catch
        //    {
        //        //do nothing
        //        MessageBox.Show("err");
        //    }
        //}
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

        private void btn_color_Click(object sender, RoutedEventArgs e)
        {
            indexOfColor = (indexOfColor + 1) % NUM_OF_COLOR;
            txtBlock.Foreground = br.ElementAt(indexOfColor);
            File.WriteAllText("RunOnStartupState.csv", regState + "\n" + indexOfColor);
        }
        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);

        //    Opacity = 1;
        //}

        //protected override void OnDeactivated(EventArgs e)
        //{
        //    base.OnDeactivated(e);

        //    Opacity = 0;
        //}


   //     [DllImport("user32.dll")]
   //     static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
   //int Y, int cx, int cy, uint uFlags);

   //     const UInt32 SWP_NOSIZE = 0x0001;
   //     const UInt32 SWP_NOMOVE = 0x0002;
   //     const UInt32 SWP_NOACTIVATE = 0x0010;

   //     static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

   //     public static void SetBottom(Window window)
   //     {
   //         IntPtr hWnd = new WindowInteropHelper(window).Handle;
   //         SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
   //     }

        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //[DllImport("user32.dll", SetLastError = true)]
        //static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //public static void SetOnDesktop(Window window)
        //{
        //    IntPtr hWnd = new WindowInteropHelper(window).Handle;
        //    IntPtr hWndProgMan = FindWindow("Progman", "Program Manager");
        //    SetParent(hWnd, hWndProgMan);
        //}
    }
}
