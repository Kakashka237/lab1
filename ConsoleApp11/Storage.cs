using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11;

namespace ConsoleApp11
{
    abstract class Storage
    {
        public List<Items> items = new List<Items>();

        public abstract void Info();
        public virtual void PrintItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public virtual void AddItems(Items name)
        {
            if (items.Contains(name))
            {
                throw new InvalidNameException("Такой предмет уже существует");
            }
            else items.Add(name);
        }
        public virtual void GetItem(Items item)
        {
            foreach (var name in items)
            {
                if (item.Equals(name))
                {
                    items.Remove(name);
                    break;
                }
            }
        }
    }
}
