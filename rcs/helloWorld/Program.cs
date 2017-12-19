using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Person_greater greet;
            greet = new Person_greater();
            greet.SayHello();
            Console.ReadLine();

        }
    }
}
