using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void Start()
    {
        string menuChoice = "";

        do
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                CreateGoal();
            }
            else if (menuChoice == "2")
            {
                ListGoalDetails();
            }
            else if (menuChoice == "3")
            {
                SaveGoals();
            }
            else if (menuChoice == "4")
            {
                LoadGoals();
            }
            else if (menuChoice == "5")
            {
                RecordEvent();
            }
            else if (menuChoice == "6")
            {
                Console.WriteLine("\nThank you for playing Eternal Quest! Goodbye.");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select a number from 1 to 6.");
            }

        } while (menuChoice != "6");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals created yet. Choose option 1 to start!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal currentGoal = _goals[i];

            Console.WriteLine($"  {i + 1}. {currentGoal.GetDetailsString()}");
        }
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            SimpleGoal newSimple = new SimpleGoal(name, description, points);
            _goals.Add(newSimple);
            Console.WriteLine("\nSimple Goal created successfully!");
        }
        else if (typeChoice == "2")
        {
            EternalGoal newEternal = new EternalGoal(name, description, points);
            _goals.Add(newEternal);
            Console.WriteLine("\nEternal Goal created successfully!");
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal newChecklist = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(newChecklist);
            Console.WriteLine("\nChecklist Goal created successfully!");
        }
        else
        {
            Console.WriteLine("\nInvalid goal type. Returning to main menu.");
        }

    }
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou don't have any goals to record. Create one first!");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choiceIndex = int.Parse(Console.ReadLine());

        int actualIndex = choiceIndex - 1;

        if (actualIndex >= 0 && actualIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[actualIndex];

            int pointsEarned = selectedGoal.RecordEvent();

            _score += pointsEarned;

            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"New Total Score: {_score}");
        }
        else
        {
            Console.WriteLine("\nInvalid selection. Returning to main menu.");
        }
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        using (StreamWriter outputFile = new StreamWriter(fullPath))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"\nGoals and score saved successfully to '{filename}'!");
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("\nError: File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fullPath);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(':');
            
            string goalType = parts[0];
            string goalData = parts[1];

            string[] dataFields = goalData.Split(',');

            if (goalType == "SimpleGoal")
            {
                string name = dataFields[0];
                string description = dataFields[1];
                int points = int.Parse(dataFields[2]);
                bool isComplete = bool.Parse(dataFields[3]);

                SimpleGoal loadedSimple = new SimpleGoal(name, description, points);
                
                if (isComplete)
                {
                    loadedSimple.RecordEvent();
                }

                _goals.Add(loadedSimple);
            }
            else if (goalType == "EternalGoal")
            {
                string name = dataFields[0];
                string description = dataFields[1];
                int points = int.Parse(dataFields[2]);

                EternalGoal loadedEternal = new EternalGoal(name, description, points);
                _goals.Add(loadedEternal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = dataFields[0];
                string description = dataFields[1];
                int points = int.Parse(dataFields[2]);
                int bonus = int.Parse(dataFields[3]);
                int amountCompleted = int.Parse(dataFields[4]);
                int target = int.Parse(dataFields[5]);

                ChecklistGoal loadedChecklist = new ChecklistGoal(name, description, points, target, bonus);

                for (int j = 0; j < amountCompleted; j++)
                {
                    loadedChecklist.RecordEvent();
                }

                _goals.Add(loadedChecklist);
            }
        }

        Console.WriteLine($"\nProgress loaded successfully from '{filename}'!");
    }
}
