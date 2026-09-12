using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNumber = int.Parse(Console.ReadLine());
        
        List<int> numbers = new List<int>();

            while (userNumber != 0)
            {
            numbers.Add(userNumber);
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            userNumber = int.Parse(Console.ReadLine());
            }
        int sum = numbers.Sum();
        int max = numbers.Max();
        double ave = numbers.Average();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {ave}");
        Console.WriteLine($"The largest number is: {max}");
    }
}