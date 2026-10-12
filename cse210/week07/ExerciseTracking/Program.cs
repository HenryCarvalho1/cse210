using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running act1 = new Running(new DateTime(2026, 9, 10), 30, 5.0);
        activities.Add(act1);

        Cycling act2 = new Cycling(new DateTime(2026, 9, 10), 60, 10);
        activities.Add(act2);

        Swimming act3 = new Swimming(new DateTime(2025, 12, 15), 20, 5);
        activities.Add(act3);

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}