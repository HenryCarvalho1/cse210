// Made a list of scriptures instead of just one scripture
using System;

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
    }
}