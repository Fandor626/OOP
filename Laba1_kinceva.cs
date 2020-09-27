using System;
using System.Linq;

namespace Laba1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Rnd = new Random();
            int[][] W = new int[5][];
            int[] T=new int[5];
            W[0] = new int[2];
            W[1] = new int[3];
            W[2] = new int[6];
            W[3] = new int[5];
            W[4] = new int[1];
            for (int i = 0; i < W.Length; i++)
            {
                for (int j = 0; j < W[i].Length; j++)
                {
                    W[i][j] = Rnd.Next(-50, 50);                   
                }
            }
            Console.WriteLine("Вивiд матрицi W:");
            foreach (int[] u in W)
            {
                foreach (int v in u)
                {
                    Console.Write("{0, 4}", v);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < W.Length; i++)
            {               
                    Array.Sort(W[i]);               
            }
            Console.WriteLine("Вивiд вiдсортованої матрицi за зростанням W:");
            foreach (int[] u in W)
            {
                foreach (int v in u)
                {
                    Console.Write("{0, 4}", v);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < W.Length; i++)
            {
                Array.Reverse(W[i]);
            }
            Console.WriteLine("Вивiд вiдсортованої матрицi за спаданням W:");
            foreach (int[] u in W)
            {
                foreach (int v in u)
                {
                    Console.Write("{0, 4}", v);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < W.Length; i++)
            {
                T[i]= W[i].Max();     
                
            }
            Console.WriteLine("Вивiд матрицi T - найбiльших елементiв кожного рядка:");
            foreach (int u in T)
            {
                Console.Write("{0, 4}", u);
            }
            Console.WriteLine();
            for (int i = 0; i < W.Length; i++)
            {
                int Min = W[i].Min();
                T[i] = Min;
            }
            Console.WriteLine("Вивiд матрицi T - найменших елементiв кожного рядка:");
            foreach (int u in T)
            {
                Console.Write("{0, 4}", u);               
            }
            Console.ReadKey();
        }
    }
}
