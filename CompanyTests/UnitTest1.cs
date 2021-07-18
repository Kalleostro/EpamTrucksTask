using System;
using Company;
using Goods.Goods;
using NUnit.Framework;

namespace CompanyTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AutoPark park = new AutoPark();
            //park.GetCombinedTrucks<Fuel>();
            StreamReaderSerializer.WriteXml(park);
            //park = Serializer.ReadXml();
            Assert.True(true);
        }
    }
}