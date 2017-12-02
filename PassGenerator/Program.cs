using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGenerator
{
    class Program
    {
        static string numArr = "0123456789";
        static int atLeastNums = 2;

        static string letterArr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static int atLeastLetters = 2;

        static string symbolArr = "!$%()*+,-:;=?";
        static  int atLeastSymbols = 1;

        static int passLength = 30;
       
        static void Main(string[] args)
        {
            Password pw = new Password(numArr, atLeastNums, letterArr, atLeastLetters, symbolArr, atLeastSymbols);
            string password = pw.GetPassword(passLength);

            Console.WriteLine("Password = " + password);

            Console.ReadKey();
        }
    }

    public class Password
    {     
        string numArr = null;
        string letterArr = null;
        string symbolArr = null;
        string mixArr = null;

        int atLeastNums = 0;
        int atLeastLetters = 0;
        int atLeastSymbols = 0;

        StringBuilder pass = null;

         Random rd = new Random();       
                
        public Password(string numArr, int atLeastNums, string letterArr, int atLeastLetters, string symbolArr, int atLeastSymbols)
        {
            this.numArr = numArr;
            this.letterArr = letterArr;
            this.symbolArr = symbolArr;

            this.atLeastNums = atLeastNums;
            this.atLeastLetters = atLeastLetters;
            this.atLeastSymbols = atLeastSymbols;
           
            mixArr = numArr + letterArr + symbolArr;  //по идее для криптоустойчивости здесь хорошо бы было еще перетасовать символы в mixArr
        }
       
        public string GetPassword(int passLength)
        {
            pass = new StringBuilder(passLength);

            char c = letterArr[rd.Next(letterArr.Length)];

            pass.Append(letterArr[rd.Next(letterArr.Length)]);

            for (int i = 0; i < passLength; i++ )
            {
                char ch = mixArr[rd.Next(mixArr.Length)];
                pass.Append(ch);
            }

            AddAtLeastChar(atLeastNums, numArr);
            AddAtLeastChar(atLeastLetters, letterArr);
            AddAtLeastChar(atLeastSymbols, symbolArr);

            return pass.ToString();
        }

        void AddAtLeastChar(int atLeastAmount, string sourceArr)
        {
            for (int i = 0; i < atLeastAmount; i++ )
            {
                char ch = sourceArr[rd.Next(sourceArr.Length)];
                pass.Insert(rd.Next(1, pass.Length), ch);
            }
        }        
    }
}
