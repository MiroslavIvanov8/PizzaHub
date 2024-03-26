using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Core.ViewModels.Courier
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.BecomeCourierForm;
    using static MessageConstants.ErrorMessages;
    public class BecomeCourierForm
    {
        public string UserId { get; set; } = string.Empty;
        
        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(pattern: PhoneNumberNumberRegex, ErrorMessage = PhoneNumberErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength,
           MinimumLength = DescriptionMinLength,
           ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

    }
}
