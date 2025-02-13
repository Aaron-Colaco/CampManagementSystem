using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
    }
}
