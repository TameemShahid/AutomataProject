using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RegularExpressions to use the functionalities of Regex
using System.Text.RegularExpressions;
//Using System.IO for filing
using System.IO;

namespace AutomataProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Defining the Path to the file
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

            DecimalPattern(file);
            Console.WriteLine();

            OperatorsPattern(file);
            Console.WriteLine();
        }

        //Function to check email patterns
        public static void EmailPattern(string file)
        {
            //can begin from any combination of (a-z + A-Z)+ followed by any combination of (0-9)*
            //followed by (_,-,.)* followed by any combination of (0-9)*(a-z + A-Z)*(0-9)*
            //followed by @ followed by (a-z) followed by .com
            string pattern = @"\b[a-zA-Z]+[0-9]*[_,-,.]*[0-9]*[a-zA-Z]*[0-9]*\@[a-z]*\.com";

            Console.WriteLine("Email patterns found:");
            CheckPattern(file, pattern);
        }

        //function to check CNIC patterns
        public static void CNICPattern(string file)
        {
            //can begin with any combination of 5 digits followed by "-" (or not)
            //then followed by any combination of 7 digits followed by "-" (or not)
            //followed by any combination of a digit 
            //OR
            //Any combination of 13 digit number
            string pattern = @"\b\d{5}-\d{7}-\d{1}\b|\b\d{13}\b";

            Console.WriteLine("CNIC patterns found:");
            CheckPattern(file, pattern);
        }

        //Function to match floating numbers
        public static void FloatPattern(string file)
        {
            //any combo. of digits followed by "." then any combo. of digits
            string pattern = @"\b[0-9]+\.[0-9]+\b";

            Console.WriteLine("Float Numbers found:");
            CheckPattern(file, pattern);
        }

        //Function to check Header Files
        public static void LibraryPattern(string file)
        {
            //keyword "lib" followed by an "(" then any combo. of (a-z+A-Z)
            //followed by "." then "h" and then ")"
            string pattern = @"lib\([a-zA-Z]*\.h\)";

            Console.WriteLine("Libraries Found:");
            CheckPattern(file, pattern);
        }


        //function to check Keywords in the language
        public static void KeywordPattern(string file)
        {
            //pattern containing all the keywords in the language
            string pattern = @"num|dec|str|if|rather|either|iter|show|record|initial\(\)";

            Console.WriteLine("Keywords Found:");
            CheckPattern(file, pattern);
        }

        //function to check special characters in the language
        public static void SpecialCharPattern(string file)
        {
            //Anything that is NOT (a-z + A-Z + 0-9) is a special keyword
            string pattern = @"[^a-zA-Z0-9]*";

            Console.WriteLine("Special Characters found:");
            CheckPattern(file, pattern);
        }

        //function to check identifiers in the language
        public static void IdentifierPattern(string file)
        {
            //All the combo. of (a-z + A-Z + _)+ followed by any combo. of (0-9)* followed by any combo. of (a-z + A-Z + _)*
            //followed by any combo. of (0-9)* EXCEPT/EXCLUDING all the KEYWORDS
            string pattern = @"\b(?!num|dec|str|if|rather|either|lib\(?.*\)?|iter|show|record|initial\(\))\b[a-zA-Z_]+[0-9]*[a-zA-Z_]*[0-9]*";

            Console.WriteLine("Identifiers found:");
            CheckPattern(file, pattern);
        }

        //function to check decimal numbers
        public static void DecimalPattern(string file)
        {
            //combination of digits with atleast one occurence
            string pattern = @"\b[0-9]+\b";

            Console.WriteLine("All the decimal numbers found:");
            CheckPattern(file, pattern);
        }

        //function to check all the operators
        public static void OperatorsPattern(string file)
        {
            //pattern containing all the operators 
            string pattern = @"\b[\+\-\*\/\%\=\!\<\>]\b|(\=\=)|(\!\=)|(\<\=)|(\>\=)";

            Console.WriteLine("All the operators found:");
            CheckPattern(file, pattern);
        }

        //Utility function that takes the file and a pattern as parameter to check words of the file against the pattern
        public static void CheckPattern(string file, string pattern)
        {
            //line variable to store the lines in the file
            string line = "";
            //An array that will store the words of the read line
            string[] words;
            //Match variable to store regex matching result
            Match result;

            //Using StreamReader to read lines
            using (StreamReader reader = new StreamReader(file))
            {
                //while the read line contains some data
                while ((line = reader.ReadLine()) != null)
                {
                    //fill the array with words by splitting the line on white spaces
                    words = line.Split(null);

                    //loop that will run for all the words in the array
                    for (int i = 0; i < words.Length; i++)
                    {
                        //Match word at ith index with the pattern
                        result = Regex.Match(words[i], pattern);

                        //if match result is successful and result does not contain white spaces
                        if (result.Success && result.Value != "")
                        {
                            //print the match result value
                            Console.WriteLine(result.Value);
                        }
                    }
                }
            }
        }
    }
}
