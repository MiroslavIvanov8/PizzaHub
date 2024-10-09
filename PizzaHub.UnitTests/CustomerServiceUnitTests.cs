using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Services;
using PizzaHub.Infrastructure.Constants;
using ApplicationUser = PizzaHub.Infrastructure.Data.Models.ApplicationUser;
using MenuItem = PizzaHub.Infrastructure.Data.Models.MenuItem;
using Order = PizzaHub.Infrastructure.Data.Models.Order;
using OrderStatus = PizzaHub.Infrastructure.Data.Models.OrderStatus;
using Restaurant = PizzaHub.Infrastructure.Data.Models.Restaurant;
using static PizzaHub.Infrastructure.Constants.DataConstants;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.UnitTests
{
    [TestFixture]
    public class CustomerServiceUnitTests
    {
        private PizzaHubDbContext dbContext;

        private IRepository repository;

        private ICustomerService customerService;
        
        private Restaurant Restaurant;

        private ICollection<MenuItem> MenuItems;
        private ICollection<Order> Orders;
        private ICollection<OrderStatus> OrderStatuses;

        private Customer Customer;
        private ApplicationUser ApplicationUser;

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
            ApplicationUser = new ApplicationUser
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
                UserId = ApplicationUser.Id,
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
                CourierId = 1,
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
                CourierId = 1,
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
                CourierId = 1,
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
                CourierId = 1,
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
                CourierId = 1,
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
            customerService = new CustomerService(repository);

            await dbContext.AddAsync(Restaurant);
            await dbContext.AddAsync(ApplicationUser);
            await dbContext.AddAsync(Customer);
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
        public async Task Get_Customer_Id_Async_Should_Return_Correct_Id()
        {
            int id = await this.customerService.GetCustomerIdAsync(ApplicationUser.Id);

            Assert.AreEqual(Customer.Id, id);
        }

        [Test]
        public async Task Get_Customer_Id_Async_Should_Return_Zero_If_Customer_Does_Not_Exist()
        {
            int id = await this.customerService.GetCustomerIdAsync(Guid.NewGuid().ToString());

            Assert.AreEqual(0, id);
            Assert.IsNotNull(id);
        }

        [Test]
        public async Task Customer_Exists_Async_Should_Return_True()
        {
            bool result = await this.customerService.CustomerExistsAsync(ApplicationUser.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task Customer_Exists_Async_Should_Return_False()
        {
            bool result = await this.customerService.CustomerExistsAsync(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task Show_Past_Orders_Async_Should_Return_Correct()
        {
            var orders = await this.customerService.ShowPastOrdersAsync(Customer.Id);

            foreach (var order in orders)
            {
                if (order.Status == "Delivered")
                {
                    Assert.AreEqual(order.Id, DeliveredOrder.Id);
                    Assert.AreEqual(order.Amount,DeliveredOrder.TotalAmount);
                    Assert.AreEqual(order.Restaurant, DeliveredOrder.Restaurant.Name);
                    Assert.AreEqual(order.CreatedOn, DeliveredOrder.CreatedOn.ToString(DateFormat));
                    Assert.AreEqual(order.Status, DeliveredOrder.OrderStatus.Name);
                }

                if (order.Status == "Cancelled")
                {
                    Assert.AreEqual(order.Id, CanceledOrder.Id);
                    Assert.AreEqual(order.Amount, CanceledOrder.TotalAmount);
                    Assert.AreEqual(order.Restaurant, CanceledOrder.Restaurant.Name);
                    Assert.AreEqual(order.CreatedOn, CanceledOrder.CreatedOn.ToString(DateFormat));
                    Assert.AreEqual(order.Status, CanceledOrder.OrderStatus.Name);
                }
            }
            
            Assert.AreEqual(2,orders.Count());
        }

        [Test]
        public async Task ShowPastOrdersAsync_Should_Return_OrderViewModel_With_Correct_OrderItems()
        {
            var orders = new List<Order>
            {
                DeliveredOrder, CanceledOrder
            };
            
            var orderViewModels = await customerService.ShowPastOrdersAsync(Customer.Id);

            foreach (var orderViewModel in orderViewModels)
            {
                if (orderViewModel.Status == "Delivered")
                {
                    Assert.AreEqual(DeliveredOrder.Items.Count, orderViewModel.OrderItems.Count());

                   foreach (var orderItemViewModel in orderViewModel.OrderItems)
                    {
                        var correspondingOrderItem = DeliveredOrder.Items.FirstOrDefault(oi => oi.MenuItem.Name == orderItemViewModel.Name);
                        Assert.IsNotNull(correspondingOrderItem);
                        Assert.AreEqual(correspondingOrderItem.Quantity, orderItemViewModel.Quantity);
                    }
                }

                if (orderViewModel.Status == "Cancelled")
                {
                    var canceledOrder = orders.FirstOrDefault(o => o.OrderStatusId == (int)OrderStatusEnum.Canceled);
                    Assert.IsNotNull(canceledOrder);

                    Assert.AreEqual(canceledOrder.Items.Count, orderViewModel.OrderItems.Count());

                    foreach (var orderItemViewModel in orderViewModel.OrderItems)
                    {
                        var correspondingOrderItem = canceledOrder.Items.FirstOrDefault(oi => oi.MenuItem.Name == orderItemViewModel.Name);
                        Assert.IsNotNull(correspondingOrderItem);
                        Assert.AreEqual(correspondingOrderItem.Quantity, orderItemViewModel.Quantity);
                    }
                }
            }
        }

        [Test]
        public async Task ShowPastOrdersAsync_Should_Return_Orders_In_Correct_Descending_Order_By_CreatedOn()
        {
            var orders = new List<Order>
            {
                DeliveredOrder, CanceledOrder
            };

            var orderViewModels = await customerService.ShowPastOrdersAsync(Customer.Id);

            //TODO FIX this test as well. TryParse needed
            var orderedByCreatedOn = orderViewModels.OrderByDescending(o => DateTime.ParseExact(o.CreatedOn, DateFormat, CultureInfo.InvariantCulture)).ToList();
            for (int i = 0; i < orderedByCreatedOn.Count; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual(CanceledOrder.Id, orderedByCreatedOn[i].Id);
                }

                if (i == 1)
                {
                    Assert.AreEqual(DeliveredOrder.Id, orderedByCreatedOn[i].Id);
                }
            }

            Assert.AreEqual(orders.Count, orderViewModels.Count());
        }

        [Test]
        public async Task Show_Ongoing_Orders_Async_Should_Return_Correct()
        {
            var orders = await this.customerService.ShowOngoingOrdersAsync(Customer.Id);

            foreach (var order in orders)
            {
                if (order.Status == "Pending")
                {
                    Assert.AreEqual(order.Id, PendingOrder.Id);
                    Assert.AreEqual(order.Amount, PendingOrder.TotalAmount);
                    Assert.AreEqual(order.Restaurant, PendingOrder.Restaurant.Name);
                    Assert.AreEqual(order.CreatedOn, PendingOrder.CreatedOn.ToString(DateFormat));
                    Assert.AreEqual(order.Status, PendingOrder.OrderStatus.Name);
                }

                if (order.Status == "In Progress")
                {
                    Assert.AreEqual(order.Id, InProgressOrder.Id);
                    Assert.AreEqual(order.Amount, InProgressOrder.TotalAmount);
                    Assert.AreEqual(order.Restaurant, InProgressOrder.Restaurant.Name);
                    Assert.AreEqual(order.CreatedOn, InProgressOrder.CreatedOn.ToString(DateFormat));
                    Assert.AreEqual(order.Status, InProgressOrder.OrderStatus.Name);
                }
                if (order.Status == "Out for Delivery")
                {
                    Assert.AreEqual(order.Id, OutForDeliveryOrder.Id);
                    Assert.AreEqual(order.Amount, OutForDeliveryOrder.TotalAmount);
                    Assert.AreEqual(order.Restaurant, OutForDeliveryOrder.Restaurant.Name);
                    Assert.AreEqual(order.CreatedOn, OutForDeliveryOrder.CreatedOn.ToString(DateFormat));
                    Assert.AreEqual(order.Status, OutForDeliveryOrder.OrderStatus.Name);
                }
            }

            Assert.AreEqual(3, orders.Count());
        }

        [Test]
        public async Task ShowOngoingOrdersAsync_Should_Return_OrderViewModel_With_Correct_OrderItems()
        {
            var orders = new List<Order>
            {
                PendingOrder, InProgressOrder, OutForDeliveryOrder
            };

            var orderViewModels = await customerService.ShowOngoingOrdersAsync(Customer.Id);

            foreach (var orderViewModel in orderViewModels)
            {
                Assert.IsTrue(orderViewModel.Status != "Delivered" && orderViewModel.Status != "Cancelled");

                var correspondingOrder = orders.FirstOrDefault(o => o.Id == orderViewModel.Id);
                Assert.IsNotNull(correspondingOrder);

                Assert.AreEqual(correspondingOrder.Items.Count, orderViewModel.OrderItems.Count());

                foreach (var orderItemViewModel in orderViewModel.OrderItems)
                {
                    var correspondingOrderItem = correspondingOrder.Items.FirstOrDefault(oi => oi.MenuItem.Name == orderItemViewModel.Name);
                    Assert.IsNotNull(correspondingOrderItem);
                    Assert.AreEqual(correspondingOrderItem.Quantity, orderItemViewModel.Quantity);
                }
            }
        }

        [Test]
        public async Task ShowOngoingOrdersAsync_Should_Return_Orders_In_Correct_Descending_Order_By_CreatedOn()
        {
            var orders = new List<Order>
            {
                PendingOrder, InProgressOrder, OutForDeliveryOrder
            };

            var orderViewModels = await customerService.ShowOngoingOrdersAsync(Customer.Id);

            //TODO pipeline error when testing, FIX
            var orderedByCreatedOn = orderViewModels.OrderByDescending(o => DateTime.ParseExact(o.CreatedOn, DateFormat, CultureInfo.InvariantCulture)).ToList();
            for (int i = 0; i < orderedByCreatedOn.Count; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual(OutForDeliveryOrder.Id, orderedByCreatedOn[i].Id);
                }

                if (i == 1)
                {
                    Assert.AreEqual(InProgressOrder.Id, orderedByCreatedOn[i].Id);
                }
                if (i == 2)
                {
                    Assert.AreEqual(PendingOrder.Id, orderedByCreatedOn[i].Id);
                }
            }

            Assert.AreEqual(orders.Count, orderViewModels.Count());
        }
    }
}