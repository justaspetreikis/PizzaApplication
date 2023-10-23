using PizzaOrderApp.Data.Models;

namespace PizzaOrderApp.Interfaces
{
    public interface IPizzaOrderRepository
    {
        /// <summary>
        /// Saves a new pizza order to the repository.
        /// </summary>
        /// <param name="order">The pizza order object to add.</param>
        Task SavePizzaOrderAsync(PizzaOrder order);

        /// <summary>
        /// Retrieves a list of all pizza orders.
        /// </summary>
        Task<List<PizzaOrder>> GetAllPizzaOrdersAsync();

        /// <summary>
        /// Retrieves a list of all available pizza sizes.
        /// </summary>
        Task<List<PizzaSize>> GetPizzaSizesListAsync();

        /// <summary>
        /// Retrieves a list of all available toppings.
        /// </summary>
        Task<List<Topping>> GetToppingsListAsync();

        /// <summary>
        /// Finds the price of a pizza by the selected pizza size ID.
        /// </summary>
        /// <param name="pizzaSizeId">The pizza size ID to search for.</param>
        /// <returns>Price of the selected size pizza in decimals</returns>
        Task<decimal> GetPriceOfPizzaSizeAsync(int pizzaSizeId);

        /// <summary>
        /// Retrieves information about a topping based on its ID.
        /// </summary>
        /// <param name="toppingId">The ID of the topping to retrieve.</param>
        Task<Topping> GetToppingByIdAsync(int toppingId);
    }
}
