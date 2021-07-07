namespace Transport.Trucks
{
    public class Man:Truck
    {
        public Man()
        {
            Consumption = Semitrailer.CurrentLoadWeight * 0.02f;
        }
    }
}