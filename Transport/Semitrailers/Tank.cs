using System;
using System.Xml.Serialization;

namespace Transport.Semitrailers
{
    [SoapInclude(typeof(Semitrailer))]
    public class Tank:Semitrailer
    {
        public Tank()
        {
            MaxLoadWeight = 1700;
            CurrentLoadWeight = 200;
            Cargo = null;
        }
    }
}