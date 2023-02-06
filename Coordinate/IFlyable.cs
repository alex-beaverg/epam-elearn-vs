namespace Coordinate
{
    // Interface with 2 methods
    internal interface IFlyable
    {
        // Methods
        int[] flyTo(int[] point);
        double getFlyTime(int[] point);
    }
}
