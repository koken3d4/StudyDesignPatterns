using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using framework;
namespace framework
{
    class FactoryMethod
    {
    }
    public abstract class Product
    {
        public abstract void Use();
    }

    public abstract class Factory
    {
        public Product create(string owner)
        {
            Product p = createProduct(owner);
            registerProduct(p);
            return p;
        }
        protected abstract Product createProduct(string owner);
        protected abstract void registerProduct(Product product);
    }
}

namespace idcard
{
    public class IDcard : Product
    {
        private string owner;
        public IDcard(string owner)
        {
            Debug.Print(owner + "のカードを作ります");
            this.owner = owner;
        }
        public override void Use()
        { Debug.Print(owner + "のカードを使います。"); }

        public string getOwner()
        {
            return owner;
        }
    }

    public class IDCardFactory : Factory
    {
        private List<string> Owners = new List<string>();
        protected override Product createProduct(string owner)
        {
            return new IDcard(owner);
        }
        protected override void registerProduct(Product product)
        {
            Owners.Add((IDcard)product.getOwner());
        }

        public List<string> getOwners()
        {
            return Owners;
        }
    }
}
