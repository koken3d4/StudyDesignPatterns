using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    /// <summary>
    /// CH9で出てくるパターン
    /// 機能のクラス階層と、実装のクラス階層を分ける事でそれぞれのクラスを独立して拡張出来るようにしている。
    /// </summary>
    class Bridge
    {
    }
    public class Display
    {
        private DisplayImpl impl;
        public Display(DisplayImpl impl)
        {
            // DisplayImplクラスをプライベート変数として持つ事で、処理を委譲させている。
            this.impl = impl;
        }

        public void Open()
        { impl.rawOpen(); }

        public void Print()
        {
            impl.rawPrint();
        }

        public void Close()
        {
            impl.rawClose();
        }

        public  void display()
        {
            Open();
            Print();
            Close();
        }
    }

    /// <summary>
    /// 新しいメソッドを追加している。
    /// ここまでが機能のクラス階層となる。
    /// </summary>
    public class CountDisplay : Display
    {
        public CountDisplay(DisplayImpl impl) : base(impl)
        {
        }

        public void multiDisplay(int times)
        {
            Open();
            for (int i = 0; i < times; i++)
                Print();

            Close();
        }
    }

    /// <summary>
    /// 実装のクラス階層
    /// DisplayImplは抽象クラス
    /// </summary>
    public abstract class DisplayImpl
    {
        public abstract void rawClose();
        public abstract void rawOpen();
        public abstract void rawPrint();
    }

    public class StringDisplayImpl : DisplayImpl
    {
        private string str;
        private int width;
        public StringDisplayImpl(string str)
        {
            this.str = str;
            this.width = str.Length;
        }

        public override void rawOpen()  //rawOpenは抽象メソッドなのでoverrideキーワードが必要
        {
            printLine();
        }

        public override void rawPrint()
        {
            Debug.Print("|" + str + "|");  //前後に｜をつけて表現する。
        }

        public override void rawClose()
        {
            printLine();
        }

        private void printLine()
        {
            Debug.Print("+");
            for (int i = 0; i < width; i++)
            {
                Debug.Print("-");
            }
            Debug.Print("+");
        }
    }
}
