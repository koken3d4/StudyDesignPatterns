//第三章
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    class Templete
    {
    }
    public abstract class AbstractDisplay
    {
        public abstract void Open();
        public abstract void Print();
        public abstract void Close();

        //抽象ラスの中で実装できるのか。
        public void Display()
        {
            Open();
            for (int i = 0; i < 5; i++)
                Print();

            Close();
        }
    }
    public class CharDiplay : AbstractDisplay
    {
        private char ch;
        public CharDiplay(char ch)
        {
            this.ch = ch;
        }
        public override void Open()
        {
            Debug.Print("<<");//本では一列で表示させるような処理をしてたがC#では見つからなかったので割愛
        }
        public override void Print()
        {
            Debug.Print(ch.ToString());

        }
        public override void Close()
        {
            Debug.Print(">>");
        }
    }


    public class StringDisplay : AbstractDisplay
    {
        private string str;
        private int width;
        public StringDisplay(string str)
        {
            this.str = str;
            this.width = str.Length; //本ではgetbytesを用いていたがC#ではなかったので割愛
        }

        public override void Open()
        {
            Debug.Print("");
        }

        public override void Print()
        {
            Debug.Print("|" + str + "|");
        }

        public override void Close()
        {
            Debug.Print("");
        }
    }
}
