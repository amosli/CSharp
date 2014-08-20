using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace httpclient
{
    public class httpclient
    {
        private static String dir = @"C:\work\";

        /// <summary>
        /// 写文件到本地
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        public static void Write(string fileName, string html)
        {
            try
            {
                FileStream fs = new FileStream(dir + fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(html);
                sw.Close();
                fs.Close();

            }catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
            }
           
        }

        /// <summary>
        /// 写文件到本地
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        public static void Write(string fileName, byte[] html)
        {
            try
            {
                File.WriteAllBytes(dir + fileName, html);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }

        /// <summary>
        /// 登录博客园
        /// </summary>
        public static void LoginCnblogs()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            String url = "http://passport.cnblogs.com/login.aspx";
            HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
            String result = response.Content.ReadAsStringAsync().Result;

            String username = "hi_amos";
            String password = "密码";

            do
            {
                String __EVENTVALIDATION = new Regex("id=\"__EVENTVALIDATION\" value=\"(.*?)\"").Match(result).Groups[1].Value;
                String __VIEWSTATE = new Regex("id=\"__VIEWSTATE\" value=\"(.*?)\"").Match(result).Groups[1].Value;
                String LBD_VCID_c_login_logincaptcha = new Regex("id=\"LBD_VCID_c_login_logincaptcha\" value=\"(.*?)\"").Match(result).Groups[1].Value;

                //图片验证码
                url = "http://passport.cnblogs.com" + new Regex("id=\"c_login_logincaptcha_CaptchaImage\" src=\"(.*?)\"").Match(result).Groups[1].Value;
                response = httpClient.GetAsync(new Uri(url)).Result;
                Write("amosli.png", response.Content.ReadAsByteArrayAsync().Result);
                
                Console.WriteLine("输入图片验证码：");
                String imgCode = "wupve";//验证码写到本地了，需要手动填写
                imgCode =  Console.ReadLine();

                //开始登录
                url = "http://passport.cnblogs.com/login.aspx";
                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                paramList.Add(new KeyValuePair<string, string>("__EVENTTARGET", ""));
                paramList.Add(new KeyValuePair<string, string>("__EVENTARGUMENT", ""));
                paramList.Add(new KeyValuePair<string, string>("__VIEWSTATE", __VIEWSTATE));
                paramList.Add(new KeyValuePair<string, string>("__EVENTVALIDATION", __EVENTVALIDATION));
                paramList.Add(new KeyValuePair<string, string>("tbUserName", username));
                paramList.Add(new KeyValuePair<string, string>("tbPassword", password));
                paramList.Add(new KeyValuePair<string, string>("LBD_VCID_c_login_logincaptcha", LBD_VCID_c_login_logincaptcha));
                paramList.Add(new KeyValuePair<string, string>("LBD_BackWorkaround_c_login_logincaptcha", "1"));
                paramList.Add(new KeyValuePair<string, string>("CaptchaCodeTextBox", imgCode));
                paramList.Add(new KeyValuePair<string, string>("btnLogin", "登  录"));
                paramList.Add(new KeyValuePair<string, string>("txtReturnUrl", "http://home.cnblogs.com/"));
                response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;
                result = response.Content.ReadAsStringAsync().Result;
                Write("myCnblogs.html",result);
            } while (result.Contains("验证码错误，麻烦您重新输入"));

            Console.WriteLine("登录成功！");
            
            //用完要记得释放
            httpClient.Dispose();
        }

        public static void Main()
        {
            //loginZJ();
            LoginCnblogs();
        }

        public static void loginZJ()
        {

            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");


            String phone = "手机号码";
            String password = "手机密码";
            String url = "https://zj.ac.10086.cn/login";
            var result = httpClient.GetAsync(new Uri(url)).Result;

            url = "https://zj.ac.10086.cn/ImgDisp";
            result = httpClient.GetAsync(new Uri(url)).Result;
            var task = result.Content.ReadAsByteArrayAsync();
            Write("1.png", task.Result);

            String imgCode = "smhus";

            url = "https://zj.ac.10086.cn/loginbox";
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
            paramList.Add(new KeyValuePair<string, string>("service", "my"));
            paramList.Add(new KeyValuePair<string, string>("continue", "%2Fmy%2Flogin%2FloginSuccess.do"));
            paramList.Add(new KeyValuePair<string, string>("failurl", "https%3A%2F%2Fzj.ac.10086.cn%2Flogin"));
            paramList.Add(new KeyValuePair<string, string>("style", "1"));
            paramList.Add(new KeyValuePair<string, string>("pwdType", "2"));
            paramList.Add(new KeyValuePair<string, string>("SMSpwdType", "0"));
            paramList.Add(new KeyValuePair<string, string>("billId", phone));
            paramList.Add(new KeyValuePair<string, string>("passwd1", "%CD%FC%BC%C7%C3%DC%C2%EB%A3%BF%BF%C9%D3%C3%B6%AF%CC%AC%C3%DC%C2%EB%B5%C7%C2%BC"));
            paramList.Add(new KeyValuePair<string, string>("passwd", password));
            paramList.Add(new KeyValuePair<string, string>("validCode", imgCode));


            result = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;


            url = "http://www.zj.10086.cn/my/sso";
            url = new Regex("action=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;

            String SAMLart = new Regex("name=\"SAMLart\" value=\"(.*?)\"").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            String RelayState = new Regex("name=\"RelayState\" value=\"(.*?)\"").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;

            paramList.Clear();
            paramList.Add(new KeyValuePair<string, string>("SAMLart", SAMLart));
            paramList.Add(new KeyValuePair<string, string>("RelayState", RelayState));
            paramList.Add(new KeyValuePair<string, string>("submit", "提交"));
            result = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;

            url = new Regex("action=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            String jumpUrl = new Regex("name=['|\"]jumpUrl['|\"] value=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            String loginUrl = new Regex("name=['|\"]loginUrl['|\"] value=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            SAMLart = new Regex("name=['|\"]SAMLart['|\"] value=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            RelayState = new Regex("name=['|\"]RelayState['|\"] value=[\'|\"](.*?)[\'|\"]").Match(result.Content.ReadAsStringAsync().Result).Groups[1].Value;
            paramList.Clear();
            paramList.Add(new KeyValuePair<string, string>("SAMLart", SAMLart));
            paramList.Add(new KeyValuePair<string, string>("RelayState", RelayState));
            paramList.Add(new KeyValuePair<string, string>("submit", "提交"));
            paramList.Add(new KeyValuePair<string, string>("jumpUrl", jumpUrl));
            paramList.Add(new KeyValuePair<string, string>("loginUrl", loginUrl));
            result = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;

            url = "http://www.zj.10086.cn/my/index.jsp";
            result = httpClient.GetAsync(new Uri(url)).Result;
            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }

        

    }
}
