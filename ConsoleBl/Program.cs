using System;
using BlApi;
using BO;

namespace ConsoleBl
{
    class Program
    {
        static void Main(string[] args)
        {
            IBl bl = BlFactory.GetBl();
            Console.WriteLine("Hello World!");
        }
    }
}
