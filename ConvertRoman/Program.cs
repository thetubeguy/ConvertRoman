using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertRoman
{
    internal class Program
    {
        struct Mainsymbol
        {
            public int decim;
            public char roman;
            public Mainsymbol(int decim, char roman) { this.decim = decim; this.roman = roman; }
        }

        
        static void Main(string[] args)
        {
            Mainsymbol[] symbolarray =
            {
                new Mainsymbol(1,'I'),
                new Mainsymbol(5,'V'),
                new Mainsymbol(10,'X'),
                new Mainsymbol(50,'L'),
                new Mainsymbol(100,'C')
            };

           

            string output="";

            Console.WriteLine("Please enter a number between 1 and 99:  ");

          
            int usernum = Convert.ToInt32(Console.ReadLine()); ;

            recursenumerals(usernum, ref output);

            void recursenumerals(int num, ref string output)
            {

                for (int index = 0; index < 4; index++)
                {
                
                    if ((num >= symbolarray[index].decim) && (num < symbolarray[index + 1].decim))
                    {
                        int remaining = 0;
                        string numstring = num.ToString()[..1];

                        if (Int32.Parse(numstring) == 4) 
                        {
                            output += String.Concat(symbolarray[index].roman, symbolarray[index + 1].roman);
                            remaining = num - (symbolarray[index + 1].decim - symbolarray[index].decim);
                        }
                        else if (Int32.Parse(numstring) == 9)
                        {
                            output += String.Concat(symbolarray[index-1].roman , symbolarray[index + 1].roman);
                            remaining = num - (symbolarray[index + 1].decim - symbolarray[index - 1].decim);
                        }
                        else
                        {
                            output += symbolarray[index].roman;
                            remaining = num - symbolarray[index].decim;
                        }

                        if (remaining > 0) recursenumerals(remaining, ref output);

                    }
                }

            }

            Console.WriteLine($"{usernum} is {output} in roman numerals");
           
        }
    }   
}
