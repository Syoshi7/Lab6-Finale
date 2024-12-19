using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class MeowCounter : IMeowkee
    {
        private readonly IMeowkee _meowkee;
        private int _meowCount;

        public MeowCounter(IMeowkee meowkee)
        {
            _meowkee = meowkee;
            _meowCount = 0;
        }

        public void Meow()
        {
            _meowkee.Meow();
            _meowCount++;
        }

        public void Meowing(int x)
        {
            _meowkee.Meowing(x);
            _meowCount += x;
        }

        public int GetMeowCount()
        {
            return _meowCount;
        }

        public IMeowkee Meowkee => _meowkee;
    }
}
