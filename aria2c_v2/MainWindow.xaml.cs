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
using System.Reflection;
using Newtonsoft.Json.Linq;



namespace aria2c_v2
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
   

    public partial class MainWindow : Window
    {
        
        public static string  dir { get; set; }
        public static string split { get; set; }
        public static string diskcache { get; set; }
        public static string maxconcurrentdownloads { get; set; }
        public static string minsplitsize { get; set; }
        public static string maxdownloadlimit { get; set; }
        public static string followtorrent { get; set; }
        public static string btmaxpeers { get; set; }
        public static string enabledht { get; set; }
        public static string seedratio { get; set; }
        public static string continue_ { get; set; }
        public static string bttracker { get; set; }
        public static string config_to_written { get; set; }

        public static string config { get; set; }
        public static string file_allocation { get; set; }
        public static string config_default { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            killaria2();
            loadconfig();
            startaria2();
            loadweb();

        }
        public void loadconfig()
        {
            if (File.Exists("aria2c.conf"))
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
                split = obj["split"].ToString();
                dir = obj["dir"].ToString();
                diskcache = obj["disk-cache"].ToString();
                maxconcurrentdownloads = obj["max-concurrent-downloads"].ToString();
                minsplitsize = obj["min-split-size"].ToString();
                maxdownloadlimit = obj["max-download-limit"].ToString();
                file_allocation = obj["file-allocation"].ToString();
                continue_ = obj["continue"].ToString();
                followtorrent = obj["follow-torrent"].ToString();
                btmaxpeers = obj["bt-max-peers"].ToString();
                enabledht = obj["enable-dht"].ToString();
                seedratio = obj["seed-ratio"].ToString();
                bttracker =  @"http://tracker.prq.to/announce,http://tracker.prq.to/announce.php,http://tracker.publicbt.com/announce,http://tracker.openbittorrent.com:80/announce,http://denis.stalker.h3q.com:6969/announce,udp://tracker.leechers-paradise.org:6969/announce,udp://tracker.pirateparty.gr:6969/announce,udp://tracker.cuntflaps.me:6969/announce,udp://tracker.coppersurfer.tk:6969/announce,udp://tracker.opentrackr.org:1337/announce,http://tracker.opentrackr.org:1337/announce,udp://tracker1.wasabii.com.tw:6969/announce,udp://tracker.zer0day.to:1337/announce,http://p4p.arenabg.com:1337/announce,udp://p4p.arenabg.com:1337/announce,http://tracker.internetwarriors.net:1337/announce,udp://tracker.internetwarriors.net:1337/announce,udp://inferno.demonoid.ooo:3389/announce,udp://explodie.org:6969/announce,udp://bt.xxx-tracker.com:2710/announce,udp://allesanddro.de:1337/announce,udp://9.rarbg.com:2710/announce,udp://tracker.mg64.net:6969/announce,udp://mgtracker.org:6969/announce,udp://ipv4.tracker.harry.lu:80/announce,http://tracker.mg64.net:6881/announce,http://mgtracker.org:6969/announce,http://ipv4.tracker.harry.lu:80/announce,http://retracker.telecom.by:80/announce,http://tracker.devil-torrents.pl:80/announce,http://grifon.info:80/announce,http://tracker1.wasabii.com.tw:6969/announce,http://tracker.grepler.com:6969/announce,http://retracker.mgts.by:80/announce,udp://tracker.grepler.com:6969/announce,http://tracker.tlm-project.org:6969/announce,http://t.nyaatracker.com:80/announce,udp://tracker.vanitycore.co:6969/announce,http://tracker.vanitycore.co:6969/announce,http://tracker.electro-torrent.pl:80/announce,http://bt.artvid.ru:6969/announce,http://agusiq-torrents.pl:6969/announce,udp://tracker.kamigami.org:2710/announce,udp://public.popcorn-tracker.org:6969/announce,http://tracker.torrentyorg.pl:80/announce,udp://tracker.kuroy.me:5944/announce,udp://86.19.29.160:6969/announce,udp://208.67.16.113:8000/announce,http://tracker2.wasabii.com.tw:6969/announce,http://tracker.kuroy.me:5944/announce,http://91.218.230.81:6969/announce,udp://tracker.tiny-vps.com:6969/announce,udp://peerfect.org:6969/announce,udp://tracker.swateam.org.uk:2710/announce,udp://tracker.filetracker.pl:8089/announce,http://tracker.filetracker.pl:8089/announce,udp://zephir.monocul.us:6969/announce,udp://z.crazyhd.com:2710/announce,udp://tracker.halfchub.club:6969/announce,udp://tracker.christianbro.pw:6969/announce,udp://tracker2.wasabii.com.tw:6969/announce,udp://tracker2.christianbro.pw:6969/announce,udp://tracker.torrent.eu.org:451/announce,udp://tracker.files.fm:6969/announce,udp://tracker.edoardocolombo.eu:6969/announce,udp://tracker.doko.moe:6969/announce,udp://tracker.desu.sh:6969/announce,udp://tracker.cypherpunks.ru:6969/announce,udp://oscar.reyesleon.xyz:6969/announce,udp://open.stealth.si:80/announce,udp://open.facedatabg.net:6969/announce,http://fxtt.ru:80/announce,udp://tracker.cyberia.is:6969/announce,udp://thetracker.org:80/announce,http://torrentsmd.com:8080/announce,udp://tracker.skyts.net:6969/announce,udp://tracker.safe.moe:6969/announce,udp://tracker.piratepublic.com:1337/announce,udp://tracker.bluefrog.pw:2710/announce,udp://tracker.baravik.org:6970/announce,udp://tr.cili001.com:6666/announce,udp://retracker.lanta-net.ru:2710/announce,http://tracker2.itzmx.com:6961/announce,http://open.acgtracker.com:1096/announce,udp://tracker.justseed.it:1337/announce,http://tracker.tfile.me:80/announce,http://share.camoe.cn:8080/announce,http://retracker.omsk.ru:2710/announce,http://explodie.org:6969/announce";


                //config = "--dir=" + dir + "--split=" + split + "--disk-cache=" + diskcache + "--max-concurrent-downloads=" + maxconcurrentdownloads +
                //    "--min-split-size=" + minsplitsize + "--max-download-limit=" + maxdownloadlimit + "--file-allocation=" + file_allocation +
                //    "--continue=" + continue_ + "--follow-torrent=" + followtorrent + "--bt-max-peers=" + btmaxpeers + "--enable-dht=" + enabledht +
                //    "--seed-ratio=" + seedratio + "--bt-tracker=" + bttracker;

                config = "  --dir=" + dir + " " + "--split=" + split + " " + "--disk-cache=" + diskcache + " " + "--max-concurrent-downloads=" + maxconcurrentdownloads +
                         " " + "--min-split-size=" + minsplitsize + " " + "--max-download-limit=" + maxdownloadlimit + " " + "--file-allocation=" + file_allocation +
                         " " + "--continue=" + continue_ + " " + "--follow-torrent=" + followtorrent + " " + "--bt-max-peers=" + btmaxpeers + " " + "--enable-dht=" + enabledht +
                         " " + "--seed-ratio=" + seedratio; //+ " " + "--bt-tracker=" + bttracker;



            }
            else
            {
                File.Create("aria2c.conf").Close();

                split = "160";
                dir = @"D:\Download";
                diskcache = "32M";
                maxconcurrentdownloads = "3";
                minsplitsize = "2M";
                maxdownloadlimit = "0";
                file_allocation = "falloc";
                continue_ = "true";
                followtorrent = "true";
                btmaxpeers = "64";
                enabledht = "true";
                seedratio = "1";
                bttracker = @"http://tracker.prq.to/announce,http://tracker.prq.to/announce.php,http://tracker.publicbt.com/announce,http://tracker.openbittorrent.com:80/announce,http://denis.stalker.h3q.com:6969/announce,udp://tracker.leechers-paradise.org:6969/announce,udp://tracker.pirateparty.gr:6969/announce,udp://tracker.cuntflaps.me:6969/announce,udp://tracker.coppersurfer.tk:6969/announce,udp://tracker.opentrackr.org:1337/announce,http://tracker.opentrackr.org:1337/announce,udp://tracker1.wasabii.com.tw:6969/announce,udp://tracker.zer0day.to:1337/announce,http://p4p.arenabg.com:1337/announce,udp://p4p.arenabg.com:1337/announce,http://tracker.internetwarriors.net:1337/announce,udp://tracker.internetwarriors.net:1337/announce,udp://inferno.demonoid.ooo:3389/announce,udp://explodie.org:6969/announce,udp://bt.xxx-tracker.com:2710/announce,udp://allesanddro.de:1337/announce,udp://9.rarbg.com:2710/announce,udp://tracker.mg64.net:6969/announce,udp://mgtracker.org:6969/announce,udp://ipv4.tracker.harry.lu:80/announce,http://tracker.mg64.net:6881/announce,http://mgtracker.org:6969/announce,http://ipv4.tracker.harry.lu:80/announce,http://retracker.telecom.by:80/announce,http://tracker.devil-torrents.pl:80/announce,http://grifon.info:80/announce,http://tracker1.wasabii.com.tw:6969/announce,http://tracker.grepler.com:6969/announce,http://retracker.mgts.by:80/announce,udp://tracker.grepler.com:6969/announce,http://tracker.tlm-project.org:6969/announce,http://t.nyaatracker.com:80/announce,udp://tracker.vanitycore.co:6969/announce,http://tracker.vanitycore.co:6969/announce,http://tracker.electro-torrent.pl:80/announce,http://bt.artvid.ru:6969/announce,http://agusiq-torrents.pl:6969/announce,udp://tracker.kamigami.org:2710/announce,udp://public.popcorn-tracker.org:6969/announce,http://tracker.torrentyorg.pl:80/announce,udp://tracker.kuroy.me:5944/announce,udp://86.19.29.160:6969/announce,udp://208.67.16.113:8000/announce,http://tracker2.wasabii.com.tw:6969/announce,http://tracker.kuroy.me:5944/announce,http://91.218.230.81:6969/announce,udp://tracker.tiny-vps.com:6969/announce,udp://peerfect.org:6969/announce,udp://tracker.swateam.org.uk:2710/announce,udp://tracker.filetracker.pl:8089/announce,http://tracker.filetracker.pl:8089/announce,udp://zephir.monocul.us:6969/announce,udp://z.crazyhd.com:2710/announce,udp://tracker.halfchub.club:6969/announce,udp://tracker.christianbro.pw:6969/announce,udp://tracker2.wasabii.com.tw:6969/announce,udp://tracker2.christianbro.pw:6969/announce,udp://tracker.torrent.eu.org:451/announce,udp://tracker.files.fm:6969/announce,udp://tracker.edoardocolombo.eu:6969/announce,udp://tracker.doko.moe:6969/announce,udp://tracker.desu.sh:6969/announce,udp://tracker.cypherpunks.ru:6969/announce,udp://oscar.reyesleon.xyz:6969/announce,udp://open.stealth.si:80/announce,udp://open.facedatabg.net:6969/announce,http://fxtt.ru:80/announce,udp://tracker.cyberia.is:6969/announce,udp://thetracker.org:80/announce,http://torrentsmd.com:8080/announce,udp://tracker.skyts.net:6969/announce,udp://tracker.safe.moe:6969/announce,udp://tracker.piratepublic.com:1337/announce,udp://tracker.bluefrog.pw:2710/announce,udp://tracker.baravik.org:6970/announce,udp://tr.cili001.com:6666/announce,udp://retracker.lanta-net.ru:2710/announce,http://tracker2.itzmx.com:6961/announce,http://open.acgtracker.com:1096/announce,udp://tracker.justseed.it:1337/announce,http://tracker.tfile.me:80/announce,http://share.camoe.cn:8080/announce,http://retracker.omsk.ru:2710/announce,http://explodie.org:6969/announce";

                config = "  --dir=" + dir + " " + "--split=" + split + " " + "--disk-cache=" + diskcache + " " + "--max-concurrent-downloads=" + maxconcurrentdownloads +
                    " " + "--min-split-size=" + minsplitsize + " " + "--max-download-limit=" + maxdownloadlimit + " " + "--file-allocation=" + file_allocation +
                   " " + "--continue=" + continue_ + " " + "--follow-torrent=" + followtorrent + " " + "--bt-max-peers=" + btmaxpeers + " " + "--enable-dht=" + enabledht +
                    " " + "--seed-ratio=" + seedratio; //+ " " + "--bt-tracker=" + bttracker;

                config_to_written = "{dir:" + dir + ",split:" + split + ",disk-cache:" + diskcache + ",max-concurrent-downloads:" +
                                    maxconcurrentdownloads + ",max-download-limit:" + maxdownloadlimit + ",min-split-size:" + minsplitsize + ",file-allocation:" +
                                    file_allocation + ",follow-torrent:" + followtorrent + ",enable-dht:" + enabledht + ",seed-ratio:" +
                                    seedratio + ",continue:" + continue_ + ",bt-max-peers:" + btmaxpeers + "}";

                config_to_written = config_to_written.Replace("{", "{\"");
                config_to_written = config_to_written.Replace("}", "\"}");
                config_to_written = config_to_written.Replace(":", "\":\"");
                config_to_written = config_to_written.Replace(",", "\",\"");
                config_to_written = config_to_written.Replace("\":\"\\", ":\\\\");

                loggingconfig(config_to_written);


            }
        }

        public void loadweb()
        {   

            //本地文件
            
            web.Navigate("file:///" + Environment.CurrentDirectory + @"\web_cn\index.html");
            //web-UI
            //web.Navigate("http://aria2c.b2cn.tk/");
            //web.Navigate("http://aria2c.com/");
            //web.Navigate("http://ariang.mayswind.net/");

        }



        //aria2c.exe start
        public void startaria2()
        {
            string aria2path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"aria2c.exe");

            config_default = "--enable-rpc=true --console-log-level=error --rpc-allow-origin-all=true --rpc-listen-port=6800 --save-session-interval=60  --input-file=aria2c.session --save-session=aria2c.session ";

            if (!File.Exists("aria2c.exe"))
            {
                MessageBox.Show("当前目录缺少aria2c.exe");
            }

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
        public void killaria2()
        {
            Process[] myProgress;
            myProgress = Process.GetProcesses();　　　　　　　　　　//获取当前启动的所有进程
            foreach (Process p in myProgress)　　　　　　　　　　　　
            {
                if (p.ProcessName == "aria2c")　　　　　　　　　　//通过进程名来寻找
                {
                    p.Kill();
                    return;
                }
            }
        }
        public void kill_all_aria2()
        {
            Process[] myProgress;
            myProgress = Process.GetProcesses();　　　　　　　　　　//获取当前启动的所有进程
            foreach (Process p in myProgress)
            {
                if (p.ProcessName == "aria2c")　　　　　　　　　　//通过进程名来寻找
                {
                    p.Kill();
                    //continue;
                }
            }
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
            killaria2();
            this.Close();
            
        }
        public static bool? restart { get; set; }
        private void settingbutton_Click(object sender, RoutedEventArgs e)
        {
            restart = false;
            Setwindow setwin = new Setwindow();
            setwin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            setwin.ShowDialog();
            
            if (restart == true)
            {
                killaria2();
                loadconfig();
                startaria2();
                loadweb();
            }
        }

        private void aboutbutton_Click(object sender, RoutedEventArgs e)
        {
            Aboutwindow aboutwin = new Aboutwindow();
            aboutwin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            aboutwin.ShowDialog();
        }

        private void openbutton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe ", dir);
        }

        private void refreshbutton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("aria2c.conf"))
            {
                File.Delete("aria2c.conf");
            }
            if (File.Exists("aria2c.session"))
            {
                File.Delete("aria2c.conf");
            }
            killaria2();
            loadconfig();
            startaria2();
            loadweb();
        }
    }
}
