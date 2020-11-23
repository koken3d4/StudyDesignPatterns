using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns.Strategy_CH10
{
    public class ProbStrategy : Strategy
    {
        private Random random;
        private int prevHandValue = 0;
        private int currentHandValue = 0;

        private int[,] history = new int[,] {
            {1,1,1},
            {1,1,1},
            {1,1,1}
        };

        public ProbStrategy(int seed)
        {
            random = new Random(seed);
        }

        public Hand nextHand()
        {
            int bet = random.Next(getSum(currentHandValue));
            int handvalue = 0;
            if (bet < history[currentHandValue, 0])
            {
                handvalue = 0;
            }
            else if (bet < history[currentHandValue, 0] + history[currentHandValue, 1])
                handvalue = 1;

            else
                handvalue = 2;

            prevHandValue = currentHandValue;
            currentHandValue = handvalue;
            return Hand.getHand(handvalue);
        }

        private int getSum(int hv)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += history[hv, i];
            }

            return sum;
        }

        public void study(bool win)
        {
            if (win)
            {
                history[prevHandValue, currentHandValue]++;
            }
            else
            {
                history[currentHandValue, (currentHandValue + 1) % 3]++;
                history[currentHandValue, (currentHandValue + 2) % 3]++;

            }
        }
    }
}
