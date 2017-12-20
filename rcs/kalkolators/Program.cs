using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkolators
{
    class Program
    {
        static void Main(string[] args)
        {
            //izveidot kalkulatora objektu
            kalklators1 calc;
            calc = new kalklators1();


            //paprasit lietotajam vērtību
            int FirstNumber = calc.AskUserForNumber();
            //otra vertība

            int SecondNumber = calc.AskUserForNumber();
            //saskaita
            int result = FirstNumber + SecondNumber;
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
