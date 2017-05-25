using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Icon { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }
    }
}