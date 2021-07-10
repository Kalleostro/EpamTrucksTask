using System;
using Goods;

namespace Transport
{
    public abstract class Semitrailer
    {
        public int MaxLoadWeight;
        public int CurrentLoadWeight;
        public Cargo Cargo = null;

        public virtual void LoadTrailer(int weight, Cargo goods)
        {
            if (MaxLoadWeight >= CurrentLoadWeight + weight && Cargo is null)
            {
                Cargo = goods;
                CurrentLoadWeight += weight;
            }
            else if (MaxLoadWeight >= CurrentLoadWeight + weight && Cargo.Equals(goods))
            {
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