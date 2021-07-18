using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Goods;
using Transport;
using Transport.Semitrailers;
using Transport.Trucks;

namespace Company
{
    public static class StreamReaderSerializer
    {
        public static void WriteXml(AutoPark park)
        {
            var writer = new XmlSerializer(typeof(AutoPark));
            var writeFile = new StreamWriter("StreamPark.xml");
            writer.Serialize(writeFile, park);
            writeFile.Close();
        }

        public static AutoPark ReadXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(AutoPark));
            StreamReader file =
                new StreamReader(
                    "/Users/kalleostro/Desktop/Учёба/EpamTask2Shemetkov/EpamTrucksTask/CompanyTests/bin/Debug/net5.0/StreamPark.xml");
            AutoPark newPark = (AutoPark) reader.Deserialize(file);
            file.Close();
            return newPark;
        }
    }
}