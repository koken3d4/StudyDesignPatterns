using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns.Strategy_CH10
{
    class WinningStrategy : Strategy
    {
        private Random random;
        private bool won = false;
        private Hand prevHand;
        public WinningStrategy(int seed)
        { random = new Random(seed); }

        public Hand nextHand()
        {
            if (!won)
                prevHand = Hand.getHand(random.Next(3));  //これで3未満の整数を出力するはず。

            return prevHand;
        }

        public void study(bool win)
        {
            won = win;
        }
    }
}
