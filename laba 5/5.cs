﻿using System;
using System.Numerics;

namespace ConsoleApp185
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            testAPlusBSqrt(new MyFrac(1, 3), new MyFrac(1, 6));
            testAPlusBSqrt(new MyComplex(1, 3), new MyComplex(1, 6));          
            Console.ReadKey();
        }
        static void testSquaresDiff<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine("(a-b) = " + aMinusB);
            Console.WriteLine("(a-b)^2 = " + aMinusB.Multiply(aMinusB));
            Console.WriteLine("a^2-b^2/a+b = " + aMinusB.Multiply(aMinusB) + " / " + aPlusB);

            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");

        }
        static void testAPlusBSqrt<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
                                   // I’m not sure how to create constant factor "2" in more elegant way,
                                   // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
    }
    class MyFrac : IMyNumber<MyFrac>, IComparable
    {

        BigInteger num;
        BigInteger denom;
        public double Value
        {
            get { return (double)num / (double)denom; }
        }
        public MyFrac() { }
        public MyFrac(BigInteger num, BigInteger denom)
        {
            this.num = num;
            this.denom = denom;
        }
        public MyFrac(int num, int denom)
        {
            this.num = num;
            this.denom = denom;
        }
        public double GetValue()
        {
            return ((double)num / (double)denom);
        }
        public MyFrac Add(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom + this.denom * that.num, this.denom * that.denom));
        }
        public MyFrac Subtract(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom - this.denom * that.num, this.denom * that.denom));
        }
        public MyFrac Multiply(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.num, this.denom * that.denom));
        }
        public MyFrac Divide(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom, this.denom * that.num));
        }
        public override string ToString()
        {
            try
            {
                return num + "/" + denom;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
        public MyFrac Normal(MyFrac t)
        {
            BigInteger x, y;
            x = t.num;
            y = t.denom;
            while (y != x && -y != x)
            {
                if (x > y)
                    x = x - y;
                else y = y - x;
            }
            return new MyFrac(t.num / x, t.denom / x);
        }
        public int CompareTo(object o)
        {
            MyFrac one = o as MyFrac;
            if (Value > one.Value)
            {
                return 1;
            }
            else if (Value == one.Value)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    class MyComplex : IMyNumber<MyComplex>
    {
        double re { get; set; }
        double im { get; set; }
        public MyComplex() { }
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex(int re, int im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }
        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(this.re * that.re - this.im * that.im, this.re * that.im + this.im * that.re);
        }
        public MyComplex Divide(MyComplex that)
        {
            try
            {
                return new MyComplex((this.re * that.re + this.im * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2)),
                                  (this.im * that.re - this.re * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2)));
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }

        }
        public override string ToString()
        {
            return re + " + " + im + "i";
        }
    }
}
