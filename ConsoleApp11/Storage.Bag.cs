using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11;

namespace ConsoleApp11
{
    class Bag : Storage
    {
        public override void Info()
        {
            Console.WriteLine("\nГлавный герой откыл сумку");
        }
        public override void PrintItems()
        {
            Console.WriteLine("Содержмое сумки: ");
            base.PrintItems();
        }
        public override void AddItems(Items name)
        {
            if (items.Count >= 4)
            {
                Console.WriteLine("Место в сумке закончилось");
                return;
            }
            base.AddItems(name);
            Console.WriteLine($"Вы достали {name} из сумки");
        }
        public override void GetItem(Items name)
        {
            if (!items.Contains(name))
            {
                Console.WriteLine($"Предмета {name} нет в сумке");
                return;
            }
            base.GetItem(name);
            Console.WriteLine($"Вы достали {name} из сумки");
        }
        public override bool Equals(object obj)
        {
            if (obj is Bag other)
            {
                return items == other.items;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(items);
        }
        public override string ToString()
        {
            return $"{items}";
        }
    }
}
