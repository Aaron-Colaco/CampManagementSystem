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

            [Display(Name = "2XS")]
            XXS = 1,

            XS = 2,

            S = 3,

            M = 4,

            L = 5,

            XL = 6,

            [Display(Name = "XXL")]
            XXL = 7,

            [Display(Name = "XXXL")]
            XXXL = 8,

            [Display(Name = "4XL")]
            XXXXL = 9
        }

        public enum ShoeSize
        {
            US3 = 30,
            US3_5 = 35,
            US4 = 40,
            US4_5 = 45,
            US5 = 50,
            US5_5 = 55,
            US6 = 60,
            US6_5 = 65,
            US7 = 70,
            US7_5 = 75,
            US8 = 80,
            US8_5 = 85,
            US9 = 90,
            US9_5 = 95,
            US10 = 100,
            US10_5 = 105,
            US11 = 110,
            US11_5 = 115,
            US12 = 120,
            US12_5 = 125,
            US13 = 130,
            US13_5 = 135,
            US14 = 140,
            US14_5 = 145,
            US15 = 150
        }


        public ClothingSize? ClothingSizes { get; set; } = null;
        public ShoeSize? ShoeSizes { get; set; } = null;



    }

}
