namespace spacebattle;
public class SpaceShip
{
    public static double[] Movement(bool canMove, bool knownSpeed,
    bool knownPosition, double[] speed, double[] position)
    {
        if (!canMove || !knownSpeed || !knownPosition)
        {
            throw new Exception();
        }
        double[] result = { position[0] + speed[0], position[1] + speed[1] };
        return result;
    }
    public static double Rotation(bool canRotation, bool knownCorner,
    bool knownAngularSpeen, double corner, double angularSpeed)
    {
        if (!canRotation || !knownCorner || !knownAngularSpeen)
        {
            throw new Exception();
        }
        double result = corner + angularSpeed;
        return result;
    }
    public static double Fuel(double fuel, double consumption)
    {
        if (fuel - consumption < 0)
        {
            throw new Exception();
        }
        double result = fuel - consumption;
        return result;
    }
}
