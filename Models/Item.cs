using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Item
    {
        [Key]
        //Sets the feild as the primary key feild (unique identifer).
        public int ItemId { get; set; }

        //Sets the name feild for the item as required and also sets the max length.
        [Required, MaxLength(50)]
        public string Name { get; set; }

        //Sets the range to (1 to 500) and also sets the data type of the price feild to currency
        [Required, DataType(DataType.Currency), Range(1, 500)]
        public double Price { get; set; }

        //Sets the range to (1 to 500) and also sets the data type of the price feild to currency
        [Required, DataType(DataType.Currency), Range(1, 500)]
        public decimal CostToProduce { get; set; }
        //Sets the max lenght to 100 characters for this feild.
        [MaxLength(1000)]
        public string ImageURL { get; set; }

        


        [ForeignKey("Category"), Required]
        public int CategoryId { get; set; }


        public Category Categorys { get; set; }



    }
}
