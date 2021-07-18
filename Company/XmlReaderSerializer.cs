using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Xml;
using Goods;
using Goods.Goods;
using Transport;
using Transport.Semitrailers;
using Transport.Trucks;

namespace Company
{
    public static class XmlReaderSerializer
    {
        public static void WriteXml(AutoPark park)
        {
            var writer = XmlWriter.Create("park.xml");
            writer.WriteStartElement("AutoPark");
            
            writer.WriteStartElement("Trucks");
            foreach (var truck in (park.Trucks))
            {
                SerializeTruck(truck, writer);
            }
            writer.WriteEndElement();
            
            writer.WriteStartElement("Trailers");
            foreach (var trailer in (park.Semitrailers))
            {
                SerializeTrailer(trailer, writer);
            }
            writer.WriteEndElement();
            
            writer.WriteEndElement();
            writer.Flush();
        }

        private static void SerializeCargo(Cargo cargo, XmlWriter writer)
        {
            writer.WriteStartElement("Cargo");
            writer.WriteStartElement("CargoType");
            writer.WriteValue(cargo.GetType().ToString());
            writer.WriteEndElement();
            
            writer.WriteStartElement("Weight");
            writer.WriteValue(cargo.Weight);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
        
        private static void SerializeTrailer(Semitrailer trailer, XmlWriter writer)
        {
            writer.WriteStartElement("Trailer");
            writer.WriteStartElement("TrailerType");
            writer.WriteValue(trailer.GetType().ToString());
            writer.WriteEndElement();
            
            writer.WriteStartElement("MaxLoadWeight");
            writer.WriteValue(trailer.MaxLoadWeight);
            writer.WriteEndElement();
            
            writer.WriteStartElement("CurrentLoadWeight");
            writer.WriteValue(trailer.CurrentLoadWeight);
            writer.WriteEndElement();
            
            if (trailer.Cargo is null)
            {
                writer.WriteStartElement("Cargo");
                writer.WriteValue("null");
                writer.WriteEndElement();
            }
            else
                SerializeCargo(trailer.Cargo, writer);

            writer.WriteEndElement();
        }
        
        private static void SerializeTruck(Truck truck, XmlWriter writer)
        {
            writer.WriteStartElement("Truck");
            writer.WriteStartElement("Type");
            writer.WriteValue(truck.GetType().ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Consumption");
            writer.WriteValue(truck.Consumption);
            writer.WriteEndElement();
            
            if (truck.Semitrailer is null)
            {
                writer.WriteStartElement("Trailer");
                writer.WriteValue("null");
                writer.WriteEndElement();
            }
            else
                SerializeTrailer(truck.Semitrailer, writer);
            
            writer.WriteEndElement();
        }
        public static AutoPark ReadXml()
        {
            var result = new AutoPark();
            
            var reader = XmlReader.Create("/Users/kalleostro/Desktop/Учёба/EpamTask2Shemetkov/EpamTrucksTask/CompanyTests/bin/Debug/net5.0/park.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Trucks")
                           result.Trucks = ReadTrucks(reader);
                        if (reader.Name == "Trailers")
                            result.Semitrailers = ReadTrailers(reader);
                        break;
                }
            }
            return result;
        }

        private static Cargo ReadCargo(XmlReader reader)
        {
            Cargo result = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                    if (reader.Name == "Cargo")
                        break;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "CargoType")
                        {
                            result = InitializeCargo(reader.ReadString());
                        }

                        if (reader.Name == "Weight" && result is not null)
                            result.Weight = int.Parse(reader.ReadString());
                        break;
                }
            }
            return result;
        }



        private static List<Semitrailer> ReadTrailers(XmlReader reader)
        {
            var result = new List<Semitrailer>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                    if (reader.Name == "Trailers")
                        break;
                if (reader.Name == "Trailer")
                    result.Add(ReadTrailer(reader));
            }
            return result;
        }

        private static Semitrailer ReadTrailer(XmlReader reader)
        {
            Semitrailer resultTrailer = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                    if (reader.Name == "Trailer")
                        break;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "TrailerType")
                        {
                            resultTrailer = InitializeTrailer(reader.ReadString());
                        }

                        if (reader.Name == "MaxLoadWeight" && resultTrailer is not null)
                            resultTrailer.MaxLoadWeight = int.Parse(reader.ReadString());
                        if (reader.Name == "CurrentLoadWeight" && resultTrailer is not null)
                            resultTrailer.CurrentLoadWeight = int.Parse(reader.ReadString());
                        if (reader.Name == "Cargo" && resultTrailer is not null)
                            resultTrailer.Cargo = ReadCargo(reader);
                        break;
                }
            }
            return resultTrailer;
        }

        private static List<Truck> ReadTrucks(XmlReader reader)
        {
            var result = new List<Truck>();
            Truck resultTruck = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                    if (reader.Name == "Trucks")
                        break;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Type")
                        {
                            resultTruck = InitializeTruck(reader.ReadString());
                            result.Add(resultTruck);
                        }
                        if (reader.Name == "Consumption" && resultTruck is not null)
                                 resultTruck.Consumption = float.Parse(reader.ReadString());
                        if (reader.Name == "Trailer" && resultTruck is not null)
                            resultTruck.Semitrailer = ReadTrailer(reader);
                        break;
                }
            }
            return result;
        }

        private static Truck InitializeTruck(string type)
        {
            switch (type)
            {
                case "Transport.Trucks.Man":
                    return new Man();
                case "Transport.Trucks.Mercedes":
                    return new Mercedes();
                case "Transport.Trucks.Renault":
                    return new Renault();
                case "Transport.Trucks.Volvo":
                    return new Volvo();
                default: return new Mercedes();
            }
        }
        private static Semitrailer InitializeTrailer(string type)
        {
            switch (type)
            {
                case "Transport.Semitrailers.Tent":
                    return new Tent();
                case "Transport.Semitrailers.Refrigerator":
                    return new Refrigerator();
                case "Transport.Semitrailers.Tank":
                    return new Tank();
                default: return null;
            }
        }
        private static Cargo InitializeCargo(string type)
        {
            switch (type)
            {
                case "Goods.Goods.Fuel":
                    return new Fuel();
                case "Goods.Goods.Food":
                    return new Food();
                case "Goods.Goods.Chemistry":
                    return new Chemistry();
                default: return null;
            }
        }
    }
}