using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    class Bridge
    {
    }
    public class Display
    {
        private DisplayImpl impl;
        public Display(DisplayImpl impl)
        {
            this.impl = impl;
        }

        public void open()
        { impl.rawOpen(); }

        public void print()
        {
            impl.rawPrint();
        }

        public void close()
        {
            impl.rawClose();
        }

        public  void display()
        {
            open();
            print();
            close();
        }
    }

    public class CountDisplay : Display
    {
        public CountDisplay(DisplayImpl impl) : base(impl)
        {
        }

        public void multiDisplay(int times)
        {
            open();
            for (int i = 0; i < times; i++)
                print();

            close();
        }
    }

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

        public override void rawOpen()
        {
            printLine();
        }

        public override void rawPrint()
        {
            Debug.Print("|" + str + "|");
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
