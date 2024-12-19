using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Tiger : IMeowkee
    {
        private readonly string Name;

        public Tiger(string name)
        {
            Name = name;
        }

        public void Meow()
        {
            Console.WriteLine($"{Name}: pррмяу?");
        }

        public void Meowing(int x)
        {
            if (x < 1)
            {
                Console.WriteLine(Name + "молчит");
            }
            if (x > 0)
            {
                string meow = " ";
                for (int i = 0; i < x - 1; i++)
                {
                    meow += "мряу";
                }

                meow += "мяу";
                Console.WriteLine($"{this}: {meow}");
            }
        }

        public override string ToString()
        {
            return $"Тигр: {Name}";
        }
    }
}
