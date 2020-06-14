using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    public class Singleton
    {
        //staticにすることでクラスロード時に一回だけインスタンスが生成される。つまりstaticを入れないと生成されない。
        private static Singleton singleton = new Singleton();
        private Singleton()
        {
            Debug.Print("インスタンスを生成しました");
        }

        public static Singleton getInstance()
        {
            return singleton;
        }
    }
}
