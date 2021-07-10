namespace Transport.Semitrailers
{
    public class Tent:Semitrailer
    {
        public Tent()
        {
            MaxLoadWeight = 1500;
            CurrentLoadWeight = 200;
            Cargo = null;
        }
    }
}