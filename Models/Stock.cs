using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Stock
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockId { get; set; }

        public string Brand { get; set; } = " ";

        public string Colour { get; set; } = " ";

        public string Notes { get; set; } = " ";

        public string StockNumber { get; set; } = " ";


        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Items { get; set; }

        [ForeignKey("User")]
        public string? OrderId { get; set; }

        public Order order { get; set; }


        public enum ClothingSize
        {
            Standard = 0,
            XS = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            XL = 5,
            XXL = 6
        }

        public enum ShoeSize
        {
            Standard = 0,
            US5 = 5,
            US6 = 6,
            US7 = 7,
            US8 = 8,
            US9 = 9,
            US10 = 10,
            US11 = 11,
            US12 = 12,
            US13 = 13,
            US14 = 14,
            US15 = 15
        }


        public ClothingSize? ClothingSizes { get; set; } = null;
        public ShoeSize? ShoeSizes { get; set; } = null;



    }

}
