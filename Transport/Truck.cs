using System;
using System.Xml.Serialization;
using Transport.Semitrailers;
using Transport.Trucks;

namespace Transport
{
    [XmlInclude(typeof(Man))]
    [XmlInclude(typeof(Mercedes))]
    [XmlInclude(typeof(Renault))]
    [XmlInclude(typeof(Volvo))]
    [Serializable]
    public abstract class Truck
    {
        public float Consumption;
        public static int MaxLoadWeight { get; set; }
        public Semitrailer Semitrailer;
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
            {
                Consumption = Semitrailer.CurrentLoadWeight * ConsumptionIndex + ConsumptionIndex * 1000;
            }
            else Consumption = ConsumptionIndex * 1000;
        }
        
    }
}