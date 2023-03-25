using JuiceStoreWeb.Models;
using JuiceStoreWeb.Repository;

namespace MontyHallSimulation.Service
{
    public interface IFruitPressServices
    {
        FruitPressResult Produce(IRecipie recipie, List<IFruit> fruits, int moneyPaid, int orderGlassQuantity);
        FruitPressRequest SetFruitPressData(FruitPressRequest fruitPressRequest);
        Recipie GetRecipie(int Id);
        List<Recipie> GetAllRecipie();
        List<Fruit> SetFruits(FruitPressRequest request);
    }
}
