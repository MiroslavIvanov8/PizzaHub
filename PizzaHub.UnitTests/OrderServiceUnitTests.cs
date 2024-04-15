using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Services;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Constants;
using static PizzaHub.Infrastructure.Constants.DataConstants;
using MenuItem = PizzaHub.Infrastructure.Data.Models.MenuItem;
using Order = PizzaHub.Infrastructure.Data.Models.Order;
using OrderStatus = PizzaHub.Infrastructure.Data.Models.OrderStatus;
using Restaurant = PizzaHub.Infrastructure.Data.Models.Restaurant;
using PizzaHub.Core.Contracts;
using ApplicationUser = PizzaHub.Infrastructure.Data.Models.ApplicationUser;
using System.Globalization;

namespace PizzaHub.UnitTests;

[TestFixture]
public class OrderServiceUnitTests
{
    private PizzaHubDbContext dbContext;

    private IRepository repository;

    private IOrderService orderService;

    private Restaurant Restaurant;

    private ICollection<MenuItem> MenuItems;
    private ICollection<Order> Orders;
    private ICollection<OrderStatus> OrderStatuses;
    private ICollection<CustomerCart> CustomerCarts;

    private Customer Customer;
    private Customer CustomerEmptyCart;
    private ApplicationUser ApplicationUserCustomer;
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

    private CustomerCart CartMargherita;
    private CustomerCart CartPepperoni;

    [SetUp]
    public async Task Setup()
    {
        Restaurant = new Restaurant()
        {
            Id = 1,
            Name = "PizzaHub"
        };
        ApplicationUserCustomer = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Miroslav",
            LastName = "Ivanov",
            BirthDate = DateTime.ParseExact("01.10.1998", "dd.MM.yyyy", CultureInfo.InvariantCulture),
            Email = "starskriim@abv.bg",
            PasswordHash = "123123123123123"
        };
        ApplicationUser = new ApplicationUser()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Test",
            LastName = "Testov",
            BirthDate = DateTime.ParseExact("01.10.1998", "dd.MM.yyyy", CultureInfo.InvariantCulture),
            Email = "star@abv.bg",
            PasswordHash = "123123123123123"
        };
        Customer = new Customer()
        {
            Id = 1,
            UserId = ApplicationUserCustomer.Id,
        };
        CustomerEmptyCart = new Customer()
        {
            Id = 2,
            UserId = ApplicationUser.Id
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
            CreatedOn = DateTime.UtcNow,
            OrderStatusId = 4,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            OrderStatus = Pending,
            Items = new List<OrderItem>
            {
                new OrderItem() { Id = 1, OrderId = 1, MenuItem = Margheritta, Quantity = 3},
                new OrderItem() { Id = 2, OrderId = 1, MenuItem = Pepperoni, Quantity = 2},
                new OrderItem() { Id = 3, OrderId = 1, MenuItem = Toscana, Quantity = 1}
            }
        };
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
            CreatedOn = DateTime.UtcNow,
            OrderStatusId = 4,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            OrderStatus = InProgress,
            Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 4, OrderId = 2, MenuItem = Margheritta, Quantity = 3},
                    new OrderItem() { Id = 5, OrderId = 2, MenuItem = Pepperoni, Quantity = 2,},
                    new OrderItem() { Id = 6, OrderId = 2, MenuItem = Toscana, Quantity = 1}
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
            CreatedOn = DateTime.UtcNow,
            OrderStatusId = 4,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            OrderStatus = OutForDelivery,
            Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 7, OrderId = 3, MenuItem = Margheritta, Quantity = 3},
                    new OrderItem() { Id = 8, OrderId = 3, MenuItem = Pepperoni, Quantity = 2},
                    new OrderItem() { Id = 9, OrderId = 3, MenuItem = Toscana, Quantity = 1}
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
            CreatedOn = DateTime.UtcNow,
            OrderStatusId = 4,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            OrderStatus = Delivered,
            Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 10, OrderId = 4, MenuItem = Margheritta, Quantity = 3},
                    new OrderItem() { Id = 11, OrderId = 4, MenuItem = Pepperoni, Quantity = 2},
                    new OrderItem() { Id = 12, OrderId = 4, MenuItem = Toscana, Quantity = 1}
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
            CreatedOn = DateTime.UtcNow,
            OrderStatusId = 4,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            OrderStatus = Canceled,
            Items = new List<OrderItem>
                {
                    new OrderItem() { Id = 13, OrderId = 5, MenuItem = Margheritta, Quantity = 3},
                    new OrderItem() { Id = 14, OrderId = 5, MenuItem = Pepperoni, Quantity = 2},
                    new OrderItem() { Id = 15, OrderId = 5, MenuItem = Toscana, Quantity = 1}
                }
        };
        Orders = new List<Order>()
            {
                PendingOrder, InProgressOrder, OutForDeliveryOrder, DeliveredOrder, CanceledOrder
            };

        CartMargherita = new CustomerCart()
        {
            CustomerId = Customer.Id,
            MenuItemId = Margheritta.Id,
            Quantity = 2
        };
        CartPepperoni = new CustomerCart()
        {
            CustomerId = Customer.Id,
            MenuItemId = Pepperoni.Id,
            Quantity = 2
        };
        CustomerCarts = new List<CustomerCart>()
        {
            CartMargherita, CartPepperoni
        };

        var options = new DbContextOptionsBuilder<PizzaHubDbContext>()
            .UseInMemoryDatabase(databaseName: "PizzaHub" + Guid.NewGuid().ToString())
            .Options;

        dbContext = new PizzaHubDbContext(options);
        repository = new Repository(dbContext);
        orderService = new OrderService(repository);

        await dbContext.AddAsync(Restaurant);
        await dbContext.AddAsync(ApplicationUserCustomer);
        await dbContext.AddAsync(Customer);
        await dbContext.AddAsync(ApplicationUser);
        await dbContext.AddAsync(CustomerEmptyCart);
        await dbContext.AddRangeAsync(OrderStatuses);
        await dbContext.AddRangeAsync(MenuItems);
        await dbContext.AddRangeAsync(Orders);
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
    public async Task GetOrderAsync_Should_Return_Correct_Order()
    {
        Order retrievedOrder = await orderService.GetOrderAsync(1);

        Assert.IsNotNull(retrievedOrder);
        Assert.AreEqual(PendingOrder.Id, retrievedOrder.Id);
        Assert.AreEqual(PendingOrder.CustomerId, retrievedOrder.CustomerId);
        Assert.AreEqual(PendingOrder.CourierId, retrievedOrder.CourierId);
        Assert.AreEqual(PendingOrder.RestaurantId, retrievedOrder.RestaurantId);
        Assert.AreEqual(PendingOrder.Address, retrievedOrder.Address);
        Assert.AreEqual(PendingOrder.PaymentMethodId, retrievedOrder.PaymentMethodId);
        Assert.AreEqual(PendingOrder.OrderStatusId, retrievedOrder.OrderStatusId);
        Assert.AreEqual(PendingOrder.CreatedOn, retrievedOrder.CreatedOn);
        Assert.AreEqual(PendingOrder.DeliveredOn, retrievedOrder.DeliveredOn);
        Assert.AreEqual(PendingOrder.TotalAmount, retrievedOrder.TotalAmount);
    }

    [TestCase(10)]
    public async Task GetOrderAsync_Should_Return_Correct_Null(int orderId)
    {
        Order retrievedOrder = await orderService.GetOrderAsync(orderId);

        Assert.IsNull(retrievedOrder);
    }

    [Test]
    public async Task GetDetailedOrderViewModelAsync_Should_Return_Null_When_Id_Not_Found()
    {
        int nonExistentId = 1000;

        DetailedOrderViewModel? order = await orderService.GetDetailedOrderViewModelAsync(nonExistentId);

        Assert.IsNull(order);
    }

    [Test]
    public async Task GetStatusNamesAsync_Should_Return_Status_Names()
    {
        IEnumerable<string> statusNames = await orderService.GetStatusNamesAsync();

        Assert.IsNotNull(statusNames);
        Assert.AreEqual(OrderStatuses.Count, statusNames.Count());

        foreach (var statusName in OrderStatuses.Select(s => s.Name))
        {
            Assert.Contains(statusName, (System.Collections.ICollection?)statusNames);
        }
    }

    [Test]
    public async Task GetOrderItemNamesAsync_Should_Return_OrderItem_Names()
    {
        IEnumerable<string> itemNames = await orderService.GetOrderItemNamesAsync(PendingOrder.Id);

        Assert.IsNotNull(itemNames);
        Assert.AreEqual(PendingOrder.Items.Count, itemNames.Count());

        Assert.IsTrue(PendingOrder.Items.All(orderItem => itemNames.Contains(orderItem.MenuItem.Name)));
    }

    [TestCase(-1)]
    [TestCase(10)]
    public async Task GetOrderItemNamesAsync_InvalidOrderId_Should_Return_EmptyList(int invalidOrderId)
    {
        IEnumerable<string> itemNames = await orderService.GetOrderItemNamesAsync(invalidOrderId);

        Assert.IsNotNull(itemNames);
        Assert.IsEmpty(itemNames);
    }

    [Test]
    public async Task GetOrderMenuItemWithQuantityViewmodelAsync_Should_Return_OrderItems_With_Quantity()
    {
        IEnumerable<OrderMenuItemWithQuantityViewModel> result = await orderService.GetOrderMenuItemWithQuantityViewmodelAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(PendingOrder.Items.Count, result.Count());

        foreach (var orderItem in result)
        {
            bool itemExists = PendingOrder.Items.Any(x => x.OrderId == orderItem.Id && x.MenuItem.Name == orderItem.Name && x.Quantity == orderItem.Quantity);
            Assert.IsTrue(itemExists);
        }
    }

    [Test]
    public async Task GetOrderMenuItemWithQuantityViewmodelAsync_Should_Return_OrderItems_With_Correct_Quantity()
    {
        IEnumerable<OrderMenuItemWithQuantityViewModel> result = await orderService.GetOrderMenuItemWithQuantityViewmodelAsync(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(PendingOrder.Items.Count, result.Count());

        foreach (var orderItem in result)
        {
            var matchingItem = PendingOrder.Items.FirstOrDefault(x => x.OrderId == orderItem.Id && x.MenuItem.Name == orderItem.Name);
            Assert.IsNotNull(matchingItem);

            Assert.AreEqual(matchingItem.Quantity, orderItem.Quantity);
        }
    }

    [Test]
    public async Task GetDetailedOrderViewModelAsync_Should_Return_DetailedOrderViewModel_When_Id_Found()
    {
        // Act
        DetailedOrderViewModel? retrievedOrder = await orderService.GetDetailedOrderViewModelAsync(1);

        // Assert
        Assert.IsNotNull(retrievedOrder);
        Assert.AreEqual(PendingOrder.Id, retrievedOrder.Id);
        Assert.AreEqual(PendingOrder.Restaurant.Name, retrievedOrder.Restaurant);
        Assert.AreEqual(PendingOrder.Address, retrievedOrder.Address);
        Assert.AreEqual(PendingOrder.TotalAmount, retrievedOrder.Amount);
        Assert.AreEqual(PendingOrder.CreatedOn.ToString(DataConstants.DateFormat), retrievedOrder.CreatedOn);
        Assert.AreEqual($"{PendingOrder.Customer.User.FirstName} {PendingOrder.Customer.User.LastName}", retrievedOrder.Customer);
        Assert.AreEqual(PendingOrder.Items.Count, retrievedOrder.OrderItems.Count());
        Assert.AreEqual(PendingOrder.OrderStatus.Name, retrievedOrder.Status);
    }

    [Test]
    public async Task CancelOrder_Should_Return_True()
    {
        bool result = await this.orderService.CancelOrder(PendingOrder.Id, Customer.Id);

        Assert.IsTrue(result);
    }

    [Test]
    public async Task CancelOrder_Should_Return_False_With_Wrong_CustomerId()
    {
        bool result = await this.orderService.CancelOrder(PendingOrder.Id, 100);

        Assert.IsFalse(result);
    }

    [Test]
    public async Task CancelOrder_Should_Return_False_With_Wrong_OrderId()
    {
        bool result = await this.orderService.CancelOrder(100, Customer.Id);

        Assert.IsFalse(result);
    }

    [Test]
    public async Task CancelOrder_Should_Return_False()
    {
        bool result = await this.orderService.CancelOrder(100, 100);

        Assert.IsFalse(result);
    }

    [Test]
    public async Task GetAllDetailedOrdersViewModelAsync_Should_Return_Correct_Number_Of_ViewModels()
    {
        var orders = new List<Order>
        {
            DeliveredOrder, CanceledOrder
        };

        var detailedOrderViewModels = await orderService.GetAllDetailedOrdersViewModelAsync(orders);

        Assert.AreEqual(orders.Count, detailedOrderViewModels.Count());
    }

    [Test]
    public async Task GetAllDetailedOrdersViewModelAsync_Should_Return_Correct_OrderViewModel_Properties()
    {
        var orders = new List<Order>
        {
            DeliveredOrder, CanceledOrder
        };

        var detailedOrderViewModels = await orderService.GetAllDetailedOrdersViewModelAsync(orders);

        foreach (var viewModel in detailedOrderViewModels)
        {
            var correspondingOrder = orders.FirstOrDefault(o => o.Id == viewModel.Id);
            Assert.IsNotNull(correspondingOrder);

            Assert.AreEqual(viewModel.Id, correspondingOrder.Id);
            Assert.AreEqual(viewModel.Restaurant, correspondingOrder.Restaurant.Name);
            Assert.AreEqual(viewModel.Address, correspondingOrder.Address);
            Assert.AreEqual(viewModel.Amount, correspondingOrder.TotalAmount);
            Assert.AreEqual(viewModel.CreatedOn, correspondingOrder.CreatedOn.ToString(DataConstants.DateFormat));
            Assert.AreEqual(viewModel.Customer, $"{correspondingOrder.Customer.User.FirstName} {correspondingOrder.Customer.User.LastName}");
            Assert.AreEqual(viewModel.Status, correspondingOrder.OrderStatus.Name);

            Assert.AreEqual(correspondingOrder.Items.Count, viewModel.OrderItems.Count());
            foreach (var orderItemViewModel in viewModel.OrderItems)
            {
                var correspondingOrderItem = correspondingOrder.Items.FirstOrDefault(oi => oi.Id == orderItemViewModel.Id);
                Assert.IsNotNull(correspondingOrderItem);

                Assert.AreEqual(orderItemViewModel.Id, correspondingOrderItem.Id);
                Assert.AreEqual(orderItemViewModel.Name, correspondingOrderItem.MenuItem.Name);
                Assert.AreEqual(orderItemViewModel.Quantity, correspondingOrderItem.Quantity);
            }
        }
    }

    [Test]
    public async Task GetAllDetailedOrdersViewModelAsync_Should_Return_Empty_List_When_Input_Orders_Empty()
    {
        var emptyOrders = new List<Order>();

        var detailedOrderViewModels = await orderService.GetAllDetailedOrdersViewModelAsync(emptyOrders);

        Assert.IsEmpty(detailedOrderViewModels);
    }

    [Test]
    public async Task CreateOrderFromCartAsync_Should_Return_True()
    {
        bool result = await this.orderService.CreateOrderFromCartAsync(Customer.Id, "Some Address", "cash");

        Assert.IsTrue(result);
    }

    [Test]
    public async Task CreateOrderFromCartAsync_Should_Return_False_When_MenuItem_Do_Not_Exist()
    {
        CustomerCart cart = new CustomerCart()
        {
            CustomerId = 1,
            MenuItemId = 10
        };
        await dbContext.AddAsync(cart);
        await dbContext.SaveChangesAsync();

        bool result = await this.orderService.CreateOrderFromCartAsync(Customer.Id, "Some Address", "cash");

        Assert.AreEqual(5, repository.AllReadOnly<Order>().Count());
        Assert.IsFalse(result);
    }

    [Test]
    public async Task CreateOrderFromCartAsync_Should_Remove_CustomerCart()
    {
        bool result = await this.orderService.CreateOrderFromCartAsync(Customer.Id, "Some Address", "cash");

        Assert.AreEqual(0, repository.AllReadOnly<CustomerCart>().Count());
        Assert.IsTrue(result);
    }

    [Test]
    public async Task CreateOrderFromCartAsync_Should_Return_False_When_CustomerCart_Is_Empty()
    {
        bool result = await this.orderService.CreateOrderFromCartAsync(CustomerEmptyCart.Id, "Some Address", "cash");

        Assert.IsFalse(result);
    }
}