//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Security.Policy;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace factory  //テキストに沿ってnamespaceを変更する。
//{
//    /// <summary>
//    /// 8CHの内容
//    /// </summary>
//    public abstract class Item
//    {
//        protected string caption;
//        public Item(string caption)
//        { this.caption = caption; }

//        public abstract String makeHTML();
//    }

//    public abstract class Link : Item
//    {
//        protected string url;
//        public Link(string caption, string url):base(caption)
//        { 
//         //   base.caption = caption;//親クラスへ渡す。これはbaseで渡し済み         
//            this.url = url;
//        }
//    }

//    public abstract class Tray : Item
//    {
//        protected ArrayList tray = new ArrayList();
//        public Tray(string caption) : base(caption)
//        { }

//        public void add(Item item)
//        {
//            tray.Add(item);
//        }
//    }

//    /// <summary>
//    /// HTMLページ全体を抽象的に表したクラス。
//    /// </summary>
//    public abstract class Page
//    {
//        protected string title;
//        protected string author;
//        protected ArrayList content = new ArrayList();


//        public Page(string title, string author)
//        {
//            this.title = title;
//            this.author = author;
//        }

//        public void Add(Item item)
//        {
//            content.Add(item);
//        }

//        public void Output()
//        {
//            try
//            {
//                string filename = title + ".html";
//                System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);
//                writer.Write(this.makeHTML());
//                writer.Close();

//                Debug.Print(filename + "　を作成しました");
//            }
//            catch (IOException e)
//            {
//                Debug.Print(e.StackTrace);
//            }
//        }
//        public abstract string makeHTML();
//    }

//    public abstract class Factory
//    {
//        /// <summary>
//        /// 具体的な具体的な工場のインスタンスを作成する。しかしリターンはFactory(抽象的な工場)となっている点に注意
//        /// </summary>
//        /// <param name="classname"></param>
//        /// <returns></returns>
//        public static Factory GetFactory(string classname)
//        {
//            //プライベート変数
//            Factory factory = null;

//            try
//            {
//                Assembly assembly = Assembly.GetExecutingAssembly();

//                factory = (Factory)assembly.CreateInstance(
//                    classname,
//                    false,
//                    BindingFlags.CreateInstance,
//                    null,
//                    null,
//                    null,
//                    null);
//            }
//            catch (TypeLoadException e)
//            {
//                Debug.Print(e.StackTrace + classname + " が見つかりません");
//            }

//            return factory;
//        }

//        public abstract Link CreateLink(string caption, string url);
//        public abstract Tray CreateTray(string caption);
//        public abstract Page CreatePage(string title, string author);
//    }


//}

