using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StudyDesignPatterns.Strategy_CH10
{
    public class StrategyManager
    {
        Tuple<string, string> retStrTuple;
        public StrategyManager()
        {

        }

        public void StartGame()
        {
            //CH10章のメインクラス
            int seed1 = 123;
            int seed2 = 545;

            Player p1 = new Player("taro", new WinningStrategy(seed1));
            Player p2 = new Player("hanako", new ProbStrategy(seed2));

            for (int i = 0; i < 1000; i++)
            {
                Hand nexthand1 = p1.nextHand();
                Hand nexthand2 = p2.nextHand();

                if (nexthand1.isStrongerThan(nexthand2))
                {
                    Debug.Print("winner:" + p1);
                    p1.win();
                    p2.lose();
                }
                else if (nexthand2.isStrongerThan(nexthand1))
                {
                    Debug.Print("winner:" + p2);
                    p1.lose();
                    p2.win();
                }

                else
                {
                    Debug.Print("even...");
                    p1.even();
                    p2.even();
                }
            }

            Debug.Print("totalresult+");
            Debug.Print(p1.tostring());
            Debug.Print(p2.tostring());
        }
    }
}