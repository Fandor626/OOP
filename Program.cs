using System;
using System.Numerics;

namespace ConsoleApp186
{
    class Program
    {
        static void Main(string[] args)
        {
            Strings stringg = new Strings();
            stringg.OutPut();
            //Nums num = new Nums();
            //num.OutPut();
            //SmallNums smallnum = new SmallNums();
        }
    }
    public class Strings 
    {
        string str;
        public double Length()
        {
            Input();
            int Out =str.Length;
            return Out;
        }
        public void Input()
        {
            str = "dfsdffxgdfsdf";
        }
        public void OutPut()
        {
            Console.WriteLine(Length());
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'f')
                {
                    str = str.Insert(++i,"...");
                }
            }
            Console.WriteLine(str);
        }
    }
    public class Nums : Strings
    {
        string str;
        public Nums(string Str) {str=Str; }
        public new void Input ()
        {
            str = "12354895";
        }
        public new void OutPut()
        {
            Input();
            Console.WriteLine(str.Length);
        }
    }
    public class SmallNums : Strings
    {
        string strSmall;
        public SmallNums(string Strsmall) { strSmall = Strsmall; }
            public void input()
        {
            strSmall="fghfgh";
        }   
        public new void OutPut()
        {
            Console.WriteLine(strSmall.Length);
        }

    }
}
