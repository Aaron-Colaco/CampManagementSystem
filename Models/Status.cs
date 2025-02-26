namespace WebApplication4.Models
{
    public class Status
    {
        public  int Id { get; set; }
public string name { get; set; }

    public  ICollection<Order> Orders { get; set; }
    }
}