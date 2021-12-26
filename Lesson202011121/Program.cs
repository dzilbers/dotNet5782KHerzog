using System;

namespace Lesson202011121
{
    interface IDoing
    {
        void Foo1();
        void Foo2() { Console.WriteLine("IDoing:Foo2"); }
    }

    class B : IDoing
    {
        public void Foo1() { Console.WriteLine("B:Foo1"); }
    }

    abstract class C : B
    {
        public abstract void Foo2();
    }

    class D : C
    {
        public override void Foo2() { Console.WriteLine("D:Foo2"); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IDoing obj = new D();
            obj.Foo1();
            obj.Foo2();
        }
    }
}
