using System;
using System.Reflection;

namespace Lesson20211212
{

    class MyClass
    {
        public int Id;
        public string Name;
    }

    static class Tools
    {
        public static int ToInt(this string str) => int.Parse(str);
        public static void Parse(this ref int num, string str) => num = str.ToInt();

        public static void ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            Console.WriteLine(str);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// THe most main Main function
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            int? a = 8;
            a = null;
            int b = a ?? 0;
            b = a != null ? (int)a : throw new ArgumentException("bla bla bla");
            
            var anonim1 = new { Id = 1234, Name = "Yossi" };

            Console.WriteLine("=========================");
            12.ToStringProperty();
            Console.WriteLine("=========================");
            DateTime.Now.ToStringProperty();
            Console.WriteLine("=========================");
            int? num = 13;
            num.ToStringProperty();
            Console.WriteLine("=========================");
            anonim1.ToStringProperty();

            //string  sNum = "1234";
            //int num1 = sNum.ToInt();
            //int num2 = "3456".ToInt();
            //int num3 = 0;
            //num3.Parse("5678");
            //Console.WriteLine(num3);

            //printInfo("  ", typeof(MyClass));

            //Console.WriteLine(anonim1);
            //Console.WriteLine("================================");
            //printInfo("  ", anonim1.GetType());
            //Console.WriteLine("================================");
            //var anonim2 = new { Id = 2.5, Name = 88 };
            //var anonim3 = new { Name = "Chaim", Id = 2345 };
            //var anonim4 = new { Id = 1234, Name = "Yossi" };
            //Console.WriteLine($"anonim1 type: {anonim1.GetType().Name}");
            //Console.WriteLine($"anonim2 type: {anonim2.GetType().Name}");
            //Console.WriteLine($"anonim3 type: {anonim3.GetType().Name}");
            //Console.WriteLine($"anonim4 type: {anonim4.GetType().Name}");

            //Console.WriteLine($"anonim1 == anonim4: {anonim1 == anonim4}");
            //Console.WriteLine($"anonim1.Equals(anonim4): {anonim1.Equals(anonim4)}");
            //Console.WriteLine($"anonim1 hash: {anonim1.GetHashCode()}");
            //Console.WriteLine($"anonim4 hash: {anonim4.GetHashCode()}");
        }

        static void printInfo(string suff, Type type)
        {
            Console.WriteLine(suff+"Type Name:" + type.Name);
            Console.WriteLine(suff + "Base Type: ");
            if (type.BaseType == null)
                Console.WriteLine(suff + suff + "None");
            else
                printInfo(suff + "  ", type.BaseType);
            Console.WriteLine(suff + "Member Info:");
            MemberInfo[] members = type.GetMembers(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static | BindingFlags.Instance
                );
            foreach (var item in members)
                Console.WriteLine(suff + "name: {0,-15} type: {2,-11} in: {1}",
                                  item.Name, item.DeclaringType.Name, item.MemberType);
        }
    }
}
