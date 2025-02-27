using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        //Primary key feild
        public string OrderItemId { get; set; }

        //sets the defualt quantity to 1
        public int Quantity { get; set; } = 1;

        //foreign key to set up the relastonship with the order table(many to many)
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public Order Orders { get; set; }

        //foreign key to set up the relastonship with the item table(many to many)
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Items { get; set; }


        [ForeignKey("Camp")]
        public int CampId { get; set; }






    }
}
