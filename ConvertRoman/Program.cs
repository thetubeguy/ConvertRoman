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

            int usernum = 59;

            string output="";

            recursenumerals(usernum, ref output);

            void recursenumerals(int num, ref string output)
            {

                for (int index = 0; index < 4; index++)
                {
                
                    if ((num >= symbolarray[index].decim) && (num < symbolarray[index + 1].decim))
                    {
                        int remaining = 0;

                        if (num == 9)
                        {
                            output += "IX";
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
           
        }
    }   
}
