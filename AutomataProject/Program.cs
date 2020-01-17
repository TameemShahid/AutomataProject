using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AutomataProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\Tameem Shahid\Desktop\SampleCode.txt";

            LibraryPattern(file);
            Console.WriteLine();

            KeywordPattern(file);
            Console.WriteLine();

            SpecialCharPattern(file);
            Console.WriteLine();

            IdentifierPattern(file);
            Console.WriteLine();

            FloatPattern(file);
            Console.WriteLine();
        }

        public static void EmailPattern(string file)
        {
            string pattern = @"\b[a-zA-Z]*[0-9]*[_,-,.]*[0-9]*[a-zA-Z]*[0-9]*\@[a-z]*\.com";

            Console.WriteLine("Email patterns found:");
            CheckPattern(file, pattern);
        }

        public static void CNICPattern(string file)
        {
            string pattern = @"\b\d{5}-\d{7}-\d{1}\b|\b\d{13}\b";

            Console.WriteLine("CNIC patterns found:");
            CheckPattern(file, pattern);
        }

        public static void FloatPattern(string file)
        {
            string pattern = @"[0-9]+\.[0-9]+";

            Console.WriteLine("Float Numbers found:");
            CheckPattern(file, pattern);
        }

        public static void LibraryPattern(string file)
        {
            string pattern = @"lib\([a-zA-Z]*\.h\)";

            Console.WriteLine("Libraries Found:");
            CheckPattern(file, pattern);
        }

        public static void KeywordPattern(string file)
        {
            string pattern = @"num|dec|str|if|rather|either|iter|show|record|initial\(\)";

            Console.WriteLine("Keywords Found:");
            CheckPattern(file, pattern);
        }

        public static void SpecialCharPattern(string file)
        {
            string pattern = @"[^a-zA-Z0-9]*";

            Console.WriteLine("Special Characters found:");
            CheckPattern(file, pattern);
        }

        public static void IdentifierPattern(string file)
        {
            string pattern = @"\b(?!num|dec|str|if|rather|either|lib\(?.*\)?|iter|show|record|initial\(\))\b[a-zA-Z_]+[0-9]*[a-zA-Z_]*[0-9]*";



            Console.WriteLine("Identifiers found:");
            CheckPattern(file, pattern);
        }

        public static void CheckPattern(string file, string pattern)
        {
            string line = "";
            string[] words;
            Match result;

            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    words = line.Split(null);

                    for (int i = 0; i < words.Length; i++)
                    {
                        result = Regex.Match(words[i], pattern);

                        if (result.Success && result.Value != "")
                        {
                            Console.WriteLine(result.Value);
                        }
                    }
                }
            }
        }
    }
}
