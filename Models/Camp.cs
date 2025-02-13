using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Camp
    {
        [Key]
        public int CampId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }



    }
}
