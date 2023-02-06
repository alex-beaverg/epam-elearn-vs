using System;
using System.Collections.Generic;

// Developments and build tools
// Unit Test Frameworks (I use MSTest(Auto))
namespace differentSymbols
{
    public class maxDifferentSymbols
    {
        public static void Main()
        {
            // Declare variables and initialize
            String dataString = "lijerkfhnewkruhwkrehhhlkrrfflqwnrjl3j534457onawlifelri7e98798888cnffkaeuhrcnaku545";

            // Result #1
            Console.Write("New string with maximum different symbols in String: ");
            Console.WriteLine(maxDiffSymbols(dataString));
            Console.WriteLine("\r");

            // Result #2
            Console.Write("New string with maximum same symbols in String: ");
            Console.WriteLine(maxSameSymbols(dataString));
            Console.WriteLine("\r");

            // Result #3
            Console.Write("New string with maximum same numbers in String: ");
            Console.WriteLine(maxSameNumbers(dataString));
            Console.WriteLine("\r");            
        }
                
        // Method #1: For maximum different symbols in String (-> 'rators')
        public static string maxDiffSymbols(string str)
        {
            char c = '\r';
            String strNew = "";
            List<string> list = new List<string>();
            foreach (var ch in str)
            {
                if (ch != c)
                {
                    c = ch;
                    strNew += ch;
                }
                else
                {
                    list.Add(strNew);
                    strNew = ch.ToString();
                }
            }
            list.Add(strNew);
            int length = 0;
            foreach (var item in list)
            {
                if (item.Length > length)
                {
                    length = item.Length;
                    strNew = item;
                }
            }
            return strNew;
        }

        // Method #2. For maximum same symbols a-Z in String (-> 'gggg')
        public static string maxSameSymbols(string str)
        {

            char c = char.Parse(str.Substring(0, 1));
            String strNew = "";
            List<string> list = new List<string>();
            foreach (var ch in str)
            {
                if (ch == c && !Char.IsNumber(ch))
                {
                    strNew += ch;
                }
                else
                {
                    list.Add(strNew);
                    strNew = ch.ToString();
                    c = ch;
                }
            }
            list.Add(strNew);
            int length = 0;
            foreach (var item in list)
            {
                if (item.Length > length)
                {
                    length = item.Length;
                    strNew = item;
                }
            }
            return strNew;
        }

        // Method #3. For maximum same symbols 0-9 in String (-> '222222')
        public static string maxSameNumbers(string str)
        {

            char c = char.Parse(str.Substring(0, 1));
            String strNew = "";
            List<string> list = new List<string>();
            foreach (var ch in str)
            {
                if (ch == c && Char.IsNumber(ch))
                {
                    strNew += ch;
                }
                else
                {
                    list.Add(strNew);
                    strNew = ch.ToString();
                    c = ch;
                }
            }
            list.Add(strNew);
            int length = 0;
            foreach (var item in list)
            {
                if (item.Length > length)
                {
                    length = item.Length;
                    strNew = item;
                }
            }
            return strNew;
        }
    }
}
