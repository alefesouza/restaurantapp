using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }

        // Same name for class and property, C# things...
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
