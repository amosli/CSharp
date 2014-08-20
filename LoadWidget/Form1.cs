using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadWidget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// 禁止新弹出的窗口，好像没有什么作用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //this.webBrowser1.Document.InvokeScript("function aa(){window.alert=null;window.confirm=null;window.open=null;window.showModalDialog=null;window.close=null}");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //js容错
            webBrowser1.ScriptErrorsSuppressed = true;
            //禁止新弹出的窗口
            this.webBrowser1.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);

        }
        public void CreateFile(String fileName,String html)
        {
            try
            {
                String dir = "C://work//";
                // 创建文件
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                FileStream fs = new FileStream(dir + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs); // 创建写入流
                sw.WriteLine(html); // 写入Hello World
                sw.Close(); //关闭文件
            }
            catch (Exception ex)
            {
                CreateFile("exception" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".html", ex.ToString());
            }
           
        }

       

        private void GO_Click(object sender, EventArgs e)
        {
             String url = urlInput.Text.Trim();
            if (String.IsNullOrEmpty(url))
            {
                url = "http://www.baidu.com";
            }
            webBrowser1.Navigate(url);
            webBrowser1.Navigate(@"C:\Users\amosli\Desktop\ocx.html");
            url = "https://www.bestpay.com.cn/api/captcha/getCode";
            httpClient.GetStringAsync(new Uri(url));
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void urlInput_Enter(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlInput.Text);
        }

        private void urlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("即将访问：" + urlInput.Text);
                webBrowser1.Navigate(urlInput.Text);
            }
        }

        private void urlInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoginPay();
        }


        public HttpClient httpClient = new HttpClient();
        public String productNo = "手机号码";
        public String password = "vjHmAw8T7DOw70NmGFvitQ==";
        public String url = "https://www.bestpay.com.cn/index";


        public void LoginPay()
        {
            //while (webBrowser1.Document.GetElementById("encrypt") == null)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}

            //String password = webBrowser1.Document.GetElementById("encrypt").InnerText;

            productNo = "手机号码";
            password = "vjHmAw8T7DOw70NmGFvitQ==";
            url = "https://www.bestpay.com.cn/index";

            // Always catch network exceptions for async methods
            try
            {
                MessageBox.Show("url:" + url);
                var result = httpClient.GetStringAsync(new Uri(url)).Result;
                CreateFile(DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".html", result.ToString());

                //bpsid:b620b3c8Z93712d4fZ147e2322e3aZ2098


                String imgCode = "";
                url = "https://www.bestpay.com.cn/api/captcha/getCode";
                result = httpClient.GetStringAsync(new Uri(url)).Result;
                CreateFile(DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".png", result.ToString());

                url = "https://www.bestpay.com.cn/api/captcha/match?actualToken=" + imgCode;
                result = httpClient.GetStringAsync(new Uri(url)).Result;
                CreateFile(DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".png", result.ToString());

                url = "https://www.bestpay.com.cn/api/security/getRandomString?key=keyPassword";
                result = httpClient.GetStringAsync(new Uri(url)).Result;
                CreateFile(DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".html", result.ToString());
                //z0ucvvpzjxzvcyvmvv8jl5kxukz08moc

                // /UIlLgT+92BN90eygkOiDg==
                // Bn4IocfkSRlZrbxKYB0eUg==
                // Kv8ARrvDPL8y8cVttv39Rw==  


                // vjHmAw8T7DOw70NmGFvitQ==

                 //vjHmAw8T7DOw70NmGFvitQ==

                

                //productNo=手机号码&vcode=dxy7&password=vjHmAw8T7DOw70NmGFvitQ==&target=
                url = "https://www.bestpay.com.cn/api/user/otherLogin";
                var pairs = new List<KeyValuePair<String, String>>();

                password = Regex.Replace(password, "=", "%3D");
                pairs.Add(new KeyValuePair<string, string>("productNo", productNo));
                pairs.Add(new KeyValuePair<string, string>("vcode", imgCode));
                pairs.Add(new KeyValuePair<string, string>("password", password));
                pairs.Add(new KeyValuePair<string, string>("target", ""));
                var content = new FormUrlEncodedContent(pairs);

                //result = httpClient.PostAsync(url, content).Result;
                string resultContent = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                CreateFile(DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".html", result.ToString());

                url = "https://www.bestpay.com.cn/mypay/home";
                result = httpClient.GetStringAsync(new Uri(url)).Result;
            }
            catch (Exception ex)
            {
                CreateFile("exception" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".html", ex.ToString());
            }

            // Once your app is done using the HttpClient object call dispose to 
            // free up system resources (the underlying socket and memory used for the object)
            httpClient.Dispose();
        }
    }
}
