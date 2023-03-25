using Microsoft.AspNetCore.Mvc;
using JuiceStoreWeb.Controllers;
using JuiceStoreWeb.Repository;
using JuiceStoreWeb.Models;
using MontyHallSimulation.Service;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JuiceStoreWeb.Service
{
    public class FruitPressServices : IFruitPressServices
    {
        private readonly ILogger<HomeController> logger;
        private readonly IFruitRepo repo;

        public FruitPressServices(ILogger<HomeController> logger, IFruitRepo repo)
        {
            this.logger = logger;
            this.repo = repo;
        }

        public FruitPressResult Produce(IRecipie recipie, List<IFruit> fruits, int moneyPaid, int orderGlassQuantity)
        {
            FruitPressResult fruitPressResult = new FruitPressResult();
            try
            {
                int totalAmount = orderGlassQuantity * recipie.PricePerGlass;
                decimal totalFruits = orderGlassQuantity * recipie.ConsumptionPerGlass;
                decimal availableFruits = fruits.FirstOrDefault(x => x.Id == recipie.ID).Quantity;
                int glassCount =(int) (availableFruits / recipie.ConsumptionPerGlass);
                if (totalAmount > moneyPaid)
                {
                    fruitPressResult.Balance += moneyPaid;
                    fruitPressResult.ResultMoney = "Error Money Only Enough for (" + glassCount + ") glasses " + fruitPressResult.Balance + " more Needed";
                }
                else
                {
                    fruitPressResult.ResultMoney = "Money  Enough for ( " + glassCount + " )glasses and balance amount is " + fruitPressResult.Balance;
                    fruitPressResult.ResultType = true;
                }

                if (totalFruits > availableFruits)
                {
                    fruitPressResult.BalanceFruits += availableFruits;
                    fruitPressResult.ResultGlass = "Error Fruits Only Enough for (" + glassCount + ") glasses " + fruitPressResult.BalanceFruits + " more Needed";
                }
                else
                {
                    fruitPressResult.ExtraFruits = totalFruits - availableFruits;
                    fruitPressResult.ResultGlass = " Fruits Enough for (" + glassCount + ") glasses  and balance Fruit is " + fruitPressResult.ExtraFruits;
                }


            }
            catch (Exception ex)
            {
            }
            return fruitPressResult;
        }
        public FruitPressRequest SetFruitPressData(FruitPressRequest fruitPressRequest)
        {
            try
            {
                fruitPressRequest.RecipieList = new();
                foreach (var item in repo.GetRecipie())
                {
                    fruitPressRequest.RecipieList.Add(
                        new SelectListItem { Value = item.ID.ToString(), Text = item.Name }
                        );
                }
            }
            catch (Exception ex)
            {
            }
            return fruitPressRequest;
        }

        public List<Recipie> GetAllRecipie()
        {
            List<Recipie> reciepie = new List<Recipie>();
            try
            {
                reciepie = repo.GetRecipie();
            }
            catch (Exception ex)
            {
            }
            return reciepie;
        }

        public List<Fruit> SetFruits(FruitPressRequest request)
        {

            return repo.SetFruits(request);
        }
        public Recipie GetRecipie(int Id)
        {
            Recipie reciepie = new Recipie();
            try
            {
                reciepie = repo.GetRecipie().FirstOrDefault(x => x.ID == Id);
            }
            catch (Exception ex)
            {
            }
            return reciepie;
        }
    }
}
