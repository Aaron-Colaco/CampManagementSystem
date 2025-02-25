using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace WebApplication4.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
       public string LastName { get; set; }

        public string DOB { get; set; }

        public string StudentNumber { get; set; }

        public int year { get; set; }

    }
}
