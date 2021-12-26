using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20211219
{
    public class MyClass
    {
        public int num;
    }

    public class PrinterEventArgs : EventArgs
    {
        public int NotPrinted { get; init; } = 0;
        public bool Handled { get; set; } = false;
        public PrinterEventArgs(int pages) => NotPrinted = pages;
    }

    public class Printer
    {
        public string Name { get; set; }
        public Printer(string name) => this.Name = name;

        public event EventHandler<PrinterEventArgs> PageOver = null;
        private int pageCount = 20;
        private void handlePageOver(int pages)
        {
            if (PageOver != null) PageOver(this, new PrinterEventArgs(pages));
            //PageOver?.DynamicInvoke();

        }
        public void Print(int pages)
        {
            if (pages <= pageCount) pageCount -= pages;
            else { handlePageOver(pages - pageCount); pageCount = 0; }
        }
        public void AddPaper(int pages) => pageCount += pages;
    }

    public class User1
    {
        List<Printer> prtrs = new();
        string name;

        public User1(string name, params Printer[] prts)
        {
            this.name = name;
            foreach (var prt in prts)
            {
                this.prtrs.Add(prt);
                prt.PageOver += Prt_PageOver;
            }
        }

        private void Prt_PageOver(object sender, PrinterEventArgs pev)
        {
            if (pev.Handled) return;
            Printer prt = sender != null ? (Printer)sender
                                         : throw new NullReferenceException();
            Console.WriteLine($"{name}: Sorry, I am busy. Somebody else will bring {pev.NotPrinted} paper for {prt.Name}");
        }
    }

    public class User2
    {
        Printer prt;
        string name;

        public User2(string name, Printer prt)
        {
            this.prt = prt;
            this.name = name;
            prt.PageOver += myPageOver;
        }

        private void myPageOver(object sender, PrinterEventArgs pev)
        {
            if (pev.Handled) return;
            Printer prt = sender != null ? (Printer)sender
                                         : throw new NullReferenceException();
            Console.WriteLine($"{name}: Bringing paper: {prt.Name}, missing : {pev.NotPrinted})");
            prt.AddPaper(30);
            pev.Handled = true;
        }
    }
}
