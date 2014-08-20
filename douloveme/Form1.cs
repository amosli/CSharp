using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace douloveme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("me too!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("好伤心，被你点到了！！");
            button2_change_location();
        }

        public void button2_change_location()
        {
            //给按钮一个新的坐标
            //这个按钮活动的最大高度就是窗体的高度减去button的高度，
            int x = this.ClientSize.Width - button2.Width;
            int y = this.ClientSize.Height - button2.Height;

            Random rnd = new Random();
            button2.Location = new Point(rnd.Next(0, x), rnd.Next(0, y));
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2_change_location();
        }


    }
}
