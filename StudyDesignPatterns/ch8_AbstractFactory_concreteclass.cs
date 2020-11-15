//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using factory;  //テキストに沿ってfactoryのnamespeceをインポートする。

//namespace listfactory  //テキストに沿ってnamespaceを変更する。
//{
//    public class ListFactory : Factory
//    {
//        public Link CreateLink(string caption, string url)
//        {
//            return new ListLink(caption, url);
//        }

//        public override Tray CreateTray(string caption)
//        {
//            return new ListTray(caption);
//        }

//        public override Page CreatePage(string title, string author)
//        { return new ListPage(title, author); }
//    }

//    public class ListLink : Link
//    {
//        public ListLink(string caption, string url) : base(caption, url)
//        { }

//        public override String makeHTML()
//        {
//            return "<li><a href=\"" + url + "\">" + caption + "</a></li>\n";
//        }
//    }

//    public class ListTray : Tray 
//    {
//        public ListTray(string caption) : base(caption)
//        { }

//        public override  string makeHTML()
//        {
//            StringBuilder buffer = new StringBuilder();
//            buffer.Append("<li>\n");
//            buffer.Append(caption + "\n");
//            buffer.Append("<ul>\n");

//            foreach (var ob in tray)
//            {
//                var _item = (Item)ob;
//                buffer.Append(_item.makeHTML());            
//            }

//            buffer.Append("</ul>\n");
//            buffer.Append("</li>\n");

//            return buffer.ToString(); 
//        }
//    }

//    public class ListPage : Page
//    {
//        public ListPage(string title, string author):base(title ,author)
//        {  }

//        public override string makeHTML()
//        {
//            StringBuilder buffer = new StringBuilder();
//            buffer.Append("<html><head><title>" + title + "</title></head>/n");
//            buffer.Append("<body>\n");
//            buffer.Append("<hl>" + title + "</hl>\n");
//            buffer.Append("<ul>\n");

//            foreach (var addItem in content)
//            {
//                var add = (Item)addItem;
//                buffer.Append(add);
//            }
//            buffer.Append("</ul>\n");
//            buffer.Append("<hr><address>"+author+"</address>");
//            buffer.Append("</body></html>\n");
//            return buffer.ToString();
//        }
//    }
//}

