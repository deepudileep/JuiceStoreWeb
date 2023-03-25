using JuiceStoreWeb.Models;
using JuiceStoreWeb.Repository;
using System.Xml.Linq;

namespace MontyHallSimulation.Helper
{
    public class FruitRepo : IFruitRepo
    {
        public List<Recipie> GetRecipie()
        {
            List<Recipie> recipies = new List<Recipie>();
            try
            {
                recipies.Add(new Recipie()
                {
                    ID = 1,
                    Name = "Apple Lemonade",
                    AllowedFruit = new Fruit() { Name = "Apple" },
                    ConsumptionPerGlass = 2.5M,
                    PricePerGlass = 10
                });
                recipies.Add(new Recipie()
                {
                    ID = 2,
                    Name = "Orange Lemonade",
                    AllowedFruit = new Fruit() { Name = "Orange" },
                    ConsumptionPerGlass = .5M,
                    PricePerGlass = 9
                });
                recipies.Add(new Recipie()
                {
                    ID = 3,
                    Name = "Melon Lemonade",
                    AllowedFruit = new Fruit() { Name = "Melon" },
                    ConsumptionPerGlass = 1,
                    PricePerGlass = 12
                });

            }
            catch (Exception e)
            {

            }
            return recipies;
        }

        public List<Fruit> SetFruits(FruitPressRequest fruitPressRequest)
        {
            List<Fruit> fruits = new List<Fruit>();
            try
            {
                fruits.Add(new Fruit()
                {
                    Name = "Apple",
                    Id = 1,
                    Quantity = fruitPressRequest.ApplesAdded
                });
                fruits.Add(new Fruit()
                {
                    Name = "Orange Lemonade",
                    Id = 2,
                    Quantity = fruitPressRequest.OrangeAdded
                });
                fruits.Add(new Fruit()
                {
                    Name = "Melon",
                    Id = 31,
                    Quantity = fruitPressRequest.MelonAdded
                });


            }
            catch (Exception e)
            {

            }
            return fruits;
        }
    }
}
