using Microsoft.EntityFrameworkCore;
using PizzaOrderApp.Data.Database;
using PizzaOrderApp.Data.Models;
using PizzaOrderApp.Interfaces;

namespace PizzaOrderApp.Repositories
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaOrderAppDbContext _dbcontext;

        public PizzaOrderRepository(PizzaOrderAppDbContext dbContext)
        {
            _dbcontext = dbContext;

            if (!_dbcontext.PizzaSize.Any() && !_dbcontext.Toppings.Any())
            {
                SeedInitialData();
            }
        }

        public async Task SavePizzaOrderAsync(PizzaOrder order)
        {
            _dbcontext.PizzaOrders.Add(order);

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error saving pizza order to database", ex);
            }
        }

        public async Task<List<PizzaOrder>> GetAllPizzaOrdersAsync()
        {
            return await _dbcontext.PizzaOrders
                .Include(order => order.PizzaOrderToppings)
                .ThenInclude(pot => pot.Topping)
                .ToListAsync();
        }

        public async Task<List<PizzaSize>> GetPizzaSizesListAsync()
        {
            return await _dbcontext.PizzaSize.ToListAsync();
        }

        public async Task<List<Topping>> GetToppingsListAsync()
        {
            return await _dbcontext.Toppings.ToListAsync();
        }

        public async Task<decimal> GetPriceOfPizzaSizeAsync(int pizzaSizeId)
        {
            var selectedPizza = await _dbcontext.PizzaSize.FirstOrDefaultAsync(i => i.Id == pizzaSizeId);
            return selectedPizza.Price;
        }

        public async Task<Topping> GetToppingByIdAsync(int toppingId)
        {
            var selectedTopping = await _dbcontext.Toppings.FirstOrDefaultAsync(i => i.Id == toppingId);
            return selectedTopping;
        }

        private void SeedInitialData()
        {
            var pizzaSizes = new List<PizzaSize>
            {
                new PizzaSize { Id = 1, Name = "Small", Price = 8 },
                new PizzaSize { Id = 2, Name = "Medium", Price = 10 },
                new PizzaSize { Id = 3, Name = "Large", Price = 12 }
            };

            var toppings = new List<Topping>
            {
                new Topping { Id = 1, Name = "Cheese", Price = 1 },
                new Topping { Id = 2, Name = "Tomato", Price = 1 },
                new Topping { Id = 3, Name = "Pepperoni", Price = 1 },
                new Topping { Id = 4, Name = "Sausage", Price = 1 },
                new Topping { Id = 5, Name = "Bacon", Price = 1 },
                new Topping { Id = 6, Name = "Mushrooms", Price = 1 }
            };

            _dbcontext.PizzaSize.AddRange(pizzaSizes);
            _dbcontext.Toppings.AddRange(toppings);

            try
            {
                _dbcontext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error adding initial data to the database", ex);
            }
        }
    }
}
