namespace SpaceShip;

public class Space_Ship
{
    public int hp = 1000;
    public int speed = 300;
}


public class Pool<spacepool> where spacepool : new()
{
    Queue<spacepool> SpaceShips = new Queue<spacepool>();
    int count;

    public Pool(int count)
    {
        this.count = count;

        for (int i = 0; i < count; i++)
        {
            SpaceShips.Enqueue(new spacepool());
        }
    }

    public spacepool Get_Object()
    {
        return SpaceShips.Dequeue();
    }

    public void Release_Object(spacepool ship)
    {
        SpaceShips.Enqueue(ship);
    }
}



public class PoolGuard<spacepool> : IDisposable where spacepool : new()
{
    Pool<spacepool> pool;
    spacepool ship;
    public PoolGuard(Pool<spacepool> pool)
    {
        ship = pool.Get_Object();
        this.pool = pool;
    }

    public void Dispose()
    {
        pool.Release_Object(ship);
    }

    public spacepool Get_Object()
    {
        return ship;
    }
}