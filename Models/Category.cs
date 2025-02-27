using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Category
    {
        [Required]
        [MaxLength(30)]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        ICollection<Item> Items { get; set; }
    }
}
