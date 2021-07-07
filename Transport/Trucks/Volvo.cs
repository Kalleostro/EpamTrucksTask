namespace Transport.Trucks
{
    public class Volvo:Truck
    {
        public Volvo()
        {
            Consumption = Semitrailer.CurrentLoadWeight * 0.025f;
        }
    }
}