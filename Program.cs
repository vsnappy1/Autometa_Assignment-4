using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToCS_Assignment_4
{
    /*OBJECTIVE:
     A program to generate the strings of a given length, defined of a given Alphabet(two Elements only)*/
    class Program
    {
        public static string[] ElementsOfAlphabet(string str, string[] array)   //For seprating elements of alphabet by ','
        {
            array = str.Split(',');
            return array;
        }
        public static int NumberOfElementsIn(string str)                        //This counts the number of elements in Alphabet
        {
            int i, count = 1;
            for (i = 0; i < str.Length; i++)
                if (str[i] == ',')
                    count++;
            return count;
        }
        public static int Power(int Base,int Exponent)                          //This function returns powered value of a base number/ power function
        {
            int result=1;
            for(int i = 0; i < Exponent; i++)
            {
                result = result * Base;
            }
            return result;
        }
        public static void PrintString(string[] array, int Length,string str)   //This prints the Combination of strings
        {
            string leter = " ";                         //Here str is a Binary Counter which gets the binary word of required length...
                                                            //e.g if length is 4 and count is 2, it will have 0011
            for(int j = 0; j < Length; j++)             //This loop makes required string combination out of binary word
            {
                if (str[j] == '0')                      //If first Character of string is 0, than leter contains first element of Alphabet
                    leter =array[0];
                else
                    leter = array[1];                   //Else it will contain the second element of Alphabet
                Console.Write(leter);                   //This prints leter by leter the whole word
            }
            Console.WriteLine();                        //This brings the courser to next line
        }

        static void Main(string[] args)
        {
            int Length;
            Console.Write("Enter Valid Alphabet = { ");
            string Alphabet = Console.ReadLine();               //Input Alphabet
            Console.Write("Enter Length of String = ");
            string Len = Console.ReadLine();                    //Input of string
            if (Len == "A")                                    
                Length = 4;
            else
                Length = int.Parse(Len);                        //If input is not A then string is converted into its equivalent integer
            
            int size = NumberOfElementsIn(Alphabet);            //This gets the number of elements in Alphabet
            string[] array = new string[size];                  //array of required size is initialized
            array = ElementsOfAlphabet(Alphabet, array);        //Now array conatains elements of Alphabet
            
            int Number_Of_Strings = Power(size, Length);        //Number of strings to be made by program 
            string BinaryCount;                                 //BinaryCount is a Binary counter of given length

            if(Len=="A")
                Console.WriteLine(" ^");
            for (int i = 0; i < Power(size,Length); i++)        //This loop completes the BinaryCount... 
            {                                                       //(e.g if length is 4, for 2 it is 11 but we need 0011
                BinaryCount = Convert.ToString(i,2);            //This converts the integer into base 2/Binary
                if (BinaryCount.Length < Length)
                {
                    for (int j = BinaryCount.Length; j < Length; j++)   //This add the remaining 0s at the begining of BinaryCount
                        BinaryCount = "0" + BinaryCount;
                }
                PrintString(array, Length, BinaryCount);        //This prints the string one by one
            }
            if (Len == "A")                                     //This prints the dots to show that there are infinity more combnations
                for(int i=0;i<5;i++)
                    Console.WriteLine("  .  ");
            if(Length==0)                                       //This prints Null Symbol if length is zero
                Console.WriteLine("^");
            Console.ReadKey();
        }
    }
}
