using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox控件学习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static String ImgDirPath = @"C:\work\img";
        String[] imgPaths = Directory.GetFiles(ImgDirPath, "*.jpg");
        public static int ImgNum = 0;
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ImgNum--;
            if (ImgNum < 0)
            {
                ImgNum = imgPaths.Length-1;
            }
            pboGirls.ImageLocation = imgPaths[ImgNum];

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ImgNum++;
            if (ImgNum >= imgPaths.Length)
            {
                ImgNum = 0;
            }
            pboGirls.ImageLocation = imgPaths[ImgNum];
        }
    }
}
