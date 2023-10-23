using System.Text.Json.Serialization;

namespace PizzaOrderApp.Data.Models
{
    public class PizzaOrderTopping
    {
        public int PizzaOrderId { get; set; }
        [JsonIgnore]
        public PizzaOrder PizzaOrder { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
