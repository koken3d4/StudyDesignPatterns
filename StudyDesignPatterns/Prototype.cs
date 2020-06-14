using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPatterns
{
    class Prototype
    {
    }
    public interface Product : ICloneable
    {
        void use(string s);      
    }

    public class Manager
    {
        private Dictionary<string, Product> showcase = new Dictionary<string, Product>();
        public void register(string name, Product proto)
        {
            showcase.Add(name, proto);
        }

        public Product Create(string protoname)
        {
            Product p = showcase[protoname];
            return (Product)p.Clone(); //objectなのでキャストする。
        }
    }

    public class MessageBox : Product
    {
        private char decochar;
        public MessageBox(char decochar)
        {
            this.decochar = decochar;
        }
        public void use(string s)
        {
            int length = s.Length;
            for (int i = 0; i < length * 4; i++)
            {
                Debug.Print(decochar.ToString());
            }

            Debug.Print(""); 
            Debug.Print(decochar + " " + s + "　" + decochar);
            for (int i = 0; i < length + 4; i++)
            {
                Debug.Print(decochar.ToString());
            }
            Debug.Print(" ");
        }

        public object Clone()
        {
            Product p = null;

            try
            {
                p = (Product)this; //地震をProductにキャスとして返す。
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
            return p;
        }
    }

    public class UnderlinePen :Product
    {
        private char ulchar;
        public UnderlinePen(char ulchar)
        {
            this.ulchar = ulchar;
        }

        public void use(string s)
        {
            int length = s.Length;
            Debug.Print("\\" + s + "\\");
            Debug.Print(" ");

            for( int i=0;i<length;i++)
            {
                Debug.Print(ulchar.ToString());
            }

            Debug.Print(" ");
        }

        public object Clone()
        {
            Product p = null;
            try
            {
                p = (Product)this;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace); 
            }
            return p;
        }
    }
}
