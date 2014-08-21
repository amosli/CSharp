using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listbox控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //实现单击播放音乐
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object path = this.listBox1.SelectedItem;
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = dirPath +"\\"+ path;
            sp.Play();
        }

        static String dirPath = @"C:\work\wav";
        static String[] paths = Directory.GetFiles(dirPath, "*.wav");
        
        //将文件名加载到listbox中
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (String path in paths)
            {
                String fileName = Path.GetFileName(path);
                listBox1.Items.Add(fileName);
            }
        }
    }
}
