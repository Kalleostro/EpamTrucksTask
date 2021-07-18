using System;
using System.Xml.Serialization;
using Goods.Goods;

namespace Goods
{
    [XmlInclude(typeof(Fuel))]
    [Serializable]
    public abstract class Cargo
    {
        public int Weight { get; set; }
    }
}