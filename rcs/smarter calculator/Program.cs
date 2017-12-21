using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarter_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //izveido kalkulatora objektu

            //paprasīt ievadīt ievadi
            Console.WriteLine("Please enter darbiba");
            string input = Console.ReadLine();

            int result = pareser.();

            //"1+4-5" skaits ir 5 pārējā simbola pozīcija ir 4
            //"1+" skaits ir 2, pēdēja pozīcija ir  1
            int result;
            string FirstenteredNumber = "";
            string SecondtenteredNumber = "";

            char enteredOperation = '';
            bool opertionFound = false;
            
            int counter = 0;
            while (counter < input.Length) 
            {
                char symbol = input[counter];
                if(symbol == '+')
                {
                    ///Saglabā operāciju mainīgajā
                    enteredOperation = symbol;
                    //ielikt karodziņu, ka tad tiks pabeigts

                    //ielaist nākošo skaitli, operācija ir jāizpilda
                    opertionFound = true;
                }
                else
                {
                    if  (opertionFound == false)
                    {

                    }
                    //saglabāt simbolu teksta virknē, lai tam
                    //var piekļūt, kad tiek veikta darbība

                    FirstenteredNumber = FirstenteredNumber + symbol;

                    int number;
                    number = Int32.Parse(symbol.ToString());
                    Console.WriteLine("number" + number);

                }
                counter = counter + 1;
            }
            Console.ReadLine();
        }
    }
}
