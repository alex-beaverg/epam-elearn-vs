using System;

// Basic of .NET Framework and C#

namespace SystemToSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enter begining conditions from console
            Console.WriteLine("Введите любое целое число в десятичной системе счисления:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите основание новой системы счисления (от 2 до 20):");
            int index = int.Parse(Console.ReadLine());

            // Write to console first condition
            Console.WriteLine("\r");
            Console.WriteLine(number + " - в десятичной системе счисления");

            // Solution
            const String chars = "0123456789ABCDEFGHIJ";
            int len = (int)Math.Log(number, index) + 1;
            var digits = new char[len];
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                number = Math.DivRem(number, index, out int rem);
                digits[i] = chars[rem];
            }            
            
            // Write to console result
            Console.WriteLine(new String(digits) + " - в системе счисления с основанием " + index);
        }
    }
}
