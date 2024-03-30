using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateFormat = "dd/MM/yyyy HH:mm:ss";
        public static class AppEmailConstants
        {
            public const string FromAppEmail = "pizzamailtoyou@gmail.com";
            public const string FromAppTeam = "Pizza Hub Team";

            public const string OrderAcceptedSuccessfully = "Your order has been accepted successfully!";

            public const string OrderAcceptedBody =
                "Great news! Your order is now being prepared. Thanks for choosing us for your pizza delivery!";

            public const string CourierApprovalEmailMessage =
                "Congratulations! You've been approved to join our Courier ranks! Welcome to Pizza Hub Courier Service!";

            public const string CourierDeclinedEmailMessage =
                "We regret to inform you that your request to become a courier has been declined. We appreciate your interest and thank you for considering our platform.";
        }

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
