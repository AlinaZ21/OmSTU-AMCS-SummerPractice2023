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
}
