using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User : IdentityUser
    {

        // First Name with min and max length validation
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        // Last Name with min and max length validation
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        // Date of Birth with a regex validation for format (e.g., MM/DD/YYYY)
        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-2][1-9]|3[0-1])\/\d{4}$", ErrorMessage = "Date of Birth must be in MM/DD/YYYY format.")]
        public string DOB { get; set; }

        // Student Number validation (6 digits only)
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Student Number must be exactly 6 digits.")]
        public string StudentNumber { get; set; }

        // Year Level must be between 0 and 9 (inclusive)
        [Required]
        [Range(9, 13, ErrorMessage = "Year Level must be between 9 and 13.")]
        public int YearLevel { get; set; }



        public ICollection<Order> Orders { get; set; }
    }
}
