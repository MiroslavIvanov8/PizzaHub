using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Services;
using ApplicationUser = PizzaHub.Infrastructure.Data.Models.ApplicationUser;
using MenuItem = PizzaHub.Infrastructure.Data.Models.MenuItem;
using Order = PizzaHub.Infrastructure.Data.Models.Order;
using OrderStatus = PizzaHub.Infrastructure.Data.Models.OrderStatus;
using Restaurant = PizzaHub.Infrastructure.Data.Models.Restaurant;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Core.ViewModels.Cart;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class CartServiceUnitTests
    {
        private PizzaHubDbContext dbContext;

        private IRepository repository;

        private ICartService cartService;
        private ICustomerService customerService;
        private IRestaurantService restaurantService;

        private Restaurant Restaurant;

        private ICollection<MenuItem> MenuItems;
        private ICollection<OrderStatus> OrderStatuses;
        private ICollection<CustomerCart> CustomerCarts;
        
        private Customer Customer;
        private ApplicationUser CustomerUser;

        private MenuItem Margheritta;
        private MenuItem Pepperoni;
        private MenuItem Toscana;
        private MenuItem Hawaii;

        private CustomerCart MargharittaCart;
        private CustomerCart PeperroniCart;
        private CustomerCart ToscanaCart;

        private OrderStatus Pending;
        private OrderStatus InProgress;
        private OrderStatus OutForDelivery;
        private OrderStatus Delivered;
        private OrderStatus Canceled;


        [SetUp]
        public async Task Setup()
        {
            Restaurant = new Restaurant()
            {
                Id = 1,
                Name = "PizzaHub"
            };

            CustomerUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Miroslav",
                LastName = "Ivanov",
                BirthDate = DateTime.ParseExact("01.10.1998", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Email = "starskriim@abv.bg",
                PasswordHash = "123123123123123"
            };
            Customer = new Customer()
            {
                Id = 1,
                UserId = CustomerUser.Id,
            };

            Pending = new OrderStatus { Id = 1, Name = "Pending" };
            InProgress = new OrderStatus { Id = 2, Name = "In Progress" };
            OutForDelivery = new OrderStatus { Id = 3, Name = "Out for Delivery" };
            Delivered = new OrderStatus { Id = 4, Name = "Delivered" };
            Canceled = new OrderStatus { Id = 5, Name = "Cancelled" };
            OrderStatuses = new List<OrderStatus>()
            {
                Pending, InProgress, OutForDelivery, Delivered, Canceled
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

            MargharittaCart = new CustomerCart()
            {
                CustomerId = 1,
                MenuItemId = 1,
                Quantity = 1
            };
            PeperroniCart = new CustomerCart()
            {
                CustomerId = 1,
                MenuItemId = 2,
                Quantity = 2
            };
            ToscanaCart = new CustomerCart()
            {
                CustomerId = 1,
                MenuItemId = 3,
                Quantity = 3
            };

            CustomerCarts = new List<CustomerCart>()
            {
                MargharittaCart, PeperroniCart, ToscanaCart
            };

            var options = new DbContextOptionsBuilder<PizzaHubDbContext>()
                .UseInMemoryDatabase(databaseName: "PizzaHub" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new PizzaHubDbContext(options);
            repository = new Repository(dbContext);

            restaurantService = new RestaurantService(repository);
            customerService = new CustomerService(repository);
            cartService = new CartService(repository, restaurantService, customerService);

            await dbContext.AddAsync(Restaurant);
            await dbContext.AddAsync(CustomerUser);
            await dbContext.AddAsync(Customer);
            await dbContext.AddRangeAsync(OrderStatuses);
            await dbContext.AddRangeAsync(MenuItems);
            await dbContext.AddRangeAsync(CustomerCarts);
            await dbContext.SaveChangesAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task MyCartAsync_Should_Return_Correct_Model()
        {
            var result = await cartService.MyCartAsync(Customer.Id);
            
            Assert.IsInstanceOf<ICollection<CartItemViewModel>>(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}