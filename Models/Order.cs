using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace WebApplication4.Models
{
    public class Order
    {


        [Key]
        public string OrderId { get; set; }


        // Time the order was placed, required and defaulted to current time
        [Required]
        public DateTime OrderTime { get; set; } = DateTime.Now;

        public DateTime HireEndDate { get; set; }

        // Total price of the order, required to be between 1 and 1000, formatted as currency
        [DataType(DataType.Currency), Range(1, 1000)]
        public decimal TotalPrice { get; set; }

         
        public ICollection<OrderItem> OrderItems { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }

        public User user { get; set; }



        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public Status status{ get; set; }



    }
}
