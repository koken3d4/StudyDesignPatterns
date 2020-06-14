using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    public abstract class Builder
    {
        public abstract void makeTitle(string title);
        public abstract void makeString(string str);
        public abstract void makeItems(string[] items);

        public abstract void close();
    }

    public class Director
    {
        private Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void construct()
        {
            builder.makeTitle(" Greeting 2");
            builder.makeString("朝から昼にかけて");
            builder.makeItems(new string[] { "おはようございます", "こんにちは" });
            builder.makeString("夜に");
            builder.makeItems(new string[] { "こんにちは", "おやすみなさい", "さようなら" });
            builder.close();
        }
    }

    public class TextBuilder : Builder
    {
        private StringBuilder buffer = new StringBuilder();
        public override void makeTitle(string title)
        {
            buffer.Append("/////////////\n");
            buffer.Append("[" + title + "]\n");
            buffer.Append("\n");
        }

        public override void makeString(string str)
        {
            buffer.Append('_' + str + "\n");
            buffer.Append("\n");
        }

        public override void makeItems(string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                buffer.Append(" ." + items[i] + "\n");
            }
            buffer.Append("\n");
        }

        public override void close()
        {
            buffer.Append("========================\n");
        }
        public string getResult()
        {
            return buffer.ToString();
        }
    }

    public class HTMLBuilder : Builder
    {
        private string filename;
        private System.IO.StreamWriter writer;
        public override void makeTitle(string title)
        {
            filename = title + ".html";
            try
            {
                writer = System.IO.File.CreateText(filename);
                writer.WriteLine("<html><head><title>" + title + "</title></head><body>");
                writer.WriteLine("<h1>" + title + "</p>");
            }
            catch (IOException e)
            {
                Debug.Print(e.StackTrace);
            }
        }

        public override void makeString(string str)
        {
            writer.WriteLine("<p>" + str + "</p>");
        }

        public override void makeItems(string[] items)
        {
            writer.WriteLine("<ul>");
            for (int i = 0; i < items.Length; i++)
            {
                writer.WriteLine("<li>" + items[i] + "</li>");
            }
            writer.WriteLine("</ul>");
        }
        public override void close()
        {
            writer.WriteLine("</body></html>");
            writer.Close();
        }

        public string getResult()
        {
            return filename;
        }
    }
}
