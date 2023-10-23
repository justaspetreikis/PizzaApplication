using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderApp.Data.Models
{
    public class PizzaOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SizeId { get; set; }
        public List<PizzaOrderTopping> PizzaOrderToppings { get; set; }
        public decimal TotalCost { get; set; }
    }
}

