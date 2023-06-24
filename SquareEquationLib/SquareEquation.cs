namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
        if (Math.Abs(a) < eps) throw new System.ArgumentException();
        if (double.IsNaN(a) || double.IsInfinity(a) ||
            double.IsNaN(b) || double.IsInfinity(b) ||
            double.IsNaN(c) || double.IsInfinity(c))
        {
            throw new System.ArgumentException();
        }
        double[] roots;
        double x1, x2;
        b /= a;
        c /= a;
        double D = Math.Pow(b,2) - 4 * c;
        if (D <= -eps)
        {
            roots = new double [0];
            return roots;
        }
        else if (Math.Abs(D)<eps)
        {
            roots = new double [1] { -b / 2 };
            return roots;
        }
        else
        {
            x1 = -(b + Math.Sign(b) * Math.Sqrt(D)) / 2;
            x2 = c / x1;
            roots = new double [2] { x1, x2 };
            return roots;
        }
    }
}