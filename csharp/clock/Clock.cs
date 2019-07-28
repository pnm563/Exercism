using System;

public class Clock : IEquatable<Clock>
{
    private int _minutes;

    private int _hours;

    public Clock(int hours, int minutes)
    {
        // We can only add or subtract minutes, so convert hours and make a total
        int totalMinutes = minutes + (hours * 60);

        // This also takes care of -ve or +ve values passed in, end result will either be an Add or Subtract
        if (totalMinutes > 0) Add(totalMinutes);
        if (totalMinutes < 0) Subtract(Math.Abs(totalMinutes));

    }

    public int Hours
    {
        // Uses MOD 24 to find the hour of the day for any given number of hours
        get
        {
            // Take care of edge case, would otherwise give 22
            if (_hours == 0)
                return 0;
            // The _hours + 1 offsets the mod correctly when going backwards
            else if (_hours < 0)
                return (23 - (Math.Abs(_hours + 1) % 24));
            // Easier when going forwards
            else
                return (_hours % 24);
        }
    }

    public int Minutes => _minutes;

    public Clock Add(int minutesToAdd)
    {
        if (minutesToAdd > 0)
        {
            // Add an hour for every 60 minutes
            _hours += minutesToAdd / 60;

            // The leftover minutes
            int minutesRemaining = minutesToAdd % 60;

            // This block handles remaining minutes causing the hour to rollover
            if (_minutes + minutesRemaining >= 60)
            {
                _hours++;
                _minutes += minutesRemaining - 60;
            }
            // Otherwise we can just add the minutes
            else
            {
                _minutes += minutesRemaining;
            }
        }
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        if (minutesToSubtract > 0)
        {
            // Subtract an hour for every 60 minutes
            _hours -= minutesToSubtract / 60;

            // The leftover minutes
            int minutesRemaining = minutesToSubtract % 60;

            // This block handles remaining minutes causing the hour to rollback
            if (_minutes - minutesRemaining < 0)
            {
                _hours--;
                _minutes =  60 - (minutesRemaining - _minutes);
            }
            // Otherwise just subtract the minutes
            else
            {
                _minutes -= minutesRemaining;
            }
        }
        return this;
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