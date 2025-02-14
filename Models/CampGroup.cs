using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class CampGroup
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }

         }
}
