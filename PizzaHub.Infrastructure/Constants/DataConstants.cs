using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateFormat = "dd/MM/yyyy HH:mm:ss";
        
        public static class ApplicationUser
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class Restaurant
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class MenuItem
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int IngredientsMaxLength = 500;
            public const int IngredientsMinLength = 30;
        }

        public static class OrderStatus
        {
            public const int StatusNameMaxLength = 20;
            public const int StatusNameMinLength = 10;
        }

        public static class Order
        {
            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 3;
        }

        public static class BecomeCourierForm
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 3;

            public const string PhoneNumberNumberRegex = @"^\+\d{10}$";
            public const string PhoneNumberErrorMessage = "Telephone Number should be like +012 345 6789";
            public const int PhoneNumberMaxLength = 11;
            public const int PhoneNumberMinLength = 11;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 50;
        }
    }
}
