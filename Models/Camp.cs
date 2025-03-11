using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Camp
    {
        [Key]
        public int Id { get; set; }

        public  DateTime Startdate { get; set; }

        
        public DateTime Enddate { get; set; }

        public int peoplelimt { get; set; }

        [Range(9,13)]
        public int Year { get; set; }

        public ICollection<User> Users { get; set; }



    }
}
