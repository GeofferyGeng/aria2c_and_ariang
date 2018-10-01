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
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Shell;
using System.Threading;
using System.Windows.Threading;

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
        public static double finish { set; get; }
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("aria2c.session"))
            {
                File.Delete("aria2c.session");
            }
            killaria2();
            loadconfig();
            startaria2();
            loadweb();




            //taskbar process
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.5);   //设置刷新的间隔时间
            timer.Start();
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

                split = "100";
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



        /// <summary>
        /// aria2c.exe start
        /// </summary>
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
        /// <summary>
        /// close process aria2
        /// </summary>
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



        void timer_Tick(object sender, EventArgs e)
        {
            getpage();
        }
        public void write_page(string text)
        {

            try
            {
                string path = System.Environment.CurrentDirectory;

                if (File.Exists("page.txt"))
                {
                    File.Delete("page.txt");
                    File.Create("page.txt").Close();
                }
                using (
                    var outfile =
                        new StreamWriter(System.IO.Path.Combine(path, "page.txt"), true)
                )
                {
                    outfile.WriteLine(text);
                }
            }
            catch (Exception)
            {
                // ignored
                MessageBox.Show("ERROR");
            }
        }
        /// <summary>
        /// 任务栏进度条
        /// </summary>
        public void getpage()
        {

            try
            {
                var doc2 = web.Document as mshtml.HTMLDocument;
                string page = doc2.documentElement.innerHTML;
                page = page.Replace("\"", "'");
                page = page.Replace("-", "_");
                page = page.Replace("(", "<");
                page = page.Replace(")", ">");
                //write_page(page);


                var lname = new List<string>();
                var ls = new List<string>();
                var lp = new List<string>();
                var lt = new List<string>();
                var lsp = new List<string>();

                Regex reg_name = new Regex(@"<span title='(.*?)' class='task-name auto-ellipsis ng-binding' ng-bind='task.taskName'>");
                MatchCollection mc_name = reg_name.Matches(page);
                foreach (Match m in mc_name)
                {
                    string r = m.Groups[1].Value.Trim();
                    //MessageBox.Show(r);
                    lname.Add(r);
                }
                Regex reg_size = new Regex(@"readableVolume'>(.*?)</span> <a title='点击查看任务详情'");
                MatchCollection mc_size = reg_size.Matches(page);
                foreach (Match m in mc_size)
                {
                    string r = m.Groups[1].Value;
                    //MessageBox.Show(r);
                    ls.Add(r);
                }
                Regex reg_p = new Regex(@"'%''>(.*?)</span></div></div>");
                MatchCollection mc_p = reg_p.Matches(page);
                foreach (Match m in mc_p)
                {
                    string r = m.Groups[1].Value.Trim();
                    //MessageBox.Show(r);
                    lp.Add(r);
                }
                Regex reg_t = new Regex(@"translate>> : ''>>'>(.*?)</span> <span class='task_download_speed");
                MatchCollection mc_t = reg_t.Matches(page);
                foreach (Match m in mc_t)
                {
                    string r = m.Groups[1].Value.Trim();
                    //MessageBox.Show(r);
                    lt.Add(r);
                }
                Regex reg_s = new Regex(@"'/s' : '_'> : ''>>'>(.*?)</span>"); //需要去重
                MatchCollection mc_s = reg_s.Matches(page);
                foreach (Match m in mc_s)
                {
                    string r = m.Groups[1].Value.Trim();
                    //MessageBox.Show(r);
                    lsp.Add(r);
                }

                double all = 0; int num = 0;
                while(num < ls.Count)
                {

                    if (ls[num].Contains("GB") == true)
                    {

                        ls[num] = ls[num].Replace('G', ' ');
                        ls[num] = ls[num].Replace('B', ' ');
                        ls[num] = ls[num].Trim();
                        double s = Double.Parse(ls[num]);
                        s = s * 1024 * 1024 * 1024;
                        s = Math.Truncate(s);
                        ls[num] = s.ToString();
                        all = all + s;
                    }
                    else if (ls[num].Contains("MB") == true)
                    {
                        ls[num] = ls[num].Replace('M', ' ');
                        ls[num] = ls[num].Replace('B', ' ');
                        ls[num] = ls[num].Trim();
                        double s = Double.Parse(ls[num]);
                        s = s * 1024 * 1024 * 1024;
                        s = Math.Truncate(s);
                        ls[num] = s.ToString();
                        all = all + s;
                    }
                    else if (ls[num].Contains("KB") == true)
                    {
                        ls[num] = ls[num].Replace('K', ' ');
                        ls[num] = ls[num].Replace('B', ' ');
                        ls[num] = ls[num].Trim();
                        double s = Double.Parse(ls[num]);
                        s = s * 1024 * 1024;
                        s = Math.Truncate(s);
                        ls[num] = s.ToString();
                        all = all + s;
                    }
                    else
                    {
                        ls[num] = ls[num].Replace('B', ' ');
                        ls[num] = ls[num].Trim();
                        double s = Double.Parse(ls[num]);
                        s = Math.Truncate(s);
                        ls[num] = s.ToString();
                        all = all + s;
                    }
                    num = num + 1;
                }

                num = 0;
                while (num < ls.Count)
                {
                    lp[num]= lp[num].Replace('%', ' ');
                    lp[num] = lp[num].Trim();
                    double s = Double.Parse(lp[num]);
                    s = s / 100;
                    lp[num] = s.ToString();
                    num = num + 1;
                }

                double a = 0; int i = 0;
                while(i<ls.Count)
                {
                    a =a + Double.Parse(ls[i]) * Double.Parse(lp[i]);
                    i = i + 1;
                }
                finish = a / all;
                finish = Math.Round(finish, 2);
                //MessageBox.Show(finish.ToString("P"));
                //finish = 0.5;
                taskbar.ProgressState = TaskbarItemProgressState.Normal;
                taskbar.ProgressValue = finish;
                if (finish == 1)
                {

                }
            }
            catch (Exception)
            {
                //
            }
        }




        private void online_page(object sender, RoutedEventArgs e)
        {
            get_online_page();
        }
        public void get_online_page()
        {

            try
            {
                var doc2 = web_test.Document as mshtml.HTMLDocument;
                string page = doc2.documentElement.innerHTML;
                page = page.Replace("\"", "'");
                page = page.Replace("-", "_");
                page = page.Replace("(", "<");
                page = page.Replace(")", ">");
                write_page(page);


                var lname = new List<string>();
                var ls = new List<string>();
                var lp = new List<string>();
                var lt = new List<string>();
                var lsp = new List<string>();

                //Regex reg_name = new Regex(@"<span title='(.*?)' class='task-name auto-ellipsis ng-binding' ng-bind='task.taskName'>");
                //MatchCollection mc_name = reg_name.Matches(page);
                //foreach (Match m in mc_name)
                //{
                //    string r = m.Groups[1].Value.Trim();
                //    //MessageBox.Show(r);
                //    lname.Add(r);
                //}
                //Regex reg_size = new Regex(@"readableVolume'>(.*?)</span> <a title='点击查看任务详情'");
                //MatchCollection mc_size = reg_size.Matches(page);
                //foreach (Match m in mc_size)
                //{
                //    string r = m.Groups[1].Value;
                //    //MessageBox.Show(r);
                //    ls.Add(r);
                //}
                //Regex reg_p = new Regex(@"'%''>(.*?)</span></div></div>");
                //MatchCollection mc_p = reg_p.Matches(page);
                //foreach (Match m in mc_p)
                //{
                //    string r = m.Groups[1].Value.Trim();
                //    //MessageBox.Show(r);
                //    lp.Add(r);
                //}
                //Regex reg_t = new Regex(@"translate>> : ''>>'>(.*?)</span> <span class='task_download_speed");
                //MatchCollection mc_t = reg_t.Matches(page);
                //foreach (Match m in mc_t)
                //{
                //    string r = m.Groups[1].Value.Trim();
                //    //MessageBox.Show(r);
                //    lt.Add(r);
                //}
                //Regex reg_s = new Regex(@"'/s' : '_'> : ''>>'>(.*?)</span>"); //需要去重
                //MatchCollection mc_s = reg_s.Matches(page);
                //foreach (Match m in mc_s)
                //{
                //    string r = m.Groups[1].Value.Trim();
                //    //MessageBox.Show(r);
                //    lsp.Add(r);
                //}

                //double all = 0; int num = 0;
                //while (num < ls.Count)
                //{

                //    if (ls[num].Contains("GB") == true)
                //    {

                //        ls[num] = ls[num].Replace('G', ' ');
                //        ls[num] = ls[num].Replace('B', ' ');
                //        ls[num] = ls[num].Trim();
                //        double s = Double.Parse(ls[num]);
                //        s = s * 1024 * 1024 * 1024;
                //        s = Math.Truncate(s);
                //        ls[num] = s.ToString();
                //        all = all + s;
                //    }
                //    else if (ls[num].Contains("MB") == true)
                //    {
                //        ls[num] = ls[num].Replace('M', ' ');
                //        ls[num] = ls[num].Replace('B', ' ');
                //        ls[num] = ls[num].Trim();
                //        double s = Double.Parse(ls[num]);
                //        s = s * 1024 * 1024 * 1024;
                //        s = Math.Truncate(s);
                //        ls[num] = s.ToString();
                //        all = all + s;
                //    }
                //    else if (ls[num].Contains("KB") == true)
                //    {
                //        ls[num] = ls[num].Replace('K', ' ');
                //        ls[num] = ls[num].Replace('B', ' ');
                //        ls[num] = ls[num].Trim();
                //        double s = Double.Parse(ls[num]);
                //        s = s * 1024 * 1024;
                //        s = Math.Truncate(s);
                //        ls[num] = s.ToString();
                //        all = all + s;
                //    }
                //    else
                //    {
                //        ls[num] = ls[num].Replace('B', ' ');
                //        ls[num] = ls[num].Trim();
                //        double s = Double.Parse(ls[num]);
                //        s = Math.Truncate(s);
                //        ls[num] = s.ToString();
                //        all = all + s;
                //    }
                //    num = num + 1;
                //}

                //num = 0;
                //while (num < ls.Count)
                //{
                //    lp[num] = lp[num].Replace('%', ' ');
                //    lp[num] = lp[num].Trim();
                //    double s = Double.Parse(lp[num]);
                //    s = s / 100;
                //    lp[num] = s.ToString();
                //    num = num + 1;
                //}

                //double a = 0; int i = 0;
                //while (i < ls.Count)
                //{
                //    a = a + Double.Parse(ls[i]) * Double.Parse(lp[i]);
                //    i = i + 1;
                //}
                //finish = a / all;
                //finish = Math.Round(finish, 2);
                ////MessageBox.Show(finish.ToString("P"));
                ////finish = 0.5;
                //taskbar.ProgressState = TaskbarItemProgressState.Normal;
                //taskbar.ProgressValue = finish;

            }
            catch (Exception)
            {
                //
            }
        }






        /// <summary>
        /// 窗口移动事件
        /// 窗口最大化最小化
        /// </summary>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }
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





        /// <summary>
        /// 主窗口功能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
<<<<<<< HEAD

            MessageBoxResult r2 = System.Windows.MessageBox.Show("将要进行重置？", "警告", MessageBoxButton.OKCancel);
            if (r2 == MessageBoxResult.OK)
            {
                if (File.Exists("aria2c.conf"))
                {
                    File.Delete("aria2c.conf");
                }
                if (File.Exists("aria2c.session"))
                {
                    File.Delete("aria2c.session");
                }
                killaria2();
                loadconfig();
                startaria2();
                loadweb();
            }
            else
            {
                //reture
            }
            
=======
            //if (File.Exists("aria2c.conf"))
            //{
            //    File.Delete("aria2c.conf");
            //}
            if (File.Exists("aria2c.session"))
            {
                File.Delete("aria2c.session");
            }
            kill_all_aria2();
            loadconfig();
            startaria2();
            loadweb();
>>>>>>> 8422520e526fe779d61ad11b0f47dc840301bf6c
        }

        
    }




}
