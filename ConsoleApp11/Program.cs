using System.Collections.Generic;
using System;
using System.Xml.Linq;

class InvalidNameException : Exception
{
    public InvalidNameException(string message) : base(message) { }
}
class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}
public enum Items
{
    Bible,
    Tabaco,
    Lamp,
    Towel,
    Apple,
    Bottle,
    Cigarette,
    Fish,
    Meat
}

interface ILightable
{
    void LightLamp();
}
interface IGotHereable
{
    void GotHere();
}
class Person : ILightable, IGotHereable
{
    private string Name;
    public void setName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Имя не может быть пустым");
        }
        Name = value;

    }
    private string Spot;
    public void setSpot(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Место не может быть пустым");
        }
        Spot = value;
    }

    private bool IsSick { get; set; }
    private bool IsTired { get; set; }
    private bool IsHungry { get; set; }
    private bool IsSickDealer { get; set; }
    private bool IsHungryDealer { get; set; }
    private bool IsTiredDealer { get; set; }
    private bool IsMoney { get; set; }
    private bool PassedByDealer { get; set; }
    private bool MurderDealer { get; set; }
    private Bag Inventory { get; set; } = new Bag();

    public Bag getInventory
    {

        get { return Inventory; }
    }

    public Person(string name, string spot)
    {
        Name = name;
        Spot = spot;
    }
    public void LeaveHome()
    {
        int k = 0;
        Console.WriteLine($"{Name} хочет выйти уже прохладным вечером на поиски еды");
        Console.WriteLine("Надеть кожанную куртку или рубашку (1 or 2)?");
        string input1 = Console.ReadLine();

        if (input1 == "1")
        {
            IsSick = false;
            IsMoney = true;
        }
        else if (input1 == "2")
        {
            IsSick = true;
            IsMoney = false;
        }
        else
        {
            throw new InvalidInputException("Введите 1 или 2");
        }

        Console.WriteLine($"Надеть удобные ботинки или лапти (1 or 2)? ");
        string input2 = Console.ReadLine();
        if (input2 == "1")
        {
            IsTired = false;
        }
        else if (input2 == "2")
        {
            IsTired = true;
            k++;
            IsHungry = true;
        }
        else
        {
            throw new InvalidInputException("Введите 1 или 2");
        }
        Console.WriteLine($"\n{Name} отправился в {Spot} на поиске еды");
        Console.WriteLine("На встречу шел торговец с припасами, он остановился и начал предлагать товары");
        if (IsMoney)
        {
            IsHungry = false;
            PassedByDealer = false;
            IsSickDealer = false;
            IsTiredDealer = false;
            Console.WriteLine($"Из за того что {Name} надел кожаную куртку, в карманах оказались деньги, и он смог купить себе поесть");
            getInventory.AddItems(Items.Apple); getInventory.AddItems(Items.Bottle);
            Console.WriteLine($"{Name} положил купленные предметы в походную сумку");
        }
        else
        {
            Console.WriteLine("Денег не оказалось, но можно убить торговца и забрать еду, или пройти мимо на поиски (1 or 2)");
            string input3 = Console.ReadLine();
            if (input3 == "1")
            {
                MurderDealer = true;
                IsTiredDealer = true;
                IsHungry = false;
                IsTired = true;
                k++;
                if (k == 2)
                {
                    IsSickDealer = true;
                }
                Console.WriteLine($"{Name} убил торговца, забрал еду, поэтому он точно не останется голодным");
                getInventory.AddItems(Items.Meat); getInventory.AddItems(Items.Apple); getInventory.AddItems(Items.Cigarette);
                Console.WriteLine($"{Name} положил награбленые предметы в походную сумку");
            }
            else if (input3 == "2")
            {
                IsSickDealer = false;
                PassedByDealer = true;
                IsTiredDealer = false;
                Console.WriteLine($"Из за того что денег нет, {Name} решил пройти мимо дальше на поиски еды");
                if (input2 == "1")
                {
                    getInventory.AddItems(Items.Fish); getInventory.AddItems(Items.Apple);
                    Console.WriteLine($"{Name} поймал рыбу и собрал яблоки, положил это в походную сумку");
                }
            }
            else
            {
                throw new InvalidInputException("Введите 1 или 2");
            }
        }
    }
    public void GotHere()
    {
        Console.WriteLine($"\n{Name}, спустя некоторое время добрался до своего убежища");
    }
    public void LightLamp()
    {
        Console.WriteLine($"{Name} включил светильник, потому что в убежище было темно");
    }
    public void CanSleep()
    {
        if (IsSick || IsSickDealer)
        {
            Console.WriteLine("Из за болезни сон никак не идет");
        }
        else if (!IsSick && !IsSickDealer)
        {
            Console.WriteLine($"{Name} спокойно уснул");
        }
    }
    public void Condition()
    {
        if (IsSick)
        {
            if (IsSickDealer)
            {
                Console.WriteLine($"В драке с торговцем {Name} очень вымотался, поэтому заболел");
            }
            else
            {
                Console.WriteLine($"{Name} болен, потому что надел рубашку и простудился");
            }
        }
        else Console.WriteLine($"{Name} надел куртку, поэтому чувствует себя хорошо");
        if (IsTired)
        {
            if (IsTiredDealer)
            {
                Console.WriteLine($"{Name} устал из за драки с торговцем");
            }
            else
            {
                if (IsMoney)
                {
                    Console.WriteLine($"{Name} просто купил еды у торговца и вернулся домой, но его ноги устали из за лаптей");
                }
                else
                {
                    Console.WriteLine($"Только ноги {Name} сильно утомились из за лаптей");
                }
            }
        }
        else
        {
            if (IsMoney)
            {
                Console.WriteLine($"{Name} купил товары и сразу же пошел домой, поэтому не сильно устал");
            }
            else if (PassedByDealer)
            {
                Console.WriteLine($"{Name} не потратил свои силы на убийство торговца");
            }
            else
            {
                Console.WriteLine($"{Name} не чувствует усталости в ногах, потому что он надел удобные ботинки");
            }
        }
        if (IsHungry)
        {
            Console.WriteLine($"{Name} ничего не купил у торговца и не нашел поесть, потому что он не смог дойти до места с едой");
        }
        else
        {
            if (IsMoney)
            {
                Console.WriteLine($"{Name} купил еды у торговца, поэтому сытый");
            }
            else if (MurderDealer)
            {
                Console.WriteLine($"{Name} убил торговца и забрал еду, поэтому сытый");
            }
            else
            {
                Console.WriteLine($"{Name} дошел до {Spot} с едой, поэтому сытый");
            }
        }
        CanSleep();
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return Name == other.Name;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
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
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите имя вашего героя: ");
            string inputname = Console.ReadLine();
            Console.Write("Введите место куда отправится герой: ");
            string inputspot = Console.ReadLine();
            Person person = new Person(inputname, inputspot);
            person.LeaveHome();
            person.GotHere();
            person.LightLamp();
            person.getInventory.Info();
            person.getInventory.PrintItems();
            person.getInventory.GetItem(Items.Apple);
            Console.WriteLine("Герой поел яблоко");
            person.Condition();

            Storage chest = new Chest();
            chest.Info();
            chest.AddItems(Items.Tabaco);
            chest.AddItems(Items.Bible);
            chest.AddItems(Items.Cigarette);
            chest.AddItems(Items.Lamp);
            chest.AddItems(Items.Towel);
            chest.PrintItems();
            chest.GetItem(Items.Bible);
            chest.GetItem(Items.Tabaco);

            Console.Write("\nХотите продолжить игру или выйти (1 или 2)? ");
            string inputgame = Console.ReadLine();
            if (inputgame == "2")
            {
                break;
            }
        }
    }
}