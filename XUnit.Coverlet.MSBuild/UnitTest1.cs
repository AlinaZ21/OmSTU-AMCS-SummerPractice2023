using Xunit;
using System;
using SquareEquationLib;

namespace UnitTest1;

public class UnitTest1
{
    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(double.PositiveInfinity, 1, 1)]
    [InlineData(1, double.PositiveInfinity, 1)]
    [InlineData(1, 1, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 1, 1)]
    [InlineData(1, double.NegativeInfinity, 1)]
    [InlineData(1, 1, double.NegativeInfinity)]
    [InlineData(double.NaN, 1, 1)]
    [InlineData(1, double.NaN, 1)]
    [InlineData(1, 1, double.NaN)]
    public void TestException(double a, double b, double c)
    {
        var argExc = new ArgumentException();
        try
        {
            var roots = SquareEquation.Solve(a, b, c);
        }
        catch (Exception exc)
        {
            Assert.Equal(exc.GetType(), argExc.GetType());
        }
    }

    [Theory]
    [InlineData(1, 2, 1)]
    [InlineData(4, 8, 4)]
    public void TestOneRoot(double a, double b, double c)
    {
        double[] roots = SquareEquation.Solve(a, b, c);

        bool rightSolution = true;
        double eps = 1e-9;

        foreach (double i in roots)
        {
            if (Math.Abs(a * Math.Pow(i, 2) + b * i + c) > eps)
            {
                rightSolution = false;
            }
        }
        Assert.True(rightSolution);
    }

    [Theory]
    [InlineData(1, 72, 1)]
    [InlineData(4, 88, 4)]
    public void TestTwoRoots(double a, double b, double c)
    {
        double[] roots = SquareEquation.Solve(a, b, c);
        bool rightSolution = true;
        double eps = 1e-9;
        foreach (double i in roots)
        {
            if (Math.Abs(a * Math.Pow(i, 2) + b * i + c) > eps)
            {
                rightSolution = false;
            }
        }
        Assert.True(rightSolution);

    }

    [Theory]
    [InlineData(10000, 1, 1)]
    [InlineData(1, 1, 24)]
    public void TestNoRoots(double a, double b, double c)
    {
        double[] roots = SquareEquation.Solve(a, b, c);
        Assert.Empty(roots);
    }
}