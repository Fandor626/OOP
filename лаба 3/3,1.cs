using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr2Task1
{

    class Program
    {
        static void Main(string[] args)
        {
            //вивід 1 матриці
            Console.WriteLine("Перша матриця з масивв рядкв");
            string[] temp = { "1 3 4", "5 7 8", "9 10 12" };
            MyMatrix mat = new MyMatrix(temp);
            Console.WriteLine(mat);
            //вивід 2 матриці
            Console.WriteLine("Друга матриця з одного рядка");
            string temp2 = "10 12 15/15 8 5/17 22 9";
            MyMatrix mat2 = new MyMatrix(temp2);
            Console.WriteLine(mat2);
            //вивід суми двох матриць
            Console.WriteLine("Сума двох матриць");
            Console.WriteLine(mat + mat2);
            //вивід добутку
            Console.WriteLine("Добуток двох матриць");
            Console.WriteLine(mat * mat2);
            //вивід транспонованої матриці
            Console.WriteLine("Транспонована друга матрица");
            Console.WriteLine(mat2.GetTransponedCopy());
            Console.ReadKey();
        }
    }
    class MyMatrix
    {
        //створення поля
        protected double[,] _matrix;
        //копіюючий конструктор
        public MyMatrix(MyMatrix mat)
        {
            MyMatrix _matrix = mat;
        }       
        //зубчастий
        public MyMatrix(double[,] mat)
        { _matrix = mat; }
        public MyMatrix(double[][] _matrix)
        {
            bool isrectangular = true;
            for (int i = 0; isrectangular && i < _matrix.Length; i++)
            {
                for (int j = 0; isrectangular && j < _matrix[i].Length; j++)
                {
                    if (_matrix[i].Length != _matrix[0].Length)
                    {
                        Console.WriteLine("Матрица не прямоугольная. Невозможно применить");
                        isrectangular = false;
                    }
                    this._matrix[i, j] = _matrix[i][j];
                }
            }
        }
        public MyMatrix(string[] mat)
        {
            int[] temp;
            double[,] temp2 = new double[mat.Length, mat.Length];
            for (int i = 0; i < mat.Length; i++)
            {
                temp = mat[i].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    temp2[i, j] = temp[j];
                }
            }
            _matrix = temp2;
        }
        public MyMatrix(string mas)
        {
            string[] temp1 = mas.Split('/');
            int[] temp;
            double[,] output = new double[temp1.Length, temp1.Length];
            for (int i = 0; i < temp1.Length; i++)
            {
                temp = temp1[i].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    output[i, j] = temp[j];
                }
            }
            _matrix = output;
        }
        //оператор+
        public static MyMatrix operator +(MyMatrix mass1, MyMatrix mass2)
        {
            return MyMatrix.Sum(mass1, mass2);
        }
        public static MyMatrix multiply(MyMatrix a, MyMatrix b)
        {
            double[,] array1 = new double[a.GetHeight(), b.GetWidth()];
            for (int i = 0; i < a.GetWidth(); i++)
            {
                for (int j = 0; j < b.GetWidth(); j++)
                {
                    for (int k = 0; k < b.GetWidth(); k++)
                    {
                        array1[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            MyMatrix resMass = new MyMatrix(array1);
            return resMass;
        }
        // оператор *
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            return MyMatrix.multiply(a, b);
        }
        override public String ToString()
        {
            string output = "";

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {

                for (int j = 0; j < _matrix.GetLength(1); j++)
                {

                    output += _matrix[i, j] + " ";
                }
                output += Environment.NewLine;
            }
            return output;
        }
        public int GetHeight()
        {
            return Height();
        }
        public int GetWidth()
        {
            return Width();
        }
        private int Height()
        {
            return _matrix.GetLength(0);
        }
        private int Width()
        {
            return _matrix.GetLength(1);
        }
        //Java-style
        public double this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }
        public static MyMatrix Sum(MyMatrix mass1, MyMatrix mass2)
        {
            double[,] array1 = new double[mass1.GetHeight(), mass1.GetWidth()];
            if (mass1.GetHeight() != mass2.GetHeight() || mass1.GetWidth() != mass2.GetWidth())
            {
                Console.WriteLine("Матрицi рiзнi. Неможливо виконати додавання");
            }
            else
            {
                for (int i = 0; i < mass1.GetHeight(); i++)
                {

                    for (int j = 0; j < mass1.GetWidth(); j++)
                    {
                        array1[i, j] = mass1[i, j] + mass2[i, j];
                    }
                }
            }
            MyMatrix resMass = new MyMatrix(array1);
            return resMass;
        }
        protected double[,] GetTransponedArray()
        {
            double[,] transp = new double[_matrix.GetLength(0), _matrix.GetLength(1)];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    transp[i, j] = _matrix[j, i];
                }
            }
            return transp;
        }
        public MyMatrix GetTransponedCopy()
        {
            MyMatrix res = new MyMatrix(GetTransponedArray());
            return res;
        }
        public void TransponeMe()
        {
            this._matrix = GetTransponedArray();
        }

    }
}
