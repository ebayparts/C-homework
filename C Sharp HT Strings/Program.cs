using System;
using System.Linq;
namespace C_Sharp_HT_Strings
{
    class Program
    {
        static string DeleteCharsFromString(ref string text, params char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
                text = text.Replace(chars[i].ToString(), String.Empty);
            return text;
        }
        static void CountAllCharsStat(string text)
        {
            int []statSymb = new int[26];
            text = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 96 && (int)text[i] < 123)
                {
                    statSymb[(int)text[i] - 97]++;
                }
            }
            for (int i = 0; i < statSymb.Length; i++)
            {
                if (statSymb[i] > 0)
                {
                    Console.Write($"\n{Convert.ToChar(i + 97)} [{statSymb[i]}] ");
                    for (int j = 0; j < statSymb[i]; j++)
                        Console.Write("*");
                }
            }
        }
        static void Main(string[] args)
        {
            string text = "A  string is a sequential collection of characters that's used to represent text. A String object is a sequential collection of System.Char objects that represent a string; " +
                "a System.Char object corresponds to a UTF-16 code unit. The value of the String object is the content of the sequential collection of System.Char objects, and that value is immutable (that is, it is read-only). For more information about the immutability of strings, see the Immutability and the StringBuilder class section. " +
                "The maximum size of a String object in memory is 2-GB, or about 1 billion characters.";
            Console.WriteLine(text);
            DeleteCharsFromString(ref text, 'a', 'b');
            Console.WriteLine(text);
            text = "I don't know whether to delete this or rewrite it";
            CountAllCharsStat(text);
        }
    }
}
