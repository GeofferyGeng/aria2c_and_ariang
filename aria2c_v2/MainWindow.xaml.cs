using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace aria2c_v2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startaria2();
            loadweb();
        }
        public void loadweb()
        {
            web.Navigate("file:///" + Environment.CurrentDirectory + @"\web\index.html");
            

        }

        //aria2c.exe start
        public void startaria2()
        {
            string aria2path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"aria2c.exe");
            string config = "--enable-rpc --console-log-level=error --rpc-allow-origin-all=true --rpc-listen-port=6800 --split=256 --save-session-interval=60 --max-concurrent-downloads=5 --input-file=aria2.session --save-session=aria2.session";

            if (!File.Exists("aria2.session"))
            {
                File.Create("aria2.session").Close();
            }
            if (File.Exists(aria2path))
            {
                Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = aria2path;
                p.StartInfo.Arguments = config;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
        }
        //close process aria2
        public void killaria2()
        {
            Process[] myProgress;
            myProgress = Process.GetProcesses();　　　　　　　　　　//获取当前启动的所有进程
            foreach (Process p in myProgress)　　　　　　　　　　　　//关闭当前启动的Excel进程
            {
                if (p.ProcessName == "aria2c")　　　　　　　　　　//通过进程名来寻找
                {
                    p.Kill();
                    return;
                }
            }
        }



        /// <summary>
        /// 窗口移动事件
        /// </summary>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            killaria2();
        }

        private void settingbutton_Click(object sender, RoutedEventArgs e)
        {
            Setwindow setwin = new Setwindow();
            setwin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            setwin.ShowDialog();
        }

        private void aboutbutton_Click(object sender, RoutedEventArgs e)
        {
            Aboutwindow aboutwin = new Aboutwindow();
            aboutwin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            aboutwin.ShowDialog();
        }
    }
}
