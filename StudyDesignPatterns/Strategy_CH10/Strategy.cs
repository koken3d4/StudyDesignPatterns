using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns.Strategy_CH10
{
    public interface Strategy
    {
        //javaではpublicが必要だけど、C#では不要。
        Hand nextHand();
        void study(bool win);
    }
}
