using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarter_calculator
{
    class MathParser
    {
        //funkcija, kas saņem lietotāja ievadītu tekst
        //saparsē un veic matemātiskās darbības
        //atgriež rezultatu
        public int ParsentMath(string input);
        static void Main(string[] args)
        {
            //izveido kalkulatora objektu
            MathParser parser;
            parser = new MathParser();

            //paprasīt ievadīt ievadi
            Console.WriteLine("Please enter darbiba");
            string input = Console.ReadLine();

            //Izsauc aprēķinātu funkciju un saglabāt rezultātu
            int result = parser.ParserMath();

            //Izvada rezultatu uz ekrana
            Console.WriteLine("your result" + result);
            }
            Console.ReadLine();
        }
    }
}
