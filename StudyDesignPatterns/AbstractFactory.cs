using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    /// <summary>
    /// 8CHの内容
    /// </summary>
    public abstract class Item
    {
        protected string caption;
        public Item(string caption)
        { this.caption = caption; }

        public abstract String makeHTML();
    }

    public abstract class Link : Item
    {
        protected string url;
        public Link(string caption,string url)
        {
            super(caption);
            this.url = url;
        }
    
    
    }
}

