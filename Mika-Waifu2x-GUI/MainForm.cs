using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace MikaMinecraftServers
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public MainForm()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            // Add dummy data to the listview
            //检测waifu2x是否存在
            TabCon2.SelectedTab = PicFix;
            if (Directory.Exists(Application.StartupPath + "//Tools//waifu2x//waifu2x_ncnn"))
            {
                PicTab.SelectedTab = SelectPic;
            }
            else
            {
                PicTab.SelectedTab = Start;
            }

            seedListView();
        }

        String AppRunPath = AppDomain.CurrentDomain.BaseDirectory;

        private void seedListView()
        {
            //Define
            var data = new[]
            {
                new []{"Lollipop", "392", "0.2", "0"},
                new []{"KitKat", "518", "26.0", "7"},
                new []{"Ice cream sandwich", "237", "9.0", "4.3"},
                new []{"Jelly Bean", "375", "0.0", "0.0"},
                new []{"Honeycomb", "408", "3.2", "6.5"}
            };

            //Add

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private int colorSchemeIndex;
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2) colorSchemeIndex = 0;

            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void ServerTab_Click(object sender, EventArgs e)
        {

        }

       
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2) colorSchemeIndex = 0;

            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            TabCon2.SelectedTab = PicFix;
            if (Directory.Exists(Application.StartupPath + "//Tools//waifu2x//waifu2x_ncnn"))
            {
                PicTab.SelectedTab = SelectPic;
            }
            else
            {
                PicTab.SelectedTab = One;
            }
            
        }

        string waifurar = "http://mika-netdisk.herokuapp.com/waifu2x_ncnn.rar";

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            String WaifuPath = AppRunPath + "/Tools/Waifu";
            PicTab.SelectedTab = Download;
            //PicBar1.Style = ProgressBarStyle.Marquee;
            if (Directory.Exists(WaifuPath))
            {
                WaifuPath = WaifuPath + "/waifu2x_ncnn.rar";

                try
                {
                    //string UpdateFile = textBox1.Text.Trim();
                    Thread threadDown = new Thread(new ThreadStart(Threadp));
                    threadDown.IsBackground = true;
                    threadDown.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Thread threadP = new Thread(() => DownloadFile(WaifuPath));
                //threadP.Start(); 
                //DownloadFile("http://mika-netdisk.herokuapp.com/waifu2x_ncnn.rar", WaifuPath);
            }
            else
            {
                Directory.CreateDirectory(WaifuPath);
                WaifuPath = WaifuPath + "/waifu2x_ncnn.rar";

                try
                {
                    //string UpdateFile = textBox1.Text.Trim();
                    Thread threadDown = new Thread(new ThreadStart(Threadp));
                    threadDown.IsBackground = true;
                    threadDown.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Thread threadP = new Thread(() => DownloadFile(WaifuPath));
                //threadP.Start();
                //DownloadFile("http://mika-netdisk.herokuapp.com/waifu2x_ncnn.rar", WaifuPath);
            }

        }





        /// <summary>
        /// Http下载文件
        /// </summary>
        /*
        private bool DownloadFile(string filename)
            {
                string URL = waifurar;
                MessageBox.Show("下载已开始");
                try
                {
                    //MessageBox.Show(URL);
                    HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                    HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                    Stream st = myrp.GetResponseStream();
                    Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length);
                    while (osize > 0)
                    {
                        MessageBox.Show("8");
                        so.Write(by, 0, osize);
                        osize = st.Read(by, 0, (int)by.Length);
                        PicBar1.Value = osize;
                        //materialLabel5.Text = osize.ToString();
                        MessageBox.Show("text");
                    }
                    so.Close();
                    st.Close();
                    myrp.Close();
                    Myrq.Abort();
                    return true;
                }
                catch (System.Exception e)
                {
                    return false;
                }
            }
        */
        private delegate void setText();

        public void Threadp()
        {
            try
            {
                setText d = new setText(downFile); //实例化一个委托

                this.Invoke(d); //在拥用此控件的基础窗体句柄的线程上执行指定的委托
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void downFile()
        {
            string updateFileUrl = "";
            if (RadioCX.Checked == true)
            {
                updateFileUrl = "http://d0.ananas.chaoxing.com/download/3911f6b49c72769387e2c5179db106b5?fn=waifu2x_ncnn";
            }
            if (RadioMIKA.Checked == true)
            {
                updateFileUrl = "http://mika-netdisk.herokuapp.com/waifu2x_ncnn.rar";
            }

            long fileLength = 0;
            try
            {
                int readCountOnce = 20000000;//每次下载的字节数，该值越大，下载越快
                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                PicBar1.Value = 0;
                if (fileLength >= 0)
                {
                    PicBar1.Maximum = (int)fileLength;
                }

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte > readCountOnce ? readCountOnce : allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        PicBar1.Value += downByte;

                        float part = (float)startByte / readCountOnce;
                        float total = (float)bufferbyte.Length / readCountOnce;
                        int percent = Convert.ToInt32((part / total) * 100);

                        this.materialLabel5.Text = percent.ToString() + "%";

                    }

                    string tempPath = Application.StartupPath + "//Tools//waifu2x//";
                    if (!Directory.Exists(tempPath))
                    {
                        Directory.CreateDirectory(tempPath);
                    }
                    tempPath += "waifu2x_ncnn.rar";
                    FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();
                    materialLabel4.Text = "已完成(￣▽￣)";
                    Thread threadunrar = new Thread(new ThreadStart(Threadu));//开始解压rar线程
                    threadunrar.IsBackground = true;
                    threadunrar.Start();

                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (WebException ex1)
            {
                MessageBox.Show("更新文件下载失败！" + ex1.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Threadu()
        {
            try
            {
                setText d = new setText(unrar); //实例化一个委托

                this.Invoke(d); //在拥用此控件的基础窗体句柄的线程上执行指定的委托
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void unrar()
        {
            reUNRAR.Visible = false;
            PicBar1.Value = 0;
            materialLabel4.Text = "解压中（。＾▽＾）";
            materialLabel5.Text = "约共占用70.9MB,清理后为38MB";
            string unrarF = Application.StartupPath + "//Resources//UnRAR.exe";
            try
            {
                string s = "";
                s = " x " + Application.StartupPath + "//Tools//waifu2x//waifu2x_ncnn.rar " + Application.StartupPath + "//Tools//waifu2x//";
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(unrarF, s);
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                PicBar1.Value = 50;
                Thread.Sleep(3000);
                if (Directory.Exists(Application.StartupPath + "//Tools//waifu2x//waifu2x_ncnn"))
                {
                    PicBar1.Value = 100;
                    materialLabel5.Text = "OK！两秒后继续---->……";
                    Thread.Sleep(2000);
                    PicTab.SelectedTab = SelectPic;
                }
                else
                {
                    PicBar1.Value = 0;
                    materialLabel4.Text = "解压失败＞︿＜";
                    materialLabel5.Text = "Error!!!";
                    reUNRAR.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("解压失败＞︿＜，原因：" + ex.Message);
            }

        }


        private void reUNRAR_Click(object sender, EventArgs e)
        {
            Thread threadunrar = new Thread(new ThreadStart(Threadu));//开始解压rar线程
            threadunrar.IsBackground = true;
            threadunrar.Start();
        }

        private void materialRaisedButton2_Click_1(object sender, EventArgs e)
        {
            string DataTimeS;
            string OutputS_end2;
            string formatPic = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择你的图片╰(￣ω￣ｏ)";
            //
            //dialog.Filter = "视频文件(*.mp4,.flv,.f4v,.webm,.m4v,.mov,.3gp,.3g2,.rm,.rmvb,.wmv,.avi,.asf,.mpg,.mpeg,.mpe,.ts,.div,.dv,.divx,.vob,.dat,.mkv,.swf,.lavf,.cpk,.dirac,.ram,.qt,.fli,.flc,.mod*)|*.mp4,.flv,.f4v,.webm,.m4v,.mov,.3gp,.3g2,.rm,.rmvb,.wmv,.avi,.asf,.mpg,.mpeg,.mpe,.ts,.div,.dv,.divx,.vob,.dat,.mkv,.swf,.lavf,.cpk,.dirac,.ram,.qt,.fli,.flc,.mod*";
            dialog.Filter = "图片文件(*.jpg;*.png;*.bmp;*.gif;*.tif;*.jpeg;*.tiff)|*.jpg;*.png;*.bmp;*.gif;*.tif;*.jpeg;*.tiff";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                long DataTimeL= DateTime.Now.ToFileTimeUtc();
                DataTimeL = DataTimeL / 100;
                DataTimeS = DataTimeL.ToString();
                if (pngR.Checked == true)
                    formatPic = "png";
                else if (jpgR.Checked == true)
                    formatPic = "jpg";
                else if (webpR.Checked == true)
                    formatPic = "webp";
                string fileURL = dialog.FileName;
                materialSingleLineTextField1.Text = fileURL;
                OutputS_end2 = Path.GetDirectoryName(materialSingleLineTextField1.Text) + "\\" + Path.GetFileNameWithoutExtension(materialSingleLineTextField1.Text) + "_" + DataTimeS + "." + formatPic;
                materialSingleLineTextField2.Text = OutputS_end2;
            }
        }

        private void materialRaisedButton3_Click_1(object sender, EventArgs e)
        {
            string OutputS;
            string DataTimeS;
            string OutputS_end;
            string formatPic="";
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog();
            if (P_File_Folder.ShowDialog() == DialogResult.OK&&materialSingleLineTextField1.Text!="")
            {
                //MessageBox.Show(P_File_Folder.SelectedPath);    //选定目录后打印路径信息
                OutputS = P_File_Folder.SelectedPath;
                long DataTimeL = DateTime.Now.ToFileTimeUtc();
                DataTimeL = DataTimeL / 100;
                DataTimeS = DataTimeL.ToString();
                if (pngR.Checked == true)
                    formatPic = "png";
                else if (jpgR.Checked == true)
                    formatPic = "jpg";
                else if (webpR.Checked == true)
                    formatPic = "webp";
                string fileURL = materialSingleLineTextField1.Text;
                materialSingleLineTextField1.Text = fileURL;
                OutputS_end = OutputS + Path.GetFileNameWithoutExtension(materialSingleLineTextField1.Text) + "_" + DataTimeS + "." + formatPic;
                materialSingleLineTextField2.Text = OutputS_end;
            }
            else
            {
                MessageBox.Show("请检查导入参数是否正确<(＿　＿)>");
            }
        }

        private void SelectPic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                pictureBox2.Visible = true;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void SelectPic_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox2.Visible = false;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string formatPic="";
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".jpg"|| Path.GetExtension(file) == ".png"|| Path.GetExtension(file) == ".bmp"|| Path.GetExtension(file) == ".tiff"|| Path.GetExtension(file) == ".jpeg"|| Path.GetExtension(file) == ".gif"|| Path.GetExtension(file) == ".tif")  //判断文件类型，只接受图片
                {
                    if (pngR.Checked == true)
                        formatPic = "png";
                    else if (jpgR.Checked == true)
                        formatPic = "jpg";
                    else if (webpR.Checked == true)
                        formatPic = "webp";
                    long DataTimeL = DateTime.Now.ToFileTimeUtc();
                    DataTimeL = DataTimeL / 100;
                    string DataTimeS = DataTimeL.ToString();
                    materialSingleLineTextField1.Text = file;
                    string OutputS_end2Drop = Path.GetDirectoryName(materialSingleLineTextField1.Text) + "\\" + Path.GetFileNameWithoutExtension(materialSingleLineTextField1.Text) + "_" + DataTimeS + "." + formatPic;
                    materialSingleLineTextField2.Text = OutputS_end2Drop;
                }
            }
        }

        private void SelectPic_DragLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            PicTab.SelectedTab = ProSetting;
        }

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            //检测参数是否符合要求
            string formatPic = "";
            int C_n = int.Parse(nST.Text);
            int C_s = int.Parse(sST.Text);
            long DataTimeL = DateTime.Now.ToFileTimeUtc();
            DataTimeL = DataTimeL / 100;
            string DataTimeS = DataTimeL.ToString();
            if (pngR.Checked == true)
                formatPic = "png";
            else if (jpgR.Checked == true)
                formatPic = "jpg";
            else if (webpR.Checked == true)
                formatPic = "webp";
            if(File.Exists(materialSingleLineTextField1.Text))
            {
                materialSingleLineTextField2.Text = Path.GetDirectoryName(materialSingleLineTextField1.Text) + "\\" + Path.GetFileNameWithoutExtension(materialSingleLineTextField1.Text) + "_" + DataTimeS + "." + formatPic;
            }
            if (C_n== -1||C_n==1||C_n==2||C_n==3)
            {
                if(C_s==1||C_s==2)
                {
                    PicTab.SelectedTab = SelectPic;
                }
                else
                {
                    MessageBox.Show("缩放参数错误！请重新填写╯︿╰");
                }
            }
            else
            {
                MessageBox.Show("降噪或缩放参数错误！请重新填写╯︿╰");
            }
            

        }

        static string Waifu2xPath = @System.AppDomain.CurrentDomain.BaseDirectory + "\\Tools\\waifu2x\\waifu2x_ncnn\\waifu2x-ncnn-vulkan.exe";

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            try
            {
                //string UpdateFile = textBox1.Text.Trim();
                Thread threadDown = new Thread(new ThreadStart(Threadwaifu2x));
                threadDown.IsBackground = true;
                threadDown.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Threadwaifu2x()
        {
            try
            {
                setText d = new setText(GoWaifu2x); //实例化一个委托

                this.Invoke(d); //在拥用此控件的基础窗体句柄的线程上执行指定的委托
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoWaifu2x()
        {
            string formatPic = "";
            string gpuid = "";
            string i1 = materialSingleLineTextField1.Text;
            string o1 = materialSingleLineTextField2.Text;
            //string OutputINFORMATION;
            int i1Size = i1.Length;
            int o1Size = o1.Length;
            //图片格式-f
            if (pngR.Checked == true)
                formatPic = "png";
            else if (jpgR.Checked == true)
                formatPic = "jpg";
            else if (webpR.Checked == true)
                formatPic = "webp";
            //gpuid -g
            if (GPU0.Checked == true)
                gpuid = "0";
            else if (GPU1.Checked == true)
                gpuid = "1";
            else if (GPU2.Checked == true)
                gpuid = "2";

            Process[] ps = Process.GetProcessesByName("waifu2x-ncnn-vulkan.exe");
            var p = new Process();
            PicTab.SelectedTab = Run;
            p.StartInfo.FileName = Waifu2xPath;
            p.StartInfo.Arguments = "-i " + materialSingleLineTextField1.Text + " -o " + materialSingleLineTextField2.Text + " -n " + nST.Text + " -s " + sST.Text + " -f " + formatPic + " -g " + gpuid;
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //p.ErrorDataReceived += new DataReceivedEventHandler(OutputINFORMATION);
            p.Start();//启动线程
            p.BeginErrorReadLine();//开始异步读取
            p.WaitForExit();//阻塞等待进程结束
            p.Close();//关闭进程
            p.Dispose();//释放资源
            materialLabel10.Text = "完成！ヾ(≧▽≦*)o";
        }
        private void OutputINFORMATION(object sendProcess, DataReceivedEventArgs output)
        {
            if (!String.IsNullOrEmpty(output.Data))
            {
                string outputSz = output.ToString();
                materialLabel11.Text = @outputSz;
            }
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            PicTab.SelectedTab = One;
        }
    }
}