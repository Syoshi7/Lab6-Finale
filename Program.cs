namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 Задача.

            Cat Barsik = new Cat("Барсик");
            Cat Sanya = new Cat("Саня");
            Tiger Grizsha = new Tiger("Гриша");

            Barsik.Meow();
            Barsik.Meowing(0);
            Sanya.Meow();
            Sanya.Meowing(-1);
            Grizsha.Meow();
            Grizsha.Meowing(8);

            Console.WriteLine();
            Console.WriteLine();

            // 2 Задача.

            List<IMeowkee> meowkees = new List<IMeowkee>();
            meowkees.Add(new Cat("Барсик"));
            meowkees.Add(new Cat("Саня"));
            meowkees.Add(new Tiger("Гриша"));
            EveryoneMustMeowMeow(meowkees);

            Console.WriteLine();
            Console.WriteLine();

            // 3 Задача.

            List<IMeowkee> meowkee2 = new List<IMeowkee>();
            meowkee2.Add(new MeowCounter(new Cat("Барсик")));
            meowkee2.Add(new MeowCounter(new Cat("Саня")));
            meowkee2.Add(new MeowCounter(new Cat("Гриша")));

            for (int meowtimes = -1; meowtimes > 0; meowtimes--)
            {
                EveryoneMustMeowMeow(meowkee2);
            }


            foreach (var meowkee in meowkee2)
            {
                var MeowCounter = (MeowCounter)meowkee;
                var cat = (Cat)MeowCounter.Meowkee;
                Console.WriteLine($"{cat._name} мяукал: {MeowCounter.GetMeowCount()} раз.");
            }

            Console.WriteLine();
            Console.WriteLine();

            //////////////////////////////////////////////////////////////////////////////////////


            Fraction D1 = new Fraction(3, 4);
            Fraction D2 = new Fraction(1, 2);
            Fraction D3 = new Fraction(7, -8);
            Fraction D4 = new Fraction(7, 8);
            Fraction D5 = new Fraction(7, 8);

            Console.WriteLine($"\n{D1} + {D2} =  {D1 + D2}");
            Console.WriteLine($"{D1} + 2 =  {D1 + 2}");
            Console.WriteLine($"2 + {D2} =  {2 + D2}");

            Console.WriteLine($"\n{D1} - {D2} =  {D1 - D2}");
            Console.WriteLine($"{D1} - 2 =  {D1 - 2}");
            Console.WriteLine($"2 - {D2} =  {2 - D2}");


            Console.WriteLine($"\n{D1} * {D2} = {D1 * D2}");
            Console.WriteLine($"{D1} * 2 = {D1 * 2}");
            Console.WriteLine($"2 * {D2} = {2 * D2}");

            Console.WriteLine($"\n{D1} / {D2} =  {D1 / D2}");
            Console.WriteLine($"{D1} / 2 =  {D1 / 2}");
            Console.WriteLine($"2 / {D2} =  {2 / D2}");

            Console.WriteLine($"\n{D1} + {D2} / {D3} - 5 = {D1 + D2 / D3 - 5}");

            Console.WriteLine($"\nПроверка равенства дробей {D4} и {D5}: {D4 == D5}");
            Console.WriteLine($"Проверка равенства дробей {D3} и {D5}: {D3 == D5}");

            Fraction cloneD5 = (Fraction)D5.Clone();
            Console.WriteLine($"\nОригинальная дробь: {D5}, клонированная дробь: {cloneD5}");
            Console.WriteLine($"Проверка равенства дробей {cloneD5} и {D5}: {cloneD5 == D5}");

            FractionCache cache = new FractionCache(D5);
            Console.WriteLine($"Вещественное значение {D5}: {cache.GetDecimalValue()}");

            D5.SetDenominator(2);
            cache.InvalidateCache();
            Console.WriteLine($"Новое вещ. значение: {cache.GetDecimalValue()}");

            Fraction clone2_D5 = (Fraction)D5.Clone();
            Console.WriteLine($"\nОригинальная дробь: {D5}, клонированная дробь: {clone2_D5}");
            Console.WriteLine($"Проверка равенства дробей {clone2_D5} и {D5}: {clone2_D5 == D5}");

            D5.SetNumerator(2);
            cache.InvalidateCache();
            Console.WriteLine($"Новое вещ. значение: {cache.GetDecimalValue()}");

            Fraction clone3_D5 = (Fraction)D5.Clone();
            Console.WriteLine($"\nОригинальная дробь: {D5}, клонированная дробь: {clone3_D5}");
            Console.WriteLine($"Проверка равенства дробей {clone3_D5} и {D5}: {clone3_D5 == D5}");

            Fraction CacheFraction = new Fraction(1, 3);
            FractionCache cacheCheck = new FractionCache(CacheFraction);
            Console.WriteLine($"Дробь: {CacheFraction}, текущий кэш: {cacheCheck.GetDecimalValue()}");
            CacheFraction.SetNumerator(2);
            //cacheCheck.InvalidateCache();
            CacheFraction.SetDenominator(0);
            Console.WriteLine($"Дробь: {CacheFraction}, текущий кэш: {cacheCheck.GetDecimalValue()}");

        }




        static void EveryoneMustMeowMeow(IEnumerable<IMeowkee> objects)
        {
            foreach (var obj in objects)
            {
                obj.Meow();
            }
        }
    }
}
