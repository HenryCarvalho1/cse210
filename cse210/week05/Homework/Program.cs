using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Henry", "Writing");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Gabriel", "Fractions", "Section 6.7", "Problems 8-10");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Ana", "Brazilian History", "Who Discovered Brazil?");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInfo());
    }
}