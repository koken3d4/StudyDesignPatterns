using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
    }
}
