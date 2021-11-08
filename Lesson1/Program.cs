using System;

Console.WriteLine("Hello World!");

Console.Read();

Object obj = new Object();
Dabush a = new ();
Console.WriteLine(obj);
Console.WriteLine(a);

MyStruct str;// = new(); // { Num = 3 };
str.Num = 20;
str.D = new();
Console.WriteLine(str);

object obj2 = 11;
int num2 = (int)obj2;

struct MyStruct
{
    public int Num;
    public Dabush D;
}

class Dabush {
    int i1 = 10;
    static int si1 = 99;

    public Dabush(int n) => i1 = n;
    public Dabush() { }

    public override string ToString()
    {
        return "Itay Dabush from K.Herzog";
    }
}

class Son : Dabush
{
    public Son() // : base(-8)
    {
        Console.WriteLine("Son ctor");
    }
}



