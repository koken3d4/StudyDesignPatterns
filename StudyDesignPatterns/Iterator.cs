using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    public interface Iterator
    {
        bool hasNext { get; }
        Object next { get; }
    }
    interface Aggregate  //aggregateは集計するという意味
    {
        Iterator iterator();
    }

    public class Book
    {
        private string name;
        public Book(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
    public class BookShelf : Aggregate
    {
        private Book[] books;
        private int last = 0;
        public BookShelf(int maxsize)
        {
            this.books = new Book[maxsize];

        }
        public Book getBookAt(int index)
        { return books[index]; }
        /// <summary>
        /// appendBookをすることで、配列の最初からブックを追加していく。
        /// </summary>
        /// <param name="book"></param>
        public void appendBook(Book book)
        {
            this.books[last] = book;
            last++;
        }

        public int getLength()
        { return last; }

        public Iterator iterator()
        { return new BookShelfIterator(this); }
    }


    public class BookShelfIterator : Iterator
    {
        private BookShelf bookshelf;
        private int index;
        public BookShelfIterator(BookShelf bookshelf)
        {
            this.bookshelf = bookshelf;
            this.index = 0;
        }
        bool Iterator.hasNext
        {
            get
            {
                if (index < bookshelf.getLength())
                    return true;
                else
                    return false;
            }
        }
        object Iterator.next
        {
            get
            {
                Book book = bookshelf.getBookAt(index);
                index++;
                return book;
            }
        }
    }
}
