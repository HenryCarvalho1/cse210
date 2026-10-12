using System;
using System.Diagnostics;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return GetLength() * _speed / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}