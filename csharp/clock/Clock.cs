using System;

public class Clock : IEquatable<Clock>
{
    // Immutable Clock
    private readonly int _minutes;
    private readonly int _hours;

    public Clock(int hours, int minutes)
    {
        _hours = hours;
        _minutes = minutes;
    }

    public int Hours
    {
        get
        {
            // Return all hours derived from number of minutes
            int hoursRet = _minutes / 60;

            // Total is hours derived from minutes plus hours already on the clock
            hoursRet += _hours;

            // Negative minutes remaining means we must roll back one more hour
            if (_minutes % 60 < 0) hoursRet--;

            // Display value for hours is somehwere between 0 and 23
            if (hoursRet < 0) return 23 - (Math.Abs(hoursRet + 1) % 24);
            else if (hoursRet > 0) return hoursRet % 24;
            else return 0; // edge case, would be 22 otherwise
        }
    }

    public int Minutes

    {
        get
        {
            // Display value for minutes is somewhere between 0 and 60
            int minutesRemaining = _minutes % 60;
            return minutesRemaining >= 0 ? minutesRemaining : 60 + minutesRemaining;
        }
    }
    

    public Clock Add(int minutesToAdd)
    {
        return new Clock(_hours, _minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_hours, _minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{Hours.ToString("00")}:{Minutes.ToString("00")}";
    }

    public bool Equals(Clock obj)
    {
        return (Minutes == obj.Minutes && Hours == obj.Hours);
    }
}