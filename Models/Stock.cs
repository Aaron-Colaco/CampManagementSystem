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


        public enum ClothingSize
        {
            Small = 1,
            Medium = 2,
            Large = 3,
            XLarge = 4
        }

        public enum ShoeSize
        {
            US6 = 6,
            US7 = 7,
            US8 = 8,
            US9 = 9,
            US10 = 10,
            US11 = 11,
            US12 = 12
        }

        public ClothingSize? ClothingSizes { get; set; } = null;
        public ShoeSize? ShoeSizes { get; set; } = null;



    }

}
