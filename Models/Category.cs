using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Category
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
