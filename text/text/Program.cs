using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            for(int i = 0;i<1000;i++)
            {
                a.Add(i);
            }
            foreach(int i in a)
            {
                Console.Write(i + ",");
            }
        }
    }
}
