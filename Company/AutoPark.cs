using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Goods;
using Goods.Goods;
using Transport;
using Transport.Semitrailers;
using Transport.Trucks;

namespace Company
{
    [Serializable]
    public class AutoPark
    {
        public  List<Semitrailer> Semitrailers;
        public  List<Truck> Trucks;

        public AutoPark()
        {
            Semitrailers = new List<Semitrailer>();
            Trucks = new List<Truck>();
            for (var i = 0; i < 2; i++)
            {
                Semitrailers.Add(new Tank());
                Semitrailers.Add(new Tent());
            }
            Trucks.Add(new Man());
            Trucks.Add(new Mercedes());
            Trucks.Add(new Renault());
            Trucks.Add(new Volvo());
            Trucks[1].AddTrailer(Semitrailers[0]);
            Semitrailers[0].LoadTrailer(300, new Fuel());
        }

        public  List<Truck> GetTrucks()
        {
            return Trucks;
        }
        public  List<Semitrailer> GetTrailers()
        {
            return Semitrailers;
        }

        public  List<T> GetTrailerByType<T>()
            where T : Semitrailer
        {
            var trailersByType = new List<T>();
            foreach(var semitrailer in Semitrailers)
                if(semitrailer is T trailer)
                    trailersByType.Add(trailer);
            return trailersByType;
        }

        public  List<T> GetTrailerByPattern<T>(int maxLoadWeight) 
            where T : Semitrailer
        {
            var trailersByPattern = GetTrailerByType<T>();
            return trailersByPattern.FindAll(x => x.MaxLoadWeight == maxLoadWeight);
        }

        public  List<Truck> GetCombinedTrucks<T>()
        {
            var combinedTrucks = new List<Truck>();
            foreach(var truck in Trucks)
                if (truck.Semitrailer is not null && truck.Semitrailer.Cargo is T)
                    combinedTrucks.Add(truck);
            return combinedTrucks;  
        }
        public List<Truck> GetFreeCombinedTrucks<T>()
        {
            var freeCombinedTrucks = new List<Truck>();
            foreach(var truck in Trucks)
                if (truck.Semitrailer is not null && truck.Semitrailer.MaxLoadWeight - truck.Semitrailer.CurrentLoadWeight > 0)
                    freeCombinedTrucks.Add(truck);
            return freeCombinedTrucks;  
        }
        public  List<Truck> GetFullFreeCombinedTrucks<T>()
        {
            var fullFreeCombinedTrucks = new List<Truck>();
            foreach(var truck in Trucks)
                if (truck.Semitrailer is not null && truck.Semitrailer.Cargo is null)
                    fullFreeCombinedTrucks.Add(truck);
            return fullFreeCombinedTrucks;
        }
    }
}