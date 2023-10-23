using PizzaOrderApp.Data.Dtos;
using PizzaOrderApp.Data.Models;
using PizzaOrderApp.Interfaces;

namespace PizzaOrderApp.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IPizzaOrderRepository _pizzaOrderRepository;

        public PizzaOrderService(IPizzaOrderRepository pizzaOrderRepository)
        {
            _pizzaOrderRepository = pizzaOrderRepository;
        }

        public async Task<PizzaOrder> SavePizzaOrderAsync(PizzaOrderRequest order)
        {
            var newPizzaOrder = new PizzaOrder
            {
                SizeId = order.SizeId,
                TotalCost = await CalculateTotalCost(order.SizeId, order.ToppingIds),
                PizzaOrderToppings = new List<PizzaOrderTopping>()
            };

            foreach (var toppingId in order.ToppingIds)
            {
                var selectedTopping = await _pizzaOrderRepository.GetToppingByIdAsync(toppingId);
                if (selectedTopping != null)
                {
                    newPizzaOrder.PizzaOrderToppings.Add(new PizzaOrderTopping
                    {
                        Topping = selectedTopping
                    });
                }
            }

            await _pizzaOrderRepository.SavePizzaOrderAsync(newPizzaOrder);

            return newPizzaOrder;
        }

       public async Task<List<PizzaOrderResponse>> GetAllPizzaOrdersAsync()
       {
            var pizzaOrders = await _pizzaOrderRepository.GetAllPizzaOrdersAsync();
            var sizes = await _pizzaOrderRepository.GetPizzaSizesListAsync();
            var toppings = await _pizzaOrderRepository.GetToppingsListAsync();

            var pizzaOrderResponses = new List<PizzaOrderResponse>();

            foreach (var pizzaOrder in pizzaOrders)
            {
                var size = sizes.FirstOrDefault(s => s.Id == pizzaOrder.SizeId);
                if (size != null)
                {
                    var toppingIds = pizzaOrder.PizzaOrderToppings.Select(pt => pt.ToppingId).ToList();
                    var pizzaOrderToppings = toppings.Where(t => toppingIds.Contains(t.Id)).ToList();

                    var pizzaOrderResponse = new PizzaOrderResponse
                    {
                        OrderId = pizzaOrder.Id,
                        SizeName = size.Name,
                        Toppings = pizzaOrderToppings,
                        TotalCost = pizzaOrder.TotalCost
                    };

                    pizzaOrderResponses.Add(pizzaOrderResponse);
                }
            }

            return pizzaOrderResponses;
       }

        public async Task<List<Topping>> GetAllToppingsAsync()
        {
            return await _pizzaOrderRepository.GetToppingsListAsync();
        }

        public async Task<List<PizzaSize>> GetAllPizzaSizesAsync()
        {
            return await _pizzaOrderRepository.GetPizzaSizesListAsync();
        }

        private async Task<decimal> CalculateTotalCost(int pizzaSizeId, List<int> toppingsIds)
        {
            var pizzaSizePrice = await _pizzaOrderRepository.GetPriceOfPizzaSizeAsync(pizzaSizeId);

            decimal toppingsPrice = 0;

            foreach (int toppingId in toppingsIds)
            {
                var topping = await _pizzaOrderRepository.GetToppingByIdAsync(toppingId);
                toppingsPrice += topping.Price;
            }

            var totalCount = (toppingsIds.Count >= 3) ? (pizzaSizePrice + toppingsPrice) * 0.9m : pizzaSizePrice + toppingsPrice;

            return Math.Round(totalCount, 2);
        }
    }
}
