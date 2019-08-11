using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<test> d = new List<test>();
            d.Add(new test() { id = 1, name = "222" });
            d.Add(new test() { id = 2, name = "2221" });
            d.Add(new test() { id = 3, name = "2221" });
            d.Add(new test() { id = 4, name = "222" });
            var sas= d.Find(x => x.name == "222", x => x.id = 1).FirstOrDefault();
            Console.WriteLine(sas.id);


        }
    }
    class test
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
