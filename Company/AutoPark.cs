using System;
using System.Collections.Generic;
using Transport;
using Transport.Semitrailers;

namespace Company
{
    public class AutoPark
    {
        public List<Semitrailer> Semitrailers = new List<Semitrailer>();
        public List<Truck> Trucks = new List<Truck>();

        public AutoPark()
        {
            Semitrailers.Add(new Refrigerator());
            Semitrailers.Add(new Tank());
            Semitrailers.Add(new Tent());
        }
    }
}