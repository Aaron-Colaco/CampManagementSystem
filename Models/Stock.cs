using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Stock
    {
        [Key]
       

        public int StockId { get; set; }

         [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Items { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public User user { get; set; }


    }

}
