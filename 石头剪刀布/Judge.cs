using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 石头剪刀布
{

    class Judge
    {

        public enum RESULT
        {
            玩家赢,
            电脑赢,
            平手,
        }

        public static RESULT WhoWin(int playerNum, int computerNum)
        {
            int result = playerNum - computerNum;
            if (result == -1 || result == 2)
            {
                return RESULT.玩家赢;
            }
            else if (result == 0)
            {
                return RESULT.平手;

            }
            else
            {
                return RESULT.电脑赢;
            }

        }


    }
}
