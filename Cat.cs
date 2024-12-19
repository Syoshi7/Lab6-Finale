using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Cat : IMeowkee
    {
        private readonly string Name;

        public Cat(string name)
        {
            Name = name;
        }

        public string _name => Name;

        public override string ToString()
        {
            return $"Кот: {Name}";
        }

        public void Meow()
        {
            Console.WriteLine(Name + ": Meow. ");
        }

        public void Meowing(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("*неловкое молчание*");
                return;
            }
            string meows = string.Join("-", new string[n].Select(_ => "Meow"));
            Console.WriteLine($"{Name}: {meows}");
        }

    }
}
