using SpaceShip;

class poolWork
{
    public static void Main()
    {
        Pool<Space_ship> pool = new Pool<Space_ship>(50);
        using (PoolGuard<Space_ship> poolGuard = new PoolGuard<Space_ship>(pool))
        {
            Space_ship ship = poolGuard.Get_Object();
            Console.WriteLine($"{ship.hp}");
            Console.WriteLine($"{ship.speed}");
        }
    }
}