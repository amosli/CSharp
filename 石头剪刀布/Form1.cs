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

namespace 石头剪刀布
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击石头按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStone_Click(object sender, EventArgs e)
        {
            String fist = "石头";
            Game(fist);
        }
        /// <summary>
        /// 点击剪刀按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScissors_Click(object sender, EventArgs e)
        {
            String fist = "剪刀";
            Game(fist);
        }
        /// <summary>
        /// 点击布按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloth_Click(object sender, EventArgs e)
        {
            String fist = "布";
            Game(fist);

        }

        //背景图片轮播
        String[] paths = Directory.GetFiles(@"C:\work\stone");//此目录里面必须有图片，否则会报错
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(paths[new Random().Next(0, paths.Length)]);

        }
        static int playerWinTimes = 0;//玩家赢的次数
        static int gameTimes = 0;//总共次数
        static int tieTimes = 0;//平手次数

        /// <summary>
        /// 通用方法
        /// </summary>
        /// <param name="fist"></param>
        private void Game(String fist)
        {
            gameTimes++;
            lbPlayer.Text = fist;
            int playerNum = Player.ShowFist(fist);
            Computer cpu = new Computer();
            int cpuNum = cpu.ShowFist();
            lbComputer.Text = cpu.Fist;
            Judge.RESULT result = Judge.WhoWin(playerNum, cpuNum);
            lbJudge.Text = result.ToString();
            lbStatistics.Text = "统计信息：\n\n1.您赢了" + playerWinTimes + "场比赛!\n\n" + "2.平手了" + tieTimes + "次; \n\n" + "3.输掉了" + (gameTimes - playerWinTimes - tieTimes) + "场比赛; \n\n" + "4.共进行了" + gameTimes + "场比赛!\n\n";

            if (result == Judge.RESULT.玩家赢)
            {
                playerWinTimes++;
                MessageBox.Show("恭喜，您已经赢了" + playerWinTimes + "场比赛！" + " 共进行了" + gameTimes + "场比赛！");
            }
            else if (result == Judge.RESULT.平手)
            {
                tieTimes++;
            }

        }


    }
}
