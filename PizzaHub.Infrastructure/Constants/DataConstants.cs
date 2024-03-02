namespace PizzaHub.Infrastructure.Constants
{
    public static class DataConstants
    {
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
    }
}
