using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    
    {
    string playAgain = "yes";
    do
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int attempts = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            attempts += 1;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    Console.Write($"You took {attempts} guesses. ");
    
    Console.Write("Do you want to play again? ");
    playAgain = Console.ReadLine();
    } while (playAgain == "yes");
}
    } 