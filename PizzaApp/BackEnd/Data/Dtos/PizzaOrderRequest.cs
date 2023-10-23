using PizzaOrderApp.Data.Models;

namespace PizzaOrderApp.Data.Dtos
{
    public class PizzaOrderRequest
    {
        public int SizeId { get; set; }
        public List<int> ToppingIds { get; set; }
    }
}

