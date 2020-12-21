using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp170
{
    class Program
    {
        static void Main(string[] args)
        {
            TRTriangle triangle1 = new TRTriangle();
            Console.WriteLine("введення даних");
            triangle1.InPut();
            triangle1.OutPut();
            TRPiramid tRPiramid=new TRPiramid();
            tRPiramid.InPut();
            tRPiramid.Volume();
            Console.ReadLine();
        }
    }
    class TRTriangle
    {//створили поля для довжин катетов
        public int K1;
        public int K2;
        //створили конструктор без параметрыв
        public TRTriangle() { }
        //створення конструктора з параметрами
        public TRTriangle(int Katet1, int Katet2) { K1 = Katet1; K2 = Katet2; }
        //створення конструктора копыювання
        public TRTriangle(TRTriangle obj) { K1 = obj.K1; K2 = obj.K2; }
        //реалізація методу  public override string ToString()
        public override string ToString()
        {
            return base.ToString();
        }
        //реалізація мектоду введення
        public void InPut()
        {
            Console.WriteLine("введiть величину 1 катета");
            K1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введiть величину 2 катета");
            K2 = Convert.ToInt32(Console.ReadLine());
        }
        //реалізація мектоду виведення
        public void OutPut()
        {
            Console.WriteLine("площа трикутника дорiвнює:");
            Console.WriteLine(Square(K1, K2));
            Console.WriteLine("периметр трикутника дорiвнює:");
            Console.WriteLine(Perimeter(K1, K2));
            Comparisons();
            Overload(K1, K2);
        }
        //реалізація методу визначення площі
        public double Square(int K1, int K2)
        {
            /*int square =*/
            return (K1 * K2) / 2;
             /*square;*/
        }
        //метод визначення периметру
        public double Perimeter(int K1, int K2)
        {
            double H = Math.Sqrt(K1 * K1 + K2 * K2);
            double perimeter = K1 + K2 + H;
            return perimeter;
        }
        //метод порівняння з іншим трикутником 
        public void Comparisons()
        {
            double per = Perimeter(K1, K2);
            double sqr = Square(K1, K2);
            Console.WriteLine("Введiть площу iншого трикутника");
            int sq1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть периметр iншого трикутника");
            int per1 = Convert.ToInt32(Console.ReadLine());
            if (sqr == sq1)
            {
                Console.WriteLine("площi рiвнi");
            }
            else
            {
                Console.WriteLine("площi різнi");
            }
            if (per == per1)
            {
                Console.WriteLine("периметри рiвнi");
            }
            else
            {
                Console.WriteLine("периметри рiзнi");
            }
        }
        //мктод забезпечення перевантаження
        public void Overload(int K1, int K2)
        {
            Console.WriteLine("введiть число на яке ви хочете домножити катет 1 та катет 2");
            double integer = Convert.ToInt32(Console.ReadLine());
            double Kat1 = integer * K1;
            double Kat2 = integer * K2;
            Console.WriteLine("{0},{1}", Kat1, Kat2);
        }
    }
    class TRPiramid:TRTriangle
    {
        //поле висоти
        private double h;
        //метод визначення об'єму
        public void Volume()
        {
            Console.WriteLine("введiть висоту");
            h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Площа дорiвнює");
            Console.WriteLine(Square());
        }
        public new void InPut()
        {
            Console.WriteLine("введiть величину 1 катета");
            K1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введiть величину 2 катета");
            K2 = Convert.ToInt32(Console.ReadLine());
        }
        public new double Square()
        {
            return h*base.Square(K1,K2)/3;
            
        }
    }
}