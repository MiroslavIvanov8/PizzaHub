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
using static PizzaHub.Infrastructure.Constants.DataConstants;
using PizzaHub.Infrastructure.Enums;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Areas.Admin.Models.Order;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class CourierServiceUnitTests
    {
        private PizzaHubDbContext dbContext;

        private IRepository repository;

        private ICourierService courierService;
        private IOrderService orderService;
        private ISendGridEmailSender emailSender;

        private Restaurant Restaurant;

        private ICollection<MenuItem> MenuItems;
        private ICollection<Order> Orders;
        private ICollection<OrderStatus> OrderStatuses;

        private ApplicationUser GuestUser;

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

        private Order PendingOrder;
        private Order InProgressOrder;
        private Order OutForDeliveryOrder;
        private Order DeliveredOrder;
        private Order CanceledOrder;

        [SetUp]
        public async Task Setup()
        {
            Restaurant = new Restaurant()
            {
                Id = 1,
                Name = "PizzaHub"
            };

            GuestUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Vankata",
                LastName = "Ivanov",
                BirthDate = DateTime.ParseExact("01.10.2010", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Email = "starskriim@abv.bg",
                PasswordHash = "123123123123123"
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

            PendingOrder = new Order()
            {
                Id = 1,
                CustomerId = 1,
                Customer = Customer,
                RestaurantId = 1,
                PaymentMethodId = 1,
                Address = "123 Main St",
                TotalAmount = 25.00M,
                CreatedOn = DateTime.UtcNow + TimeSpan.FromMinutes(1),
                OrderStatusId = 4,
                DeliveredOn = DateTime.UtcNow.AddHours(1),
                OrderStatus = Pending,
                Items = new List<OrderItem>
            {
                new OrderItem() { Id = 1, OrderId = 1, MenuItem = Margheritta, Quantity = 1},
                new OrderItem() { Id = 2, OrderId = 1, MenuItem = Pepperoni, Quantity = 1},
                new OrderItem() { Id = 3, OrderId = 1, MenuItem = Toscana, Quantity = 1}
            }};
            InProgressOrder = new Order()
            {
                Id = 2,
                CustomerId = 1,
                Customer = Customer,
                RestaurantId = 1,
                PaymentMethodId = 1,
                Address = "123 Main St",
                TotalAmount = 25.00M,
                CreatedOn = DateTime.UtcNow + TimeSpan.FromMinutes(2),
                OrderStatusId = 4,
                DeliveredOn = DateTime.UtcNow.AddHours(1),
                OrderStatus = InProgress,
                Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 4, OrderId = 2, MenuItem = Margheritta, Quantity = 2},
                    new OrderItem() { Id = 5, OrderId = 2, MenuItem = Pepperoni, Quantity = 2},
                    new OrderItem() { Id = 6, OrderId = 2, MenuItem = Toscana, Quantity = 2}
                }
            };
            OutForDeliveryOrder = new Order()
            {
                Id = 3,
                CustomerId = 1,
                Customer = Customer,
                RestaurantId = 1,
                PaymentMethodId = 1,
                Address = "123 Main St",
                TotalAmount = 25.00M,
                CreatedOn = DateTime.UtcNow + TimeSpan.FromMinutes(3),
                OrderStatusId = 4,
                DeliveredOn = DateTime.UtcNow.AddHours(1),
                OrderStatus = OutForDelivery,
                Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 7, OrderId = 3, MenuItem = Margheritta, Quantity = 3},
                    new OrderItem() { Id = 8, OrderId = 3, MenuItem = Pepperoni, Quantity = 3},
                    new OrderItem() { Id = 9, OrderId = 3, MenuItem = Toscana, Quantity = 3}
                }
            };
            DeliveredOrder = new Order()
            {
                Id = 4,
                CustomerId = 1,
                Customer = Customer,
                RestaurantId = 1,
                PaymentMethodId = 1,
                Address = "123 Main St",
                TotalAmount = 25.00M,
                CreatedOn = DateTime.UtcNow + TimeSpan.FromMinutes(4),
                OrderStatusId = 4,
                DeliveredOn = DateTime.UtcNow.AddHours(1),
                OrderStatus = Delivered,
                Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 10, OrderId = 4, MenuItem = Margheritta, Quantity = 4},
                    new OrderItem() { Id = 11, OrderId = 4, MenuItem = Pepperoni, Quantity = 4},
                    new OrderItem() { Id = 12, OrderId = 4, MenuItem = Toscana, Quantity = 4}
                }
            };
            CanceledOrder = new Order()
            {
                Id = 5,
                CustomerId = 1,
                Customer = Customer,
                RestaurantId = 1,
                PaymentMethodId = 1,
                Address = "123 Main St",
                TotalAmount = 25.00M,
                CreatedOn = DateTime.UtcNow + TimeSpan.FromMinutes(5),
                OrderStatusId = 4,
                DeliveredOn = DateTime.UtcNow.AddHours(1),
                OrderStatus = Canceled,
                Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 13, OrderId = 5, MenuItem = Margheritta, Quantity = 5},
                    new OrderItem() { Id = 14, OrderId = 5, MenuItem = Pepperoni, Quantity = 5},
                    new OrderItem() { Id = 15, OrderId = 5, MenuItem = Toscana, Quantity = 5}
                }
            };
            Orders = new List<Order>()
            {
                PendingOrder, InProgressOrder, OutForDeliveryOrder, DeliveredOrder, CanceledOrder
            };

            var options = new DbContextOptionsBuilder<PizzaHubDbContext>()
                .UseInMemoryDatabase(databaseName: "PizzaHub" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new PizzaHubDbContext(options);
            repository = new Repository(dbContext);

            emailSender = new SendGridEmailSender("apikey");
            orderService = new OrderService(repository);
            courierService = new CourierService(repository,orderService, emailSender);

            await dbContext.AddAsync(Restaurant);
            await dbContext.AddAsync(CustomerUser);
            await dbContext.AddAsync(GuestUser);
            await dbContext.AddAsync(Customer);
            await dbContext.AddAsync(Courier);
            await dbContext.AddRangeAsync(OrderStatuses);
            await dbContext.AddRangeAsync(MenuItems);
            await dbContext.AddRangeAsync(Orders);
            await dbContext.SaveChangesAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task IsApplicantInLegalAge_Should_Return_True()
        {
            bool result = await courierService.IsApplicantInLegalAge(CustomerUser.Id);

            Assert.True(result);
        }

        [Test]
        public async Task IsApplicantInLegalAge_Should_Return_False_When_User_Is_UnderAge()
        {
            bool result = await courierService.IsApplicantInLegalAge(GuestUser.Id);

            Assert.False(result);
        }

        [Test]
        public async Task IsApplicantInLegalAge_Should_Return_False_When_User_Is_Missing()
        {
            bool result = await courierService.IsApplicantInLegalAge(Guid.NewGuid().ToString());

            Assert.False(result);
        }

        [Test]
        public async Task CreateApplicationRequestAsync_Should_Return_True()
        {
            bool result =
                await courierService.CreateApplicationRequestAsync(CustomerUser.Id, "+0894669073", "Blah blah blah");

            Assert.True(result);
            Assert.AreEqual(1,repository.AllReadOnly<CourierApplicationRequest>().Count());
        }

        [Test]
        public async Task CreateApplicationRequestAsync_Should_Return_False_When_User_Already_Has_A_Request()
        {
            await courierService.CreateApplicationRequestAsync(CustomerUser.Id, "+0894669073", "Blah blah blah");

            bool result =
                await courierService.CreateApplicationRequestAsync(CustomerUser.Id, "+0894669073", "Blah blah blah");

            Assert.False(result);
        }

        [Test]
        public async Task CreateApplicationRequestAsync_Should_Return_False_When_User_Is_Not_In_Legal_Age()
        {
            bool result =
                await courierService.CreateApplicationRequestAsync(GuestUser.Id, "+0894669073", "Blah blah blah");

            Assert.False(result);
        }
        
        [TestCase("12334")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task CreateApplicationRequestAsync_Should_Return_False_When_PhoneNumber_Is_Empty(string phoneNumber)
        {
            bool result1 =
                await courierService.CreateApplicationRequestAsync(CustomerUser.Id, phoneNumber, "Blah blah blah");
            
            Assert.False(result1);
        }

        [Test]
        public async Task PickOrderAsync_Should_Return_True()
        {
            bool result = await courierService.PickOrderAsync(InProgressOrder.Id, 1);

            Assert.True(result);
            Assert.AreEqual(1, InProgressOrder.CourierId);
            Assert.AreEqual(3, InProgressOrder.OrderStatusId);
        }

        [Test]
        public async Task PickOrderAsync_Should_Return_False_When_Order_Status_IsNot_InProgress()
        {
            bool result1 = await courierService.PickOrderAsync(PendingOrder.Id, 1);
            bool result2 = await courierService.PickOrderAsync(OutForDeliveryOrder.Id, 1);

            Assert.False(result1);
            Assert.False(result2);
        }

        [Test]
        public async Task PickOrderAsync_Should_Return_False_When_Order_Is_Missing()
        {
            bool result = await courierService.PickOrderAsync(10, 1);

            Assert.False(result);
        }

        [Test]
        public async Task MarkOrderDelivered_Should_Return_True()
        {
            bool result = await courierService.MarkOrderDelivered(OutForDeliveryOrder.Id);

            Assert.True(result);
            Assert.AreEqual(4, OutForDeliveryOrder.OrderStatusId);
        }

        [Test]
        public async Task MarkOrderDelivered_Should_Return_False_When_Order_Status_IsNot_OutForDelivery()
        {
            bool result1 = await courierService.MarkOrderDelivered(PendingOrder.Id);
            bool result2 = await courierService.MarkOrderDelivered(InProgressOrder.Id);

            Assert.False(result1);
            Assert.False(result2);
        }

        [Test]
        public async Task MarkOrderDelivered_Should_Return_False_When_Order_Is_Missing()
        {
            bool result = await courierService.MarkOrderDelivered(10);

            Assert.False(result);
        }

        [Test]
        public async Task GetCourierId_Should_Return_Correct_Id()
        {
            int result = await courierService.GetCourierId(CustomerUser.Id);

            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetCourierId_Should_Return_Zero_If_Incorrect_UserId()
        {
            int result = await courierService.GetCourierId(Guid.NewGuid().ToString());

            Assert.AreEqual(0, result);
        }

        [Test]
        public async Task ShowPickedOrdersAsync_Should_Return_Expected_Model()
        {
            PendingOrder.OrderStatusId = 2;

            await courierService.PickOrderAsync(PendingOrder.Id, 1);
            await courierService.PickOrderAsync(InProgressOrder.Id, 1);
            var result = await courierService.ShowPickedOrdersAsync(1);

            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<DetailedOrderViewModel>>(result);
            Assert.AreEqual(2, result.Count());

            foreach (var order in result)
            {
                Assert.AreEqual("Out for Delivery", order.Status);
            }
        }


        [Test]
        public async Task ShowPickedOrdersAsync_Should_Return_Empty_Model()
        {
            var result = await courierService.ShowPickedOrdersAsync(1);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
            Assert.IsInstanceOf<IEnumerable<DetailedOrderViewModel>>(result);
            Assert.AreEqual(0, result.Count());

        }

        [Test]
        public async Task ShowTodayDelivered_Should_Return_Expected_Model()
        {
            OutForDeliveryOrder.CourierId = 1;

            await this.courierService.PickOrderAsync(InProgressOrder.Id, 1);

            await courierService.MarkOrderDelivered(InProgressOrder.Id);
            await courierService.MarkOrderDelivered(OutForDeliveryOrder.Id);

            var result = await courierService.ShowTodayDelivered(1);

            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ShowOrderViewModel>>(result);
            Assert.AreEqual(2, result.Count());

            foreach (var order in result)
            {
                Assert.AreEqual("Delivered", order.Status);
            }
        }

        [Test]
        public async Task ShowTodayDelivered_Should_Return_Models_From_Today()
        {
            OutForDeliveryOrder.CourierId = 1;

            await this.courierService.PickOrderAsync(InProgressOrder.Id, 1);

            await courierService.MarkOrderDelivered(InProgressOrder.Id);
            await courierService.MarkOrderDelivered(OutForDeliveryOrder.Id);

            InProgressOrder.DeliveredOn = DateTime.UtcNow  + TimeSpan.FromDays(3);
            OutForDeliveryOrder.DeliveredOn = DateTime.UtcNow + TimeSpan.FromDays(3);
            await repository.SaveChangesAsync();

            var result = await courierService.ShowTodayDelivered(1);

            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ShowOrderViewModel>>(result);
            Assert.AreEqual(0, result.Count());
            
        }

        [Test]
        public async Task ShowTodayDelivered_Should_Return_Empty_Model_When_Wrong_CourierId()
        {
            OutForDeliveryOrder.CourierId = 1;

            await this.courierService.PickOrderAsync(InProgressOrder.Id, 1);

            await courierService.MarkOrderDelivered(InProgressOrder.Id);
            await courierService.MarkOrderDelivered(OutForDeliveryOrder.Id);

            await repository.SaveChangesAsync();

            var result = await courierService.ShowTodayDelivered(10);

            Assert.NotNull(result);
            Assert.IsEmpty(result);
            Assert.IsInstanceOf<IEnumerable<ShowOrderViewModel>>(result);
            Assert.AreEqual(0, result.Count());

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task ShowInProgressOrdersAsync_Should_Return_Correct_Model(int currentPage)
        {
            int ordersPerPage = 2;

            PendingOrder.OrderStatusId = 2;
            OutForDeliveryOrder.OrderStatusId = 2;
            DeliveredOrder.OrderStatusId = 2;
            CanceledOrder.OrderStatusId = 2;
            await repository.SaveChangesAsync();

            var result = await courierService.ShowInProgressOrdersAsync(currentPage, ordersPerPage);

            Assert.NotNull(result);
            Assert.IsInstanceOf<OrderQueryServiceModel> (result);
            Assert.IsInstanceOf<IEnumerable<DetailedOrderViewModel>>(result.Orders);
            
            if (currentPage == 3)
            {
                Assert.AreEqual(1,result.Orders.Count());
            }
            else
            {
                Assert.AreEqual(2, result.Orders.Count());
                Assert.AreEqual(5, result.OrdersCount);

            }
        }
        [TestCase(1)]
        public async Task ShowInProgressOrdersAsync_Should_Return_Empty_Model(int currentPage)
        {
            int ordersPerPage = 2;

            InProgressOrder.OrderStatusId = 1;
            await repository.SaveChangesAsync();

            var result = await courierService.ShowInProgressOrdersAsync(currentPage, ordersPerPage);

            Assert.NotNull(result);
            Assert.IsInstanceOf<OrderQueryServiceModel>(result);
            Assert.IsInstanceOf<IEnumerable<DetailedOrderViewModel>>(result.Orders);
            Assert.AreEqual(0, result.Orders.Count());
            Assert.AreEqual(0, result.OrdersCount);
            
        }
    }
}