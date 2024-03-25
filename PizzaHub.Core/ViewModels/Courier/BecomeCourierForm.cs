using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Core.ViewModels.Courier
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.BecomeCourierForm;
    using static ErrorMessages;
    public class BecomeCourierForm
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthErrorMessage )]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(pattern: TelephoneNumberRegex, ErrorMessage = TelephoneNumberErrorMessage)]
        public string TelephoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength,
           MinimumLength = DescriptionMinLength,
           ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        //TODO add a dateBirth validation.
    }
}
