namespace JuiceStoreWeb.Repository
{
    public interface IFruit
    {
        string Name { get; }
        int Id { get; }
        decimal Quantity { get; }
    }
    public class Fruit : IFruit
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Quantity { get; set; }
    }
}
