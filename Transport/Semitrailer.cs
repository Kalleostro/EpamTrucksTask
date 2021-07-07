using System;

namespace Transport
{
    public abstract class Semitrailer
    {
        public static int MaxLoadWeight;
        public int CurrentLoadWeight;
        public Cargo.Cargo Type;

        public abstract void LoadTrailer(int weight);
        public abstract void UnloadTrailer(int weight, Enum type);
    }
}