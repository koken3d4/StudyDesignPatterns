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
    }
}
