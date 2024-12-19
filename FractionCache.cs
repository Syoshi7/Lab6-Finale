using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class FractionCache : IFraction
    {
        private Fraction fraction;   // Ссылка на объект дроби
        private double? cachedValue; // кэш значение

        

        public FractionCache(Fraction fraction)
        {
            this.fraction = fraction;
            this.fraction.FractionChanged += InvalidateCache;
            cachedValue = null;
        }

        // Получение закэшированного значения
        public double GetDecimalValue()
        {
            if (!cachedValue.HasValue)
            {
                Console.WriteLine("Кэш пуст. Вычисление: ");
                cachedValue = (double)fraction.Numerator / fraction.Denominator;
            }
            else
            {
                Console.WriteLine("Значение взято из кэша.");
            }
            return cachedValue.Value;
        }

        

        public void InvalidateCache()
        {
            Console.WriteLine("Кэш сбросил.");
            cachedValue = null;
        }

        public void SetNumerator(int numerator)
        {
            fraction.SetNumerator(numerator);
            InvalidateCache();
        }

        public void SetDenominator(int denominator)
        {
            fraction.SetDenominator(denominator);
            InvalidateCache();
        }
    }

}
//17 декабря в 9:45, к концу пар подойти. 524/2.