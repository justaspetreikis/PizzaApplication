using PizzaOrderApp.Data.Models;

namespace PizzaOrderApp.Data.Dtos
{
    public class PizzaOrderResponse
{
    public int OrderId { get; set; }
    public string SizeName { get; set; }
    public List<Topping> Toppings { get; set; }
    public decimal TotalCost { get; set; }
}
}