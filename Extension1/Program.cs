using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userSentance = string.Empty;
            int totalWords = 0;
            int totalCharWithoutSpace = 0;
            Console.WriteLine("Enter the your sentance");
            userSentance = Console.ReadLine();
            //calling Extension Method WordCount  
            totalWords = userSentance.WordCount();
            Console.WriteLine("Total number of words is :" + totalWords);
            //calling Extension Method to count character  
            totalCharWithoutSpace = userSentance.TotalCharWithoutSpace();
            Console.WriteLine("Total number of character is :" + totalCharWithoutSpace);
            Console.ReadKey();
        }
    }

    public static class Extension
    {
        public static int WordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' },
                                        StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;
            return wordCount;
        }
        public static int TotalCharWithoutSpace(this string str)
        {
            int totalCharWithoutSpace = 0;
            string[] userString = str.Split(' ');
            foreach (string stringValue in userString)
            {
                totalCharWithoutSpace += stringValue.Length;
            }
            return totalCharWithoutSpace;
        }
    }
}
