using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.Services;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class RestaurantServiceUnitTests
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
        public async Task Test_Item_Exists_Returns_Correct()
        {
            bool resultTrue = await this.restaurantService.MenuItemExistsAsync(1);
            bool resultFalse = await this.restaurantService.MenuItemExistsAsync(5);

            Assert.AreEqual(resultTrue, true);
            Assert.AreEqual(resultFalse, false);
        }

        [Test]
        public async Task Test_GetItemReturns_Correct()
        {
           MenuItemViewModel margherita = await this.restaurantService.GetItemAsync(1);
           MenuItemViewModel aNull = await this.restaurantService.GetItemAsync(10);


           Assert.AreEqual(margherita.Id, 1);
           Assert.AreEqual(aNull,null);
        }

        [Test]
        [TestCase("Pizza")]
        public async Task Test_GetMenuReturns_Correct(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.IsNotNull(menu);
            Assert.AreEqual(menu.Count(),4);
        }
        
        [TestCase("Ham? Bacon!   Pineapple")]
        public async Task Test_GetMenuReturns_Correct_If_SearchTerms_IsArr(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 1);
        }

        [TestCase("HAM,    bacon. PIneapple, PEpper")]
        public async Task Test_GetMenuReturns_Zero_If_SearchTerms_IsArr(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 0);
        }

        [TestCase("pepper")]
        public async Task Test_GetMenuReturns_Correct_If_TwoPizzas_Have_Shared_Ingredient(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 2);
        }

        [TestCase(null)]
        public async Task Test_GetMenuReturns_Correct_If_SearchTerm_Is_Null(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 4);
        }

        [TestCase("chips")]
        public async Task Test_GetMenuReturns_Correct_If_SearchTerm_Is_Not_Available(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 0);
        }

        [TestCase("    asda sdda sda sdasdwasdwasd ")]
        public async Task Test_GetMenuReturns_Correct_If_SearchTerm_Is_EmptyString_Or_NonSense(string searchTerm)
        {
            var menu = await restaurantService.GetMenuAsync(searchTerm);

            Assert.AreEqual(menu.Count(), 0);
        }

        [Test]
        public async Task Test_ShowBestSellers_Should_Return_Correct_If_No_Data()
        {
            var bestSellers = await restaurantService.ShowBestSellersAsync();

            Assert.AreEqual(bestSellers.Count(), 0);
        }

        [Test]
        public async Task Test_ShowBestSellers_Should_Return_Correct_With_Data()
        {
            OrderItem orderItem1 = new OrderItem()
            {
                Id = 1,
                MenuItemId = 1,
                Quantity = 3
            };
            OrderItem orderItem2 = new OrderItem()
            {
                Id = 2,
                MenuItemId = 2,
                Quantity = 2
            };
            OrderItem orderItem3 = new OrderItem()
            {
                Id = 3,
                MenuItemId =3,
                Quantity = 1
            };

            await repository.AddAsync(orderItem1);
            await repository.AddAsync(orderItem2);
            await repository.AddAsync(orderItem3);
            await repository.SaveChangesAsync();

            var bestSellers = await restaurantService.ShowBestSellersAsync();

            Assert.AreEqual(bestSellers.Count(), 3);
        }

        [Test]
        public async Task Test_ShowBestSellers_Should_Return_Correct_With_Only_Two()
        {
            OrderItem orderItem1 = new OrderItem()
            {
                Id = 1,
                MenuItemId = 1,
                Quantity = 3
            };
            OrderItem orderItem2 = new OrderItem()
            {
                Id = 2,
                MenuItemId = 2,
                Quantity = 2
            };
            

            await repository.AddAsync(orderItem1);
            await repository.AddAsync(orderItem2);
            await repository.SaveChangesAsync();

            var bestSellers = await restaurantService.ShowBestSellersAsync();

            Assert.AreEqual(bestSellers.Count(), 2);
        }

        [Test]
        public async Task Test_ShowBestSellers_Should_Return_Correct_Quantity_Items()
        {
            OrderItem orderItem1 = new OrderItem()
            {
                Id = 1,
                MenuItemId = 1,
                Quantity = 4
            };
            OrderItem orderItem2 = new OrderItem()
            {
                Id = 2,
                MenuItemId = 2,
                Quantity = 3
            };
            OrderItem orderItem3 = new OrderItem()
            {
                Id = 3,
                MenuItemId = 3,
                Quantity = 2
            };

            OrderItem orderItem4 = new OrderItem()
            {
                Id = 4,
                MenuItemId = 4,
                Quantity = 1
            };
            await repository.AddAsync(orderItem1);
            await repository.AddAsync(orderItem2);
            await repository.AddAsync(orderItem3);
            await repository.AddAsync(orderItem4);

            await repository.SaveChangesAsync();

            var bestSellers = await restaurantService.ShowBestSellersAsync();

            List<int> expectedItemIds = new List<int> { 1, 2, 3 };
            
            Assert.AreEqual(bestSellers.Count(), 3);

            foreach (var bestSeller in bestSellers)
            {
                Assert.IsTrue(expectedItemIds.Contains(bestSeller.Id));
            }
        }
    }
}