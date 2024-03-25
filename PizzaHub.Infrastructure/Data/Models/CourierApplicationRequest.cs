using System.ComponentModel.DataAnnotations.Schema;
using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.BecomeCourierForm;
    public class CourierApplicationRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
