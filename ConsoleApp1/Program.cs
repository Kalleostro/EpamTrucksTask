using System;
using Company;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoPark park = null;
            //park.GetCombinedTrucks<Fuel>();
            //Serializer.WriteXml(park);

            park = XmlReaderSerializer.ReadXml();
            Console.Write(park.Trucks.Count);
            
            // foreach (var truck in park.Trucks)
            // {
            //     Console.WriteLine(truck.Consumption.ToString());
            // }
        }
    }
}