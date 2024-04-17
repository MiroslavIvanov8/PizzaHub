using System.Collections;
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
using Moq;
using PizzaHub.Core.ViewModels.Cart;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class CartServiceUnitTestsMoq
    {
        private PizzaHubDbContext dbContext;

        private IRepository repository;
        private ICartService cartService;

        private Mock<IRestaurantService> restaurantServiceMock;
        private Mock<ICustomerService> customerServiceMock;

        private Restaurant Restaurant;

        private ICollection<MenuItem> MenuItems;
        private ICollection<OrderStatus> OrderStatuses;

        private ICollection<CustomerCart> CustomerCarts;
        
        private Customer Customer;
        private Courier Courier;
        private ApplicationUser CustomerUser;

        private MenuItem Margheritta;
        private MenuItem Pepperoni;
        private MenuItem Toscana;
        private MenuItem Hawaii;

        private OrderStatus Pending;
        private OrderStatus InProgress;
        private OrderStatus OutForDelivery;
        private OrderStatus Delivered;
        private OrderStatus Canceled;

        private CustomerCart MargharittaCart;
        private CustomerCart PeperroniCart;
        private CustomerCart ToscanaCart;

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
            Courier = new Courier()
            {
                Id = 1,
                UserId = CustomerUser.Id
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
            restaurantServiceMock = new Mock<IRestaurantService>();
            customerServiceMock = new Mock<ICustomerService>();

            cartService = new CartService(repository, restaurantServiceMock.Object, customerServiceMock.Object);

            customerServiceMock
                .Setup(x => x.CustomerExistsAsync(Customer.UserId))
                .Returns(Task.FromResult(true));
            customerServiceMock
                .Setup(x => x.GetCustomerIdAsync(Customer.UserId))
                .Returns(Task.FromResult(Customer.Id));

            customerServiceMock
                .Setup(x => x.CustomerExistsAsync("abc"))
                .Returns(Task.FromResult(false));

            restaurantServiceMock
                .Setup(x => x.MenuItemExistsAsync(Margheritta.Id))
                .Returns(Task.FromResult(true));
            restaurantServiceMock
                .Setup(x => x.MenuItemExistsAsync(Hawaii.Id))
                .Returns(Task.FromResult(true));
            restaurantServiceMock
                .Setup(x => x.MenuItemExistsAsync(10))
                .Returns(Task.FromResult(false));

            await dbContext.AddAsync(Restaurant);
            await dbContext.AddAsync(CustomerUser);
            await dbContext.AddAsync(Customer);
            await dbContext.AddAsync(Courier);
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
        public async Task AddToCartAsync_Should_Return_True_When_Adding_New_Item_To_Cart()
        {
            var result = await cartService.AddToCartAsync(Hawaii.Id, Customer.UserId, 1);

            Assert.IsTrue(result);
            Assert.AreEqual(4, repository.AllReadOnly<CustomerCart>().Count());
        }

        [Test]
        public async Task AddToCartAsync_Should_Return_True_When_Adding_Existing_Item_To_Cart()
        {
            var result = await cartService.AddToCartAsync(Margheritta.Id, Customer.UserId, 1);

            Assert.IsTrue(result);
            Assert.AreEqual(2, MargharittaCart.Quantity);
        }

        [Test]
        public async Task AddToCartAsync_Should_Return_False_When_Customer_Id_Is_Not_Existing()
        {
            var result = await cartService.AddToCartAsync(Margheritta.Id, "abc", 1);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddToCartAsync_Should_Return_False_When_Menu_Item_Id_Is_Not_Existing()
        {
            var result = await cartService.AddToCartAsync(10, Customer.UserId, 1);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task MyCartAsync_Should_Return_Correct_Model()
        {
            var result = await cartService.MyCartAsync(Customer.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ICollection<CartItemViewModel>>(result);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public async Task MyCartAsync_Should_Return_Empty_Model_When_Customer_Got_No_Items()
        {
            var result = await cartService.MyCartAsync(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ICollection<CartItemViewModel>>(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task IncreaseCartQuantityAsync_Should_Return_True_And_Increase_Quantity()
        {
            bool result = await cartService.IncreaseCartQuantityAsync(Customer.Id, Margheritta.Id);

            Assert.True(result);
            Assert.AreEqual(2,MargharittaCart.Quantity);
        }

        [Test]
        public async Task IncreaseCartQuantityAsync_Should_Return_False_When_Customer_Id_Missing()
        {
            bool result = await cartService.IncreaseCartQuantityAsync(2, Margheritta.Id);

            Assert.False(result);
        }
        [Test]
        public async Task IncreaseCartQuantityAsync_Should_Return_False_When_MenuItem_Id_Missing()
        {
            bool result = await cartService.IncreaseCartQuantityAsync(Customer.Id, 10);

            Assert.False(result);
        }

        [Test]
        public async Task DecreaseCartQuantityAsync_Should_Return_True_And_Decrease_Quantity()
        {
            await cartService.IncreaseCartQuantityAsync(Customer.Id, Margheritta.Id);
            await cartService.IncreaseCartQuantityAsync(Customer.Id, Margheritta.Id);

            bool result = await cartService.DecreaseCartQuantityAsync(Customer.Id, Margheritta.Id);

            Assert.True(result);
            Assert.AreEqual(2, MargharittaCart.Quantity);
        }

        [Test]
        public async Task DecreaseCartQuantityAsync_Should_Return_False_If_Quantity_Is_One_And_Decrease_Goes_To_Zero()
        {
            bool result = await cartService.DecreaseCartQuantityAsync(Customer.Id, Margheritta.Id);

            Assert.False(result);
            Assert.AreEqual(1, MargharittaCart.Quantity);
        }

        [Test]
        public async Task DecreaseCartQuantityAsync_Should_Return_False_When_Customer_Id_Missing()
        {
            bool result = await cartService.DecreaseCartQuantityAsync(2, Margheritta.Id);

            Assert.False(result);
        }

        [Test]
        public async Task DecreaseCartQuantityAsync_Should_Return_False_When_MenuItem_Id_Missing()
        {
            bool result = await cartService.DecreaseCartQuantityAsync(Customer.Id, 10);

            Assert.False(result);
        }

        [Test]
        public async Task CalculateTotalCartSum_Should_Return_Correct_Sum()
        {
            decimal sum1 = await cartService.CalculateTotalCartSum(Customer.Id);

            Assert.IsNotNull(sum1);
            Assert.AreEqual(81.96, sum1);

            await cartService.IncreaseCartQuantityAsync(Customer.Id, Margheritta.Id);

            decimal sum2 = await cartService.CalculateTotalCartSum(Customer.Id);

            Assert.IsNotNull(sum2);
            Assert.AreEqual(91.95,sum2);
        }

        [Test]
        public async Task CalculateTotalCartSum_Should_Return_Zero_If_Customer_Cart_Is_Empty()
        {
            await cartService.DeleteFromCartAsync(Margheritta.Id, Customer.Id);
            await cartService.DeleteFromCartAsync(Pepperoni.Id, Customer.Id);
            await cartService.DeleteFromCartAsync(Toscana.Id, Customer.Id);

            decimal sum = await cartService.CalculateTotalCartSum(Customer.Id);

            Assert.IsNotNull(sum);
            Assert.AreEqual(0,sum);
        }

        [Test]
        public async Task CalculateTotalCartSum_Should_Return_Zero_If_Customer_Id_Is_Missing()
        {
            decimal sum = await cartService.CalculateTotalCartSum(2);

            Assert.IsNotNull(sum);
            Assert.AreEqual(0,sum);
        }

        [Test]
        public async Task CalculateItemCartSum_Should_Return_Correct_Sum()
        {
            decimal margharittaSum = await cartService.CalculateItemCartSum(Customer.Id, Margheritta.Id);
            decimal pepperoniSum = await cartService.CalculateItemCartSum(Customer.Id, Pepperoni.Id);

            Assert.AreEqual(9.99,margharittaSum);
            Assert.AreEqual(27, pepperoniSum);
        }

        [Test]
        public async Task CalculateItemCartSum_Should_Return_Zero_If_Customer_Id_Missing()
        {
            decimal margharittaSum = await cartService.CalculateItemCartSum(2, Margheritta.Id);
            
            Assert.AreEqual(0, margharittaSum);
        }

        [Test]
        public async Task CalculateItemCartSum_Should_Return_Zero_If_MenuItem_Id_Missing()
        {
            decimal margharittaSum = await cartService.CalculateItemCartSum(Customer.Id, 10);

            Assert.AreEqual(0, margharittaSum);
        }

        [Test]
        public async Task DeleteFromCartAsync_Should_Return_True_And_Delete()
        {
            bool result = await cartService.DeleteFromCartAsync(Margheritta.Id, Customer.Id);

            Assert.True(result);
            Assert.True(!await repository.AllReadOnly<CustomerCart>().AnyAsync(cc => cc.MenuItemId == Margheritta.Id));
            Assert.AreEqual(2,repository.AllReadOnly<CustomerCart>().Count());
        }

        [Test]
        public async Task DeleteFromCartAsync_Should_Return_False_If_Customer_Id_Missing()
        {
            bool result = await cartService.DeleteFromCartAsync(Margheritta.Id, 2);

            Assert.False(result);
            Assert.AreEqual(3, repository.AllReadOnly<CustomerCart>().Count());
        }

        [Test]
        public async Task DeleteFromCartAsync_Should_Return_False_If_MenuItem_Id_Missing()
        {
            bool result = await cartService.DeleteFromCartAsync(10, Customer.Id);

            Assert.False(result);
            Assert.AreEqual(3, repository.AllReadOnly<CustomerCart>().Count());
        }
    }
}