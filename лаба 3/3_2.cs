using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp178
{
    public class MyFrac
    {
        private int nom;
        private int denom;

        public MyFrac()
        {
            Random rnd = new Random();
            nom = rnd.Next(-50, 50);
            denom = rnd.Next(-50, 50);
            Console.WriteLine("Випадковим чином заповняємо значення дробу: {0}/{1}", nom, denom);
        }
        public MyFrac(int nom, int denom)
        {
            int commDenom = 1;
            if (denom < 0)
            {
                denom = -denom;
            }
            if (nom < 0)
            {
                nom = -nom;
            }
            for (int i = 2; i <= nom; i++)
            {
                if (denom % i == 0 && nom % i == 0)
                    commDenom = i;
            }

            nom = nom / commDenom;
            denom = denom / commDenom;
            Console.WriteLine(nom + "/" + denom);
        }

        public int Nom
        {
            get { return nom; }
        }
        public int Denom
        {
            get { return denom; }
        }
        public static void ToStringwithInteger(int nom, int denom)
        {
            Console.WriteLine($"Дрiб з видiленою цiлою частиною: ({(nom) / (denom)}+{nom - (nom) / denom * denom}/{denom})");
        }
        public static void Plus(int nom1, int denom1, int nom2, int denom2)
        {
            Console.WriteLine("Пiсля додавання двох дробiв отримаємо: " + (nom1 * denom2 + denom1 * nom2) + "/" + (denom1 * denom2));
        }
        public static void Minus(int nom1, int denom1, int nom2, int denom2)
        {
            Console.WriteLine("Пiсля вiднiмання двох дробiв отримаємо: " + (nom1 * denom2 - denom1 * nom2) + "/" + (denom1 * denom2));
        }
        public static void Multiply(int nom1, int denom1, int nom2, int denom2)
        {
            Console.WriteLine("Пiсля множення двох дробiв отримаємо: " + (nom1 * nom2) + "/" + (denom1 * denom2));
        }
        public static void Divide(int nom1, int denom1, int nom2, int denom2)
        {
            Console.WriteLine("пiсля дiлення двох дробiв отримаємо: " + (nom1 * denom2) + "/" + (denom1 * nom2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Дрiб №1");
            MyFrac f1 = new MyFrac();
            Console.Write("Cкорочений дрiб: ");
            MyFrac f11 = new MyFrac(f1.Nom, f1.Denom);
            MyFrac.ToStringwithInteger(f1.Nom, f1.Denom);
            Console.WriteLine();
            Console.WriteLine("Дрiб №2");
            MyFrac f2 = new MyFrac();
            Console.Write("Cкорочений дрiб: ");
            MyFrac f22 = new MyFrac(f2.Nom, f2.Denom);
            MyFrac.ToStringwithInteger(f2.Nom, f2.Denom);
            Console.WriteLine();
            Console.WriteLine("Результат додавання  двох дробiв: ");
            MyFrac f3 = new MyFrac((f1.Nom * f2.Denom + f1.Denom * f2.Nom), (f1.Denom * f2.Denom));
            Console.WriteLine("Результат вiднiмання  двох дробiв: ");
            MyFrac f4 = new MyFrac((f1.Nom * f2.Denom - f1.Denom * f2.Nom), (f1.Denom * f2.Denom));
            Console.WriteLine("Результат множення  двох дробiв: ");
            MyFrac f5 = new MyFrac((f1.Nom * f2.Nom), (f1.Denom * f2.Denom));
            Console.WriteLine("Результат дiлення  двох дробiв: ");
            MyFrac f6 = new MyFrac((f1.Nom * f2.Denom), (f2.Nom * f1.Denom));
            Console.ReadLine();
        }
    }
}
