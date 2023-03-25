using JuiceStoreWeb.Models;

namespace JuiceStoreWeb.Repository
{
    public interface IFruitRepo
    {
        List<Recipie> GetRecipie();
        List<Fruit> SetFruits(FruitPressRequest fruitPressRequest);
    }
}
