using DataConstants = PizzaHub.Infrastructure.Constants.DataConstants;

namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    
    using static DataConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(NameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
