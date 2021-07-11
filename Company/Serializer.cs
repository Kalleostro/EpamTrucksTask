using System;
using System.Diagnostics;
using System.Web;
using System.Xml;
using Goods;
using Transport;

namespace Company
{
    public class Serializer
    {
        public void WriteXML()
        {
            var writer = XmlWriter.Create("park.xml");
            writer.WriteStartElement("AutoPark");
            
            writer.WriteStartElement("Trucks");
            foreach (var truck in (AutoPark.Trucks))
            {
                SerializeTruck(truck, writer);
            }
            writer.WriteEndElement();
            
            writer.WriteStartElement("Trailers");
            foreach (var trailer in (AutoPark.Semitrailers))
            {
                SerializeTrailer(trailer, writer);
            }
            writer.WriteEndElement();
            
            writer.WriteEndElement();
            writer.Flush();
        }

        public void ReadXML()
        {
            
        }

        public void SerializeCargo(Cargo cargo, XmlWriter writer)
        {
            writer.WriteStartElement("Cargo");
            writer.WriteStartElement("Type");
            writer.WriteValue(cargo.GetType().ToString());
            writer.WriteEndElement();
            
            writer.WriteStartElement("Weight");
            writer.WriteValue(cargo.Weight);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
        
        private void SerializeTrailer(Semitrailer trailer, XmlWriter writer)
        {
            writer.WriteStartElement("Trailer");
            writer.WriteStartElement("Type");
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
        
        private void SerializeTruck(Truck truck, XmlWriter writer)
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
    }
}