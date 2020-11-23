using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    public class Hand
    {
        public static int HANDVALUE_GUU = 0;
        public static int HANDVALUE_CHO = 1;
        public static int HANDVALUE_PAA = 2;
        public static Hand[] hand =
        {
            new Hand(HANDVALUE_GUU),
            new Hand(HANDVALUE_CHO),
            new Hand(HANDVALUE_PAA)
        };

        private static String[] name ={
            "グー",
            "チョキ",
            "パー"
        };

        private int handvalue;
        private Hand(int handvalue)
        {
            this.handvalue = handvalue;
        }

        public static Hand getHand(int handvalue)
        { return hand[handvalue]; }

        public Boolean isStrongerThan(Hand h)
        { return figth(h) == 1; }

        public bool isWeakerTha(Hand h)
        { return figth(h) == -1; }

        private int figth(Hand h)
        {
            //引き分けの時は〇，Thisの価値ならば一、hの価値ならば-1を返す。
            if (this == h)
                return 0;

            else if ((this.handvalue + 1) % 3 == h.handvalue)
                return 1;
            else
                return -1;
        }

        public String toString()
        {
            return name[handvalue];
        }
    }
}
