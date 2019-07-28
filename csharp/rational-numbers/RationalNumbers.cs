using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    public RationalNumber(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    private int _numerator;
    private int _denominator;

    public RationalNumber Add(RationalNumber r)
    {
        return this + r;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber x;
        x._numerator = r1._numerator * r2._denominator + r1._denominator * r2._numerator;
        x._denominator = r1._denominator * r2._denominator;
        return x.Reduce();
    }

    public RationalNumber Sub(RationalNumber r)
    {
        return this - r;
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber x;
        x._numerator = r1._numerator * r2._denominator - r1._denominator * r2._numerator;
        x._denominator = r1._denominator * r2._denominator;
        return x.Reduce();
    }

    public RationalNumber Mul(RationalNumber r)
    {
        return this * r;
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber x;
        x._numerator = r1._numerator * r2._numerator;
        x._denominator = r1._denominator * r2._denominator;
        return x.Reduce();
    }

    public RationalNumber Div(RationalNumber r)
    {
        return this / r;
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber x;
        x._numerator = r1._numerator * r2._denominator;
        x._denominator = r1._denominator * r2._numerator;
        return x.Reduce();
    }

    public RationalNumber Abs()
    {
        if (_numerator < 0) _numerator = Math.Abs(_numerator);
        if (_denominator < 0) _denominator = Math.Abs(_denominator);
        return this.Reduce();
    }

    public RationalNumber Reduce()
    {
        if (_numerator == 0)
        {
            _denominator = 1;
            return this;
        }

        if (_numerator < 0 && _denominator < 0)
        {
            _numerator = Math.Abs(_numerator);
            _denominator = Math.Abs(_denominator);
        }

        List<int> listOne = Factors(Convert.ToInt32(Math.Abs(_numerator)));
        List<int> listTwo = Factors(Convert.ToInt32(Math.Abs(_denominator)));

        int GCD = listOne.Intersect(listTwo).Max();

        _numerator = _numerator / GCD;
        _denominator = _denominator / GCD;

        return this;
    }

    public RationalNumber Exprational(int power)
    {
        if (_numerator == 0) return Reduce();
        if (_numerator == 1 && _denominator == 1) return this;

        RationalNumber x;
        x._numerator = Convert.ToInt16(Math.Pow(Convert.ToDouble(_numerator), Convert.ToDouble(power)));
        x._denominator = Convert.ToInt16(Math.Pow(Convert.ToDouble(_denominator), Convert.ToDouble(power)));
                       
        return x.Reduce();
    }

    public double Expreal(int baseNumber)
    {
        return NthRoot(Math.Pow(Convert.ToDouble(baseNumber), _numerator), _denominator);
    }

    public static List<int> Factors(int number)
    {
        int i = 2;
        List<int> theFactors = new List<int> { 1, number };

        while (i <= number / 2)
        {
            if (number % i == 0) theFactors.Add(i);
            i++;
        }
        return theFactors;
    }

    static double NthRoot(double A, int N)
    {
        return Math.Pow(A, 1.0 / N);
    }
}
