namespace Transport
{
    public abstract class Truck
    {
        public float Consumption;
        public static int MaxLoadWeight { get; set; }
        public Semitrailer Semitrailer = null;
        protected float ConsumptionIndex;

        public void AddTrailer(Semitrailer trailer)
        {
            Semitrailer = trailer;
            Consumption = Semitrailer.CurrentLoadWeight * ConsumptionIndex;
        }
        public void RemoveTrailer(Semitrailer trailer)
        {
            Semitrailer = null;
        }
    }
}