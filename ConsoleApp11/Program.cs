using System.Collections.Generic;
using System;
using System.Xml.Linq;
using ConsoleApp11;
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