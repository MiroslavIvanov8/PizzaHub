using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.Services;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class RestaurantUnitTests
    {
        private PizzaHubDbContext dbContext;

        private IRepository repository;

        private IRestaurantService restaurantService;

        private ICollection<MenuItem> MenuItems;

        private Restaurant Restaurant;
        private MenuItem Margheritta;
        private MenuItem Pepperoni;
        private MenuItem Toscana;
        private MenuItem Hawaii;


        [SetUp]
        public async Task Setup()
        {
            Restaurant = new Restaurant()
            {
                Id = 1,
                Name = "PizzaHub"
            };

            Margheritta = new MenuItem()
            {

                Id = 1,
                Name = "Margherita",
                Ingredients = "Pizza Dough, Tomatoes, Fresh Mozzarella Balls, Fresh Basil, Olive Oil & Salt",
                ImageUrl =
                    "https://media.istockphoto.com/id/1168754685/photo/pizza-margarita-with-cheese-top-view-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=psLRwd-hX9R-S_iYU-sihB4Jx2aUlUr26fkVrxGDfNg=",
                Price = 9.99M,
                RestaurantId = 1,
            };
            Pepperoni = new MenuItem()
            {
                Id = 2,
                Name = "Pepperoni",
                Ingredients =
                    "Pizza Dough, Tomatoes, Crushed Red Pepper Flakes, Sliced Pepperoni, Crushed Tomatoes with Basil, Olive Oil & Salt",
                ImageUrl =
                    "https://media.istockphoto.com/id/1413684626/photo/classic-pepperoni-pizza-with-cut-slices-isolated-on-white.jpg?s=612x612&w=0&k=20&c=498sVNGAyb7IQb9T9z5X9pnnv0YZpDWgWWKZeDO6lKw=",
                Price = 13.50M,
                RestaurantId = 1,
            };
            Toscana = new MenuItem()
            {
                Id = 3,
                Name = "Toscana",
                Ingredients =
                    "Pizza Dough, Tomatoes, Cheese, Mushrooms, Diced Chicken, Mixed Peppers, Olive Oil & Salt",
                ImageUrl =
                    "https://media.istockphoto.com/id/635675852/photo/pizza-on-white-background.jpg?s=612x612&w=0&k=20&c=3z6N8hYH4yNRK8EbGJ4Pt7vszNw7dL_l8QwnNUz2Z_o=",
                Price = 14.99M,
                RestaurantId = 1,
            };
            Hawaii = new MenuItem()
            {
                Id = 4,
                Name = "Hawaii",
                Ingredients =
                    "Pizza Dough, Tomato Sauce, Mozzarella Cheese, Ham or Bacon, and Pineapple topped with Dried Oregano.",
                ImageUrl =
                    "https://media.istockphoto.com/id/503580316/photo/pizza-with-pineapple-and-ham-on-white-background.jpg?s=612x612&w=0&k=20&c=CArlgKntmtUpZENENw0plUmIo3jau3TjHKQ7gPXzfZc=",
                Price = 13.50M,
                RestaurantId = 1,
            };

            MenuItems = new List<MenuItem>()
            {
                Margheritta, Pepperoni, Toscana, Hawaii
            };

            var options = new DbContextOptionsBuilder<PizzaHubDbContext>()
                .UseInMemoryDatabase(databaseName: "PizzaHub" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new PizzaHubDbContext(options);

            await dbContext.AddAsync(Restaurant);
            await dbContext.AddRangeAsync(MenuItems);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            restaurantService = new RestaurantService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_Item_Exists_Returns_True()
        {
            bool resultTrue = await this.restaurantService.MenuItemExistsAsync(1);
            bool resultFalse = await this.restaurantService.MenuItemExistsAsync(5);

            Assert.AreEqual(resultTrue, true);
            Assert.AreEqual(resultFalse, false);
        }
    }
}