using System;

namespace Lesson20211219
{
    public delegate int SomeDelegate(int x, int y);

    class Program
    {
        static public int sum(int num1, int num2) => num1 + num2;
        static public int mult(int num1, int num2) => num1 * num2;
        static public int sub(int num1, int num2) => num1 - num2;

        static void Main(string[] args)
        {
            Printer prt1 = new("Floor1Pr1");
            Printer prt2 = new("Floor1Pr2");
            User1 user1 = new("Itay", prt1);
            User1 user2 = new("Daniel", prt1, prt2);
            User2 user3 = new("Ariel", prt1);
            User2 user4 = new("Adir", prt2);

            Console.WriteLine("Let's print 10 pages");
            prt1.Print(10);
            //prt.PageOver();
            Console.WriteLine("Let's print 16 pages");
            prt1.Print(16);
            prt2.Print(25);

            //SomeDelegate myDlgt = new SomeDelegate(sum);
            //myDlgt += mult;
            //myDlgt += sub;
            //myDlgt -= sum;
            //Console.WriteLine(myDlgt(2, 3));

            //foreach (var d in myDlgt.GetInvocationList())
            //    Console.WriteLine(d.Method);

            //if (myDlgt is Delegate) 
            //    Console.WriteLine("myDlgt is Delegate == true");

            //foreach (var item in myDlgt.GetInvocationList())
            //    Console.WriteLine(item.DynamicInvoke(3, 2));

            //foreach (SomeDelegate item in myDlgt.GetInvocationList())
            //    Console.WriteLine(item(3, 2));

            //Action<int, int> act = delegate (int x, int y) { Console.WriteLine(x + y); };
            //act += delegate (int x, int y) { Console.WriteLine(x - y); };

            //act(4, 3);

            //((Action<int, int>)(act.GetInvocationList()[1]))(5, 3);
            //act.GetInvocationList()[1].DynamicInvoke(5, 3);

            //MyClass obj = new();

            //Console.WriteLine(obj?.ToString());
        }
    }
}
