namespace JuiceStoreWeb.Repository
{
    public interface IRecipie
    {
        int ID { get; }
        string Name { get; }
        Fruit AllowedFruit { get; }
        decimal ConsumptionPerGlass { get; }
        int PricePerGlass { get; }
    }
    public class Recipie : IRecipie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Fruit AllowedFruit { get; set; }
        public decimal ConsumptionPerGlass { get; set; }
        public int PricePerGlass { get; set; }
    }
}
