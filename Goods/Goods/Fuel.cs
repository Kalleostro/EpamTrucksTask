namespace Goods.Goods
{
    public class Fuel:Cargo
    {
        public FuelTypes FuelType { get; set; }

        public Fuel(FuelTypes fuelType)
        {
            FuelType = fuelType;
        }
    }
}