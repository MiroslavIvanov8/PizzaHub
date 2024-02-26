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
    }
}
