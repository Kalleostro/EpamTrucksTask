namespace Transport
{
    public abstract class Truck
    {
        public float Consumption;
        public static int MaxLoadWeight;
        public Semitrailer Semitrailer;
        public abstract void AddTrailer(Semitrailer trailer);
        public abstract void RemoveTrailer(Semitrailer trailer);
    }
}