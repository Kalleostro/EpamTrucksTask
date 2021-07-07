namespace Transport.Trucks
{
    public class Renault:Truck
    {
        public Renault()
        {
            Consumption = Semitrailer.CurrentLoadWeight * 0.04f;
        }
    }
}