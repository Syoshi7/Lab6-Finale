using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Fraction : ICloneable, IFraction

    // Сложение дробей - один знаменатель, приводим к общему, т.е. к наименьшему общему кратному
    // Вычитание дробей - один знаменатель, приводим к НОК 
    // Умножение дробей - тоже НОК
    // Деление дробей - это умножение с переворотом числителя и знаменателя наоборот, но делимая дробь не должна быть равна 0, требуется проверка 
    {
        private int numerator;
        private int denominator;

        public event Action FractionChanged;
        public int Numerator
        {
            get => numerator;
            private set => numerator = value;
        }

        public int Denominator
        {
            get => denominator;
            private set
            {
                if (value == 0)
                    throw new ArgumentException("!= 0");
                denominator = value;
            }
        }

        public virtual void OnFractionChanged()
        {
            FractionChanged?.Invoke();
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator < 0)
            {
                this.numerator = -numerator;
                this.denominator = -denominator;
            }
            if (denominator == 0)
                throw new DivideByZeroException("Деление на 0.");
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        ////////////////////////////////////////////////////////////

        public object Clone()
        {
            return new Fraction(Numerator, Denominator);
        }

        public double GetDecimalValue()
        {
            return (double)Numerator / Denominator;
        }

        public void SetNumerator(int numerator)
        {
            Numerator = numerator;
            OnFractionChanged();

        }

        public void SetDenominator(int denominator)
        {
            Denominator = denominator;
            OnFractionChanged();
        }

        ////////////////////////////////////////////////////////////

        public static int NOD(int d1, int d2) // наибольший общий делитель, если у нас дробь например 21 / 48, будет 7 / 16, для этого мы ищем НОД - 3
        {
            if (d2 == 0)
                throw new DivideByZeroException("Попытка деления на ноль");
            while (d1 > 0 && d2 > 0)                // 3 и 7
            {
                if (d1 >= d2)
                    d1 = d1 % d2;
                else                    //  7 > 3
                    d2 = d2 % d1;       // 1 max 1 и 0. возвращается 3 на 7 делённое на 1 это 21, что верно.
            }
            return Math.Max(d1, d2);
        }

        public static int NOK(int d1, int d2) // наименьшее общее кратное, поиск идеального знаменателя
        {
            return d1 * d2 / NOD(d1, d2); // - наименьшее общее кратное 
        }

        ////////////////////////////////////////////////////////

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newDen = NOK(a.Denominator, b.Denominator);
            int newNum = a.Numerator * (newDen / a.Denominator) + b.Numerator * (newDen / b.Denominator);
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        public static Fraction operator +(Fraction a, int b)
        {
            int newDen = a.Denominator;
            int newNum = a.Numerator + b * a.Denominator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        public static Fraction operator +(int a, Fraction b)
        {
            int newDen = b.Denominator;
            int newNum = b.Numerator + a * b.Denominator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        //////////////////////////////////////////////////////////

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int newDen = NOK(a.Denominator, b.Denominator);
            int newNum = a.Numerator * (newDen / a.Denominator) - b.Numerator * (newDen / b.Denominator);
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        public static Fraction operator -(Fraction a, int b)
        {
            int newDen = a.Denominator;
            int newNum = a.Numerator - b * a.Denominator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        public static Fraction operator -(int a, Fraction b)
        {
            int newDen = b.Denominator;
            int newNum = b.Numerator - a * b.Denominator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), newDen));
        }

        //////////////////////////////////////////////////////////

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int newDen = a.Denominator * b.Denominator;
            int newNum = a.Numerator * b.Numerator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
        }

        public static Fraction operator *(Fraction a, int b)
        {
            int newDen = a.Denominator;
            int newNum = a.Numerator * b;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
        }

        public static Fraction operator *(int a, Fraction b)
        {
            int newDen = b.Denominator;
            int newNum = a * b.Numerator;
            return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
        }

        //////////////////////////////////////////////////////////

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new ArgumentException("Делить на 0 нельзя.");
            }
            else
            {
                int newDen = a.Denominator * b.Numerator;
                int newNum = a.Numerator * b.Denominator;
                return new Fraction(newNum / NOD(Math.Abs(newNum), Math.Abs(newDen)), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
            }
        }

        public static Fraction operator /(Fraction a, int b) //  1/2  /  2
        {
            if (b == 0)
            {
                throw new ArgumentException("Делить на 0 нельзя.");
            }
            else
            {
                int newDen = a.Denominator * b;
                int newNum = a.Numerator;
                return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
            }
        }

        public static Fraction operator /(int a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new ArgumentException("Делить на 0 нельзя.");
            }
            else
            {
                int newDen = b.Numerator;
                int newNum = a * b.Denominator;
                return new Fraction(newNum / NOD(Math.Abs(newNum), newDen), newDen / NOD(Math.Abs(newNum), Math.Abs(newDen)));
            }
        }

        //////////////////////////////////////////////////////////

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a.Numerator == b.Numerator && a.Denominator == b.Denominator)
                return true;
            else
                return false;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.Numerator != b.Numerator || a.Denominator != b.Denominator)
                return true;
            else
                return false;
        }

        /////////

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}