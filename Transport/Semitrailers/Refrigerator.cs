using System;
using Goods;

namespace Transport.Semitrailers
{
    public class Refrigerator:Semitrailer
    {
        public Refrigerator()
        {
            MaxLoadWeight = 1350;
            CurrentLoadWeight = 200;
            Cargo = null;
        }
    }
}