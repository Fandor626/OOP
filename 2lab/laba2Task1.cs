using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp169
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введiть розмiрнiсть матрицi N/M");
            int nn = Convert.ToInt32(Console.ReadLine());
            int mm= Convert.ToInt32(Console.ReadLine());
            Matrix mass1 = new Matrix(nn,mm);            
            Console.WriteLine("введення матрицi: ");
            mass1.WriteMat();
            Console.WriteLine("вивiд матрицi");
            mass1.ReadMat();
            Console.WriteLine("вивiд максимального значення матрицi");
            mass1.MaxMat();
            Console.WriteLine("вивiд мiнiмального значення матрицi");
            mass1.MinMat();
            Console.ReadKey();
        }
    }
    class Matrix
    {
        //призовані поля 
        private int n;
        private int m;
        private int[,] mass;
        //створення конструкторів матриці
        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public int M
        {
            get { return m; }
            set { if (value > 0) n = value; }
        }     
        //задання індексаторів 
        public Matrix(int n,int m)
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }   
        //метод введення матриці
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введiть елементи матрицi  {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        //метод виведення матриці
        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        //метод знаходження максимального значення
        public void MaxMat()
        {
            int Max = mass[0, 0];

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] > Max)
                    {
                        Max = mass[i, j];
                    }
                }
            }
            Console.WriteLine(Max);
        }
        //метод знаходження мінімального значення
        public void MinMat()
        {
            int min = mass[0, 0];

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] < min)
                    {
                        min = mass[i, j];
                    }
                }
            }
            Console.WriteLine(min);
        }
    }
}
