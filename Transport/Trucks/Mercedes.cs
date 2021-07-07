namespace Transport.Trucks
{
    public class Mercedes:Truck
    {
        public Mercedes()
        {
            Consumption = Semitrailer.CurrentLoadWeight * 0.03f;
        }
        
    }
}