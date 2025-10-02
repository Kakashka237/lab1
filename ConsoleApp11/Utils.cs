using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11;

namespace ConsoleApp11
{
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
}
