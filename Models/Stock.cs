using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Stock
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockId { get; set; }

         [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Items { get; set; }

        [ForeignKey("User")]
        public string? OrderId { get; set; }

        public Order order { get; set; }


    }

}
