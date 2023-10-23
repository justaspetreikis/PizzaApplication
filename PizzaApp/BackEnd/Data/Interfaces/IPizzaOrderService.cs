using PizzaOrderApp.Data.Dtos;
using PizzaOrderApp.Data.Models;

namespace PizzaOrderApp.Interfaces
{
    public interface IPizzaOrderService
    {
        /// <summary>
        /// Saves a new pizza order based on the provided order request.
        /// </summary>
        /// <param name="order">The pizza order request containing order details.</param>
        /// <returns>The saved pizza order.</returns>
        Task<PizzaOrder> SavePizzaOrderAsync(PizzaOrderRequest order);

        /// <summary>
        /// Retrieves a list of all pizza orders.
        /// </summary>
        /// <returns>A list of pizza orders.</returns>
        Task<List<PizzaOrderResponse>> GetAllPizzaOrdersAsync();

        /// <summary>
        /// Retrieves a list of all available toppings.
        /// </summary>
        Task<List<Topping>> GetAllToppingsAsync();

        /// <summary>
        /// Retrieves a list of all available pizza sizes.
        /// </summary>
        Task<List<PizzaSize>> GetAllPizzaSizesAsync();
    }
}
