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
            //This program was used to find out info about the lexicon for hangman inorder to set the difficulties and also to sort the lexicon by word length
            bool saveIndex4 = true;
            bool saveIndex6 = true;
            bool saveIndex8 = true;
            int indexOf4 = 0;
            int indexOf6 = 0;
            int indexOf8 = 0;
            //Reads the rawLexicon from a textfile in the project files
            List<string> rawLexicon = File.ReadAllLines("../../UnsortedHanglexicon.txt", Encoding.Default).ToList();
            List<string> cookedLexicon = new List<string>();
            // Uses the OrderBy method to sort the words in rawLexicon in ascending order in cookedLexicon
            cookedLexicon = rawLexicon.OrderBy(word => word.Length).ToList();
            //Converting to uppercase
            for(int i = 0; i < cookedLexicon.ToArray().Length; i++)
            {
                cookedLexicon[i] = cookedLexicon[i].ToUpper();
            }
            //Writes the now sorted lexicon into a txt file
            File.WriteAllLines("../../SortedHanglexicon.txt", cookedLexicon.ToArray());
            for(int i = 0; i <rawLexicon.ToArray().Length;i++)
            {
                Console.WriteLine(cookedLexicon[i]);
                //if cases for saving the index of the first word with 4 or 6 letters in cookedLexicon
                if(rawLexicon[i].Length==4 && saveIndex4)
                {
                    indexOf4 = i;
                    saveIndex4 = false;
                }
                if (cookedLexicon[i].Length == 6 && saveIndex6)
                {
                    indexOf6 = i;
                    saveIndex6 = false;
                }
                if (cookedLexicon[i].Length == 8 && saveIndex8)
                {
                    indexOf8 = i;
                    saveIndex8 = false;
                }


            }
            //Printing out the info for the difficulties
            Console.WriteLine("There are "+ cookedLexicon.ToArray().Length + " words in the lexicon");
            Console.WriteLine("The 132th word had " + cookedLexicon[132].Length + " letters");
            Console.WriteLine("The 264th word had " + cookedLexicon[264].Length + " letters");
            Console.WriteLine("The 4 letter words begin at:" + indexOf4);
            Console.WriteLine("The 6 letter words begin at:" + indexOf6);
            Console.WriteLine("The 8 letter words begin at:" + indexOf8);

            Console.ReadLine();




        }
    }
}
