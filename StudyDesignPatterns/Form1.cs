using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyDesignPatterns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookShelf bookShelf = new BookShelf(4);
            bookShelf.appendBook(new Book("asdf"));
            bookShelf.appendBook(new Book("2222"));
            bookShelf.appendBook(new Book("3333"));
            bookShelf.appendBook(new Book("4444"));
            Iterator it = bookShelf.iterator();
            while (it.hasNext)
            {
                Book book = (Book)it.next;
                Debug.Print(book.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPrint IP = new PrintBanner("hello");
            IP.PrintWeak();
            IP.PrintStrong();

            Print P = new PrintBannerInheritance("test");//　Printクラスだけど、PrintBannerInheritanceクラスでインスタンスしていることに注意。中小クラスだからこれができる。普通のクラスの警鐘だとこれはできないので注意すること。
            P.PrintWeak();
            P.PrintStrong();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbstractDisplay d1 = new CharDiplay('H');
            AbstractDisplay d2 = new StringDisplay("Hello,World");
            AbstractDisplay d3 = new StringDisplay("ｔｔｔｔ");

            d1.Display();
            d2.Display();
            d3.Display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Singleton obj1 = Singleton.getInstance();
            Singleton obj2 = Singleton.getInstance();
            if (obj1 == obj2)
                Debug.Print("1と2は同じです");
            else 
                Debug.Print("1と2は同じインスタンスではありません");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            UnderlinePen upen = new UnderlinePen('~');
            MessageBox mbox = new MessageBox('*');
            MessageBox sbox = new MessageBox('Z');
            manager.register("strong massage", upen);
            manager.register("warning box", mbox);
            manager.register("slash box", sbox);

            //生成
            Product p1 = manager.Create("strong massage");
            p1.use("hello world");
            Product p2 = manager.Create("warning box");
            p2.use("hello world");
            Product p3 = manager.Create("slash box");
            p3.use("hello world");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //plane textでの出力
            TextBuilder textbuilder = new TextBuilder();
            Director director = new Director(textbuilder);
            director.construct();
            string result = textbuilder.getResult();
            Debug.Print(result);

            //htmlでの出力
            HTMLBuilder htmlbuilder = new HTMLBuilder();
            Director director2 = new Director(htmlbuilder);
            director2.construct();
            string filename = htmlbuilder.getResult();
            Debug.Print(filename + "が作成されました");
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Display d1 = new Display(new StringDisplayImpl("Hello Japan."));
            Display d2 = new Display(new StringDisplayImpl("Hello World."));
            CountDisplay d3 = new CountDisplay(new StringDisplayImpl("Hello Universe."));
            d1.display();
            d2.display();
            d3.display();
            d3.multiDisplay(2);
        }


    }
}
