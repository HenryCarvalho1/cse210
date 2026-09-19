using System;
using System.Collections.Generic;

// I created a library of scriptures, every time the program starts, it picks one scripture completely at random for the user to memorize.

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("Proverbs", 3, 5, 6);
        Scripture scrip1 = new Scripture(ref1, "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths");

        Reference ref2 = new Reference("John", 3, 16);
        Scripture scrip2 = new Scripture(ref2, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");

        Reference ref3 = new Reference("Philippians", 4, 13);
        Scripture scrip3 = new Scripture(ref3, "I can do all things through Christ which strengtheneth me");

        List<Scripture> scriptureLibrary = new List<Scripture> { scrip1, scrip2, scrip3 };

        Random random = new Random();
        int randomIndex = random.Next(0, scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[randomIndex];

        do
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish.");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "quit")
            {
                break;
            }

            if (currentScripture.IsCompletelyHidden())
            {
                break; 
            }

            currentScripture.HideRandomWords(3);

        } while (true);

        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\nGreat job! The scripture memorization is complete. Goodbye!");
    }
}
