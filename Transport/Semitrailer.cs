using System;
using System.Xml.Serialization;
using Goods;
using Transport.Semitrailers;

namespace Transport
{
    [XmlInclude(typeof(Tank))]
    [XmlInclude(typeof(Tent))]
    [XmlInclude(typeof(Refrigerator))]
    [Serializable]
    public abstract class Semitrailer
    {
        public int MaxLoadWeight;
        public int CurrentLoadWeight;
        public Cargo Cargo;

        public virtual void LoadTrailer(int weight, Cargo goods)
        {
            if (MaxLoadWeight >= CurrentLoadWeight + weight && Cargo is null)
            {
                Cargo = goods;
                Cargo.Weight += weight;
                CurrentLoadWeight += weight;
            }
            else if (MaxLoadWeight >= CurrentLoadWeight + weight && Cargo.Equals(goods))
            {
                Cargo.Weight += weight;
                CurrentLoadWeight += weight;
            }
            else throw new Exception("Not enough space in the trailer or wrong cargo type!");
        }
        
        public void UnloadTrailer(int weight, Cargo goods) =>
            CurrentLoadWeight -= CurrentLoadWeight >= weight
                ? weight
                : throw new Exception("Unload weight is bigger than current!");
    }
}