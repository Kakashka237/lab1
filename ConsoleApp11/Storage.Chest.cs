using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11;

namespace ConsoleApp11
{
    class Chest : Storage
    {
        public override void Info()
        {
            Console.WriteLine("\nПосле непродолжительного сна герой пошел к сундуку за табаком и библией");
        }
        public override void PrintItems()
        {
            Console.WriteLine("Содержимое сундука:");
            base.PrintItems();
        }
        public override void AddItems(Items name)
        {
            base.AddItems(name);
        }
        public override void GetItem(Items name)
        {
            if (!items.Contains(name))
            {
                Console.WriteLine($"Предмета {name} нет в сундуке");
                return;
            }
            base.GetItem(name);
            Console.WriteLine($"Вы достали {name} из сундука");
        }
        public override bool Equals(object obj)
        {
            if (obj is Chest other)
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
