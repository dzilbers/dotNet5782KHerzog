using System;
using System.Collections;
using System.Linq;

namespace linq
{
    class Program
    {
        static int count = 0;
        static int DigitCount(int num)
        {
            ++count;
            int digits = 1;
            while (num > 9)
            {
                ++digits;
                num /= 10;
            }
            return digits;
        }

        static void Main(string[] args)
        {
            int[] nums1 = { 5, 9, 4, 1, 5, 6, 8 };
            var nums2 = nums1.Where(x => x % 2 == 0)
                             //.Select(x => $"Number #{x}"); //.ToList();
                             .Select(x => new { Ariel = x, Meir = x * 2 }); //.ToList();
            foreach (var item in nums2)
                Console.Write($"{item},");
            Console.WriteLine();

            // Identical to nums2:
            var nums3 = from /*int*/ item1 in nums1
                        where item1 % 2 == 0
                        select new { Ariel = item1, Meir = item1 * 2 };

            var nums5 = nums1.Select(x => x * 2)
                             .Where(x => x % 3 == 0);
            //.Select(x => x * 2);
            //var nums4 = from item2 in
            //            select item2 * 2 // ERROR
            //            where item2 % 2 == 0;

            ArrayList arr = new() { };
            // arr.Where(x => true); //
            var result1 = arr.OfType<int>()
                             .Where(x => x % 2 == 0)
                             .Select(x => $"Number #{x}");
            //var arr2 = result1.AsEnumerable();

            int[] numbersA = { 123, 54675, 2345, 23, 345, 8 };
            int[] numbersB = { 2, 3, 4 };
            count = 0;
            Console.WriteLine("start");
            var result2 = from num1 in numbersA
                          from num2 in numbersB
                          where DigitCount(num1) == num2
                          select num1;
            foreach (var num in result2)
                Console.Write($"{num},");
            Console.WriteLine($"\n{count}");

            count = 0;
            Console.WriteLine("start");
            var result3 = from num1 in numbersA
                          let digits = DigitCount(num1)
                          from num2 in numbersB
                          where digits == num2
                          select num1;
            foreach (var num in result3)
                Console.Write($"{num},");
            Console.WriteLine($"\n{count}");

            string[] children = { "Rami", "Sarit", "Eliora", "Hananel", "Efrat" };
            foreach (var kid in children.OrderByDescending(s => s.Length)
                                        .ThenBy(s => s))
                Console.WriteLine(kid);

            var grouped1 = children.GroupBy(kid => kid.Substring(0, 1));
            foreach (var group in grouped1)
            {
                Console.WriteLine(group.Key);
                foreach (var kid in group)
                    Console.WriteLine($"  * {kid}");
            }

            var grouped2 = from kid in children
                           group kid.Substring(1) by kid.Substring(0, 1);
            foreach (var group in grouped2)
            {
                Console.WriteLine($"{group.Key}-");
                foreach (var kid in group)
                    Console.WriteLine($" -{kid}");
            }

        }
    }
}
