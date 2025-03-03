using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Status
    {
        [Key]
        public  int Id { get; set; }
public string Name { get; set; }

    public  ICollection<Order> Orders { get; set; }
    }
}