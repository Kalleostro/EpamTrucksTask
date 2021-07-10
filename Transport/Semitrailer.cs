using System;
using Goods;

namespace Transport
{
    public abstract class Semitrailer
    {
        public static int MaxLoadWeight;
        public int CurrentLoadWeight;
        public Cargo Cargo;

        public void LoadTrailer(int weight, Cargo goods)
        {
            if (MaxLoadWeight >= CurrentLoadWeight + weight)
            {
                Cargo = goods;
                CurrentLoadWeight += weight;
            }
            else throw new Exception("Not enough space in the trailer!");
        }

        public void UnloadTrailer(int weight, Cargo goods) =>
            CurrentLoadWeight -= CurrentLoadWeight >= weight
                ? weight
                : throw new Exception("Unload weight is bigger than current!");
    }
}