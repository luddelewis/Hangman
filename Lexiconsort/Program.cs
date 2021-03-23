using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lexiconsort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool saveIndex3 = true;
            bool saveIndex6 = true;
            int indexOf3;
            int indexOf6;
            List<string> rawLexicon = File.ReadAllLines("../../Hanglexicon.txt", Encoding.Default).ToList();
            rawLexicon = rawLexicon.OrderBy(a => a.Length).ToList();
            for()
            {
                Console.WriteLine(s);
                if (s.Length == 3 && saveIndex3)
                {

                }
            }
            Console.WriteLine(rawLexicon.ToArray().Length);
            Console.ReadLine();




        }
    }
}
