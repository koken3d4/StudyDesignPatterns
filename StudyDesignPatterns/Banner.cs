using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    public class Banner
    {
        private string str;

        public Banner(string str)
        { this.str = str; }
        public void ShowWithParen()
        {
            Debug.Print("(" + str + ")");
        }

        public void ShowWithAster()
        {
            Debug.Print("*" + str + "*");
        }
    }

    public interface IPrint
    {
        void PrintWeak();
        void PrintStrong();
    }

    public class PrintBanner : Banner, IPrint
    {
        public PrintBanner(string str) : base(str)//baseキーワードの使い方をさっぱり忘れていたので要注意。
        {

        }
        public void PrintWeak()
        {
            ShowWithParen();//継承元から呼び出している。
        }

        public void PrintStrong()
        {
            ShowWithAster();//継承元から呼び出している。
        }
    }
}
