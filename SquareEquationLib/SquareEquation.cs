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
        if (Math.Abs(b) > eps)
        {
            b = b / a;
            c /= a;
            double D = Math.Pow(b, 2) - 4 * c;
            if (D <= -eps)
            {
                roots = new double[0];
                return roots;
            }
            else if (Math.Abs(D) < eps)
            {
                roots = new double[1] { -b / 2 };
                return roots;
            }
            else
            {
                x1 = -(b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                x2 = c / x1;
                roots = new double[2] { x1, x2 };
                return roots;
            }
        }
        else if (c <= eps)
        {
            x1 = Math.Pow(Math.Abs(c), 0.5);
            x2 = -Math.Pow(Math.Abs(c), 0.5);
            roots = new double[2] { x1, x2 };
            return roots;
        }
        else
        {
            roots = new double[0];
            return roots;
        }
    }
}