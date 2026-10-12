using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public int GetLength()
    {
        return _length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public string GetSummary()
    {
    return $"{GetDate().ToString("dd MMM yyyy")} {this.GetType().Name} ({GetLength()} min) - Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
}