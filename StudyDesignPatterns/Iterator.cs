using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    class Iterator
    {
    }

     interface IIterator
    {
        bool hasNext { get; set; }
        Object next { get; set; }
    }
    interface Aggregate
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
        { return Book[index]; }

        public void appendBook(Book book)
        {
            this.books[last] = book;
            last++;
        }

        public int getLength()
        { return last; }

        public Iterator iterator()
        { return new BookshelfIterator(this); }
    }


    public class BookShelfIterator : IIterator
    {
        private BookShelf bookshelf;
        private int index;
        public BookShelfIterator(BookShelf bookshelf)
        {
            this.bookshelf = bookshelf;
            this.index = 0;
        }
        public bool IIterator.hasNext
        {
            if (index < bookshelf.getLength())
                return true;
            else
                return false;
        }
        public object IIterator.next()
        {
            Book book = bookshelf.getBookAt(index);
            index++;
            return book;
        }
}
