using System;

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
            if (Semitrailer is null)
                Semitrailer = trailer;
            else throw new Exception("Truck already has trailer.");
            UpdateComsuption();
        }
        public void RemoveTrailer(Semitrailer trailer)
        {
            Semitrailer = null;
        }
        public void UpdateComsuption()
        {
            if (Semitrailer is not null)
                Consumption = Semitrailer.CurrentLoadWeight * ConsumptionIndex;
            else Consumption = ConsumptionIndex * 1000;
        }
    }
}