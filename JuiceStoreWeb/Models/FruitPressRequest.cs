using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JuiceStoreWeb.Models
{
    public class FruitPressRequest
    {
        /// <summary>
        /// Result
        /// </summary>
        public string RecipieName { get; set; }

        [Display(Name = "Select Recipe")]
        public int RecipieID { get; set; }

        public List<SelectListItem> RecipieList { get; set; }

        [Display(Name = "Name")]
        public int OrderQuantity { get; set; }
        [Display(Name = "Money Paid")]
        public int MoneyPaid { get; set; }
        [Display(Name = "Apples Added")]
        public decimal ApplesAdded { get; set; }
        [Display(Name = "Melon Added")]
        public decimal MelonAdded { get; set; }
        [Display(Name = "Orange Added")]
        public decimal OrangeAdded { get; set; }
        public FruitPressResult FruitPressResult { get; set; }

    }
}
