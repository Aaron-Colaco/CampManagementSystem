using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Order
    {


        [Key]
        public string OrderId { get; set; }

        // Time the order was placed, required and defaulted to current time
        [Required]
        public DateTime OrderTime { get; set; } = DateTime.Now;

        // Total price of the order, required to be between 1 and 1000, formatted as currency
        [DataType(DataType.Currency), Range(1, 1000)]
        public decimal TotalPrice { get; set; }

        public DateTime HireEndDate{get; set;} 



    }
}
