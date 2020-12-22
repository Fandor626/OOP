using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp179
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            string str1;
            string str2;
            long summ = 0;
            long nGood = 0;
            int TempMultiply = new Int32();
            for (int i = 10; i < 30; i++)
            {
                string path = @"E:\duniver\ООП\laba 4\" + i + ".txt";
                try
                {
                    StreamReader f = new StreamReader(path);
                    str1 = f.ReadLine();
                    a = Convert.ToInt32(str1);
                    str2 = f.ReadLine();
                    b = Convert.ToInt32(str2);
                    checked
                    {
                        TempMultiply = a * b;
                    }
                    Console.WriteLine("Добуток чисел у файлi " + i + ".txt" + " : " + TempMultiply);
                    summ += TempMultiply;
                    nGood++;
                    f.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"E:\duniver\ООП\laba 4\lr1\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i + ".txt");
                    }
                }
                catch (System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"E:\duniver\ООП\laba 4\lr1\bad_data.txt", true, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {
                    using (StreamWriter overflow = new StreamWriter(@"E:\duniver\ООП\laba 4\lr1\overflow.txt", true, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Доступу до файлу немає. Можливо його вже було створено");
                    break;
                }
            }
            Console.WriteLine("Загалом нормальних файлiв {0}. Середнє арифметичне добутку двох чисел з цих файлiв = {1}", nGood, summ / (double)nGood);
            Console.ReadKey();
        }
    }
}

