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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace aria2c_v2
{
    /// <summary>
    /// Setwindow.xaml 的交互逻辑
    /// </summary>
    public partial class Setwindow : Window
    {
        public string config_to_be_wrriten { get; set; }
        public string config { get; set; }
        public Setwindow()
        {
            InitializeComponent();
            loadset();

        }


        //load set from config
        public void loadset()
        {
            string path = System.Environment.CurrentDirectory;
            path = System.IO.Path.Combine(path, "aria2c.conf");
            //MessageBox.Show(path);
            FileInfo fi = new FileInfo(path);
            long len = fi.Length;
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();
            string raw = Encoding.ASCII.GetString(buffer);// Encoding.Unicode.GetString(buffer);

            var obj = JObject.Parse(raw);
            t_split.Text = obj["split"].ToString();
            t_dir.Text = obj["dir"].ToString();
            t_diskcache.Text = obj["disk-cache"].ToString();
            t_maxconcurrentdownloads.Text = obj["max-concurrent-downloads"].ToString();
            t_minsplitsize.Text = obj["min-split-size"].ToString();
            t_maxdownloadlimit.Text = obj["max-download-limit"].ToString();
            t_fileallocation.Text = obj["file-allocation"].ToString();
            t_continue.Text = obj["continue"].ToString();
            t_followtorrent.Text = obj["follow-torrent"].ToString();
            t_btmaxpeers.Text = obj["bt-max-peers"].ToString();
            t_enabledht.Text = obj["enable-dht"].ToString();
            t_seedratio.Text = obj["seed-ratio"].ToString();

        }

        public void changeconfig()
        {
            //MainWindow m = new MainWindow();
            MainWindow.split = t_split.Text;
            MainWindow.dir = t_dir.Text;
            MainWindow.diskcache = t_diskcache.Text;
            MainWindow.maxconcurrentdownloads = t_maxconcurrentdownloads.Text;
            MainWindow.maxdownloadlimit = t_maxdownloadlimit.Text;
            MainWindow.minsplitsize = t_minsplitsize.Text;
            MainWindow.file_allocation = t_fileallocation.Text;
            MainWindow.followtorrent = t_followtorrent.Text;
            MainWindow.enabledht = t_enabledht.Text;
            MainWindow.seedratio = t_seedratio.Text;
            MainWindow.continue_ = t_continue.Text;
            MainWindow.btmaxpeers = t_btmaxpeers.Text;


            config_to_be_wrriten = "{dir:" + MainWindow.dir + ",split:" + MainWindow.split + ",disk-cache:" + MainWindow.diskcache + ",max-concurrent-downloads:" +
                MainWindow.maxconcurrentdownloads + ",max-download-limit:" + MainWindow.maxdownloadlimit + ",min-split-size:" + MainWindow.minsplitsize + ",file-allocation:" +
                MainWindow.file_allocation + ",follow-torrent:" + MainWindow.followtorrent + ",enable-dht:" + MainWindow.enabledht + ",seed-ratio:" +
                MainWindow.seedratio + ",continue:" + MainWindow.continue_ + ",bt-max-peers:" + MainWindow.btmaxpeers + "}";

            config_to_be_wrriten = config_to_be_wrriten.Replace("{","{\"");
            config_to_be_wrriten = config_to_be_wrriten.Replace("}", "\"}");
            config_to_be_wrriten = config_to_be_wrriten.Replace(":", "\":\"");
            config_to_be_wrriten = config_to_be_wrriten.Replace(",", "\",\"");
            config_to_be_wrriten = config_to_be_wrriten.Replace("\":\"\\", ":\\\\");

            loggingconfig(config_to_be_wrriten);

            config = "  --dir=" + MainWindow.dir + " " + "--split=" + MainWindow.split + " " + "--disk-cache=" + MainWindow.diskcache + " " + "--max-concurrent-downloads=" + MainWindow.maxconcurrentdownloads +
                     " " + "--min-split-size=" + MainWindow.minsplitsize + " " + "--max-download-limit=" + MainWindow.maxdownloadlimit + " " + "--file-allocation=" + MainWindow.file_allocation +
                     " " + "--continue=" + MainWindow.continue_ + " " + "--follow-torrent=" + MainWindow.followtorrent + " " + "--bt-max-peers=" + MainWindow.btmaxpeers + " " + "--enable-dht=" + MainWindow.enabledht +
                     " " + "--seed-ratio=" + MainWindow.seedratio; //+ " " + "--bt-tracker=" + bttracker;


        }


        public void loggingconfig(string text)
        {

            try
            {
                string path = System.Environment.CurrentDirectory;

                if (File.Exists("aria2c.conf"))
                {
                    File.Delete("aria2c.conf");
                    File.Create("aria2c.conf").Close();
                }

                using (
                    var outfile =
                        new StreamWriter(System.IO.Path.Combine(path, "aria2c.conf"), true)
                )
                {
                    outfile.WriteLine(text);
                }

            }
            catch (Exception)
            {
                // ignored
            }

        }



        public void startaria2()
        {   

            string aria2path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"aria2c.exe");
            string config_default = "--enable-rpc=true --console-log-level=error --rpc-allow-origin-all=true --rpc-listen-port=6800 --save-session-interval=60  --input-file=aria2c.session --save-session=aria2c.session";

            if (!File.Exists("aria2c.session"))
            {
                File.Create("aria2c.session").Close();
            }
            if (File.Exists(aria2path))
            {
                Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = aria2path;
                p.StartInfo.Arguments = config_default + config;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
        }
        //close process aria2
        public void kill_one_aria2()
        {
            int a = 1;
            Process[] myProgress;
            myProgress = Process.GetProcesses();　　　　　　　　　　//获取当前启动的所有进程
            foreach (Process p in myProgress)
            {
                if (p.ProcessName == "aria2c")　　　　　　　　　　//通过进程名来寻找
                {
                    a = a - 1;
                    if (a == 0)
                    {
                        p.Kill();
                        return;
                    }
                  
                }
            }
        }
        public void killaria2()
        {

            Process[] myProgress;
            myProgress = Process.GetProcesses();　　　　　　　　　　//获取当前启动的所有进程
            foreach (Process p in myProgress)
            {
                if (p.ProcessName == "aria2c")　　　　　　　　　　//通过进程名来寻找
                {
                    p.Kill();
                    break;
                }
            }
        }


        private void set_ok_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r1 = System.Windows.MessageBox.Show("是否立即应用新的设置?立即应用设置可能导致当前正在进行的任务暂停，重新开始。点否将在下一次启动时应用。", "立即生效？",MessageBoxButton.YesNoCancel);

            if (r1 == System.Windows.MessageBoxResult.Yes)
            {
                System.Windows.MessageBox.Show("Aria2c配置已更新！","Aria2c配置",System.Windows.MessageBoxButton.OK);
                changeconfig();
                MainWindow.restart = true;
                this.Close();
                
            }
            else if (r1 == System.Windows.MessageBoxResult.No)
            {
                System.Windows.MessageBox.Show("Aria2c配置将于下次启动时更新！", "Aria2c配置", System.Windows.MessageBoxButton.OK);
                changeconfig();
                MainWindow.restart = false;
                this.Close();

            }
            else
            {
                MainWindow.restart = null;
                //reture;
            }
            
        }

        private void set_cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r2 = System.Windows.MessageBox.Show("离开并放弃所有更改？","关闭设置",MessageBoxButton.OKCancel);
            if (r2 == MessageBoxResult.OK)
            {
                this.Close();
            }
            else
            {
                //reture
            }
        }













        /// <summary>
        /// 窗口移动事件
        /// </summary>
        private void TitleBar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
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

        }

        private void file_path_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            DialogResult result = m_Dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string m_Dir = m_Dialog.SelectedPath.Trim();
            t_dir.Text = m_Dir;
            t_dir.ToolTip = m_Dir;
        }

    }
}
