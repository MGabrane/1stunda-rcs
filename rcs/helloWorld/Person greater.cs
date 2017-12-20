using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloWorld
{
    class Person_greater
    {
        public string HelloText;
        public void SayHello()
        {
            string myName;
            myName = Console.ReadLine();
            Console.WriteLine(HelloText + myName);
        }
    }
}
