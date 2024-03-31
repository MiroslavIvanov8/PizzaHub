using System.ComponentModel.DataAnnotations;
using static PizzaHub.Infrastructure.Constants.DataConstants.MenuItem;
using static PizzaHub.Infrastructure.Constants.MessageConstants.ErrorMessages;
namespace PizzaHub.Core.ViewModels.MenuItem
{
    public class MenuItemFormModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(IngredientsMaxLength,
            MinimumLength = IngredientsMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Ingredients { get; set; } = null!;
        
        [Required(ErrorMessage = RequiredErrorMessage)] 
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal Price { get; set; }
    }
}
