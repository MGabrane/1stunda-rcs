using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkolators
{
    class kalklators1
    {
        public int AskUserForNumber()
        {
            //izvadīt tekstu, kas paprasa ciparu
            Console.WriteLine("Please enter number");
            //ielaist ciparu
          
            int number;
            string inputText = Console.ReadLine();

            //pārveido lietotaja textu par ciparu
            bool success = Int32.TryParse(inputText, out number);


            if(success == false)
            {
                Console.WriteLine("Sorry, wrong value entered");
                number = this.AskUserForNumber();
            }
            return number;

        }
    }
}
