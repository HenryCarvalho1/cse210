 using System;
public class Fraction
{   
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int topNumber)
    {
        _top = topNumber;
        _bottom = 1;
    }
    public Fraction(int topNumber, int bottomNumber)
    {
        _top = topNumber;
        _bottom = bottomNumber;
    }

    public int GetTopNumber()
    {
        return _top;
    }
    public void SetTopNumber(int topNumber)
    {
        _top = topNumber;
    }

    public int GetBottomNumber()
    {
        return _bottom;
    }
    public void SetBottomNumber(int bottomNumber)
    {
        _bottom = bottomNumber;
    }

    public string GetFractionString()
    {
       return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return(double) _top / _bottom;
    }
}