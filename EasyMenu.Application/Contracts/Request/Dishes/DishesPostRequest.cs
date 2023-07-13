using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.Dishes
{
    public class DishesPostRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

      //public Portion Portion { get; set; } --> Enum

        public bool? Promotion { get; set; }

        public decimal? PromotionPrice { get; set; }

        public string DisheTypeId { get; set; }
    }
}
