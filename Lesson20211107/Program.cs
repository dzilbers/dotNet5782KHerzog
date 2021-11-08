using System;

namespace Lesson20211107
{
    class Program
    {
        static void Main(string[] args)
        {
            int i1 = 1, i2, i3 = 3;
            Console.WriteLine(func(ref i1, out i2, in i3));
            Console.WriteLine(sum());
            Console.WriteLine(sum(1));
            Console.WriteLine(sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            named(1, parm3: "Adir", parm2: 2.5);
            named(1, parm3: "Yair");

            outer();


            int[] arr = { 1, 2, 3, 4, 5 };
            //var (a, b, rest) = arr;

            MyClass1 o1 = new();
            MyClass2 o2 = (MyClass2)o1;
        }

        static (int, double) intDouble(in string s)
        {
            return (int.Parse(s), double.Parse(s));
        }

        static int switchy(object o) => o switch
        {
            int => (int)o,
            string => int.Parse("" + o),
            _ => 0
        };

        static int field = 9;
        static void outer()
        {
            int number = 99;
            Console.WriteLine("Outer: " + field + number);
            inner();
            sInner();
            void inner() { Console.WriteLine("Inner" + field + number); }
            static void sInner() { Console.WriteLine("Static Inner" + field /*+ number*/); }
        }

        static void named(int parm1, double parm2 = 0.0, string parm3 = "Daniel")
        {
            Console.WriteLine("" + parm1 + parm2 + parm3);
        }

        static int func(ref int ref1, out int out2, in int in3)
        {
            out2 = in3; // mandatory to assign a value
            ref1 = out2; // possible but not mandatory
            //in3 = 3; // error
            return -1;
        }

        static int sum(params int[] numbers)
        {
            int s = 0;
            foreach (int num in numbers)
                s += num;
            return s;
        }

    }

    class MyClass1 { }
    class MyClass2 {
        public static explicit operator MyClass2(MyClass1 o) => new MyClass2();
    }

}
