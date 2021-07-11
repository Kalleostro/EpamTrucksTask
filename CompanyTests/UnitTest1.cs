using Company;
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
            Serializer serializer = new Serializer();
            serializer.WriteXML();
            Assert.True(park is not null);
        }
    }
}