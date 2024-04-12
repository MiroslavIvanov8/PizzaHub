using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Services;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.UnitTests;

[TestFixture]
public class OrderServiceUnitTests
{
    private PizzaHubDbContext dbContext;
            
    private IRepository repository;
            
    private OrderService orderService;
            
    private ICollection<MenuItem> MenuItems;
            
    private Restaurant Restaurant;
    private MenuItem Margheritta;
    private MenuItem Pepperoni;
    private MenuItem Toscana;
    private MenuItem Hawaii;
            
    private Order order;

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
        orderService = new OrderService(repository);
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
        Order order = new Order()
        {
            Id = 1,
            CustomerId = 1,
            CourierId = 1,
            RestaurantId = 1,
            Address = "123 Main St",
            PaymentMethodId = 1,
            OrderStatusId = 1,
            CreatedOn = DateTime.UtcNow,
            DeliveredOn = DateTime.UtcNow.AddHours(1),
            TotalAmount = 25.00M
        };

        await repository.AddAsync(order);
        await repository.SaveChangesAsync();

        Order retrievedOrder = await orderService.GetOrderAsync(1);

        Assert.IsNotNull(retrievedOrder);
        Assert.AreEqual(order.Id, retrievedOrder.Id);
        Assert.AreEqual(order.CustomerId, retrievedOrder.CustomerId);
        Assert.AreEqual(order.CourierId, retrievedOrder.CourierId);
        Assert.AreEqual(order.RestaurantId, retrievedOrder.RestaurantId);
        Assert.AreEqual(order.Address, retrievedOrder.Address);
        Assert.AreEqual(order.PaymentMethodId, retrievedOrder.PaymentMethodId);
        Assert.AreEqual(order.OrderStatusId, retrievedOrder.OrderStatusId);
        Assert.AreEqual(order.CreatedOn, retrievedOrder.CreatedOn);
        Assert.AreEqual(order.DeliveredOn, retrievedOrder.DeliveredOn);
        Assert.AreEqual(order.TotalAmount, retrievedOrder.TotalAmount);
    }
    [Test]
    public async Task GetOrderAsync_Should_Return_Correct_Null()
    {
        Order retrievedOrder = await orderService.GetOrderAsync(1);

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
    public async Task GetDetailedOrderViewModelAsync_Should_Return_Correct_Order_When_Id_Found()
    {
        Order orderInDatabase = new Order()
        {
            Id = 1,
            RestaurantId = 1,
            Address = "123 Main St",
            TotalAmount = 25.00M,
            CreatedOn = DateTime.UtcNow,
            Customer = new Customer()
            {
                Id = 1,
                User = new ApplicationUser()
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            },
            Items = new List<OrderItem>()
        {
            new OrderItem()
            {
                Id = 1,
                MenuItem = Margheritta,
                Quantity = 2
            },
            new OrderItem()
            {
                Id = 2,
                MenuItem = Pepperoni,
                Quantity = 1
            }
        },
            OrderStatus = new OrderStatus()
            {
                Id = 1,
                Name = "Delivered"
            }
        };

        await repository.AddAsync(orderInDatabase);
        await repository.SaveChangesAsync();

        DetailedOrderViewModel? retrievedOrder = await orderService.GetDetailedOrderViewModelAsync(1);

        Assert.IsNotNull(retrievedOrder);
        Assert.AreEqual(orderInDatabase.Id, retrievedOrder.Id);
        Assert.AreEqual(orderInDatabase.Restaurant.Name, retrievedOrder.Restaurant);
        Assert.AreEqual(orderInDatabase.Address, retrievedOrder.Address);
        Assert.AreEqual(orderInDatabase.TotalAmount, retrievedOrder.Amount);
        Assert.AreEqual(orderInDatabase.CreatedOn.ToString(DataConstants.DateFormat), retrievedOrder.CreatedOn);
        Assert.AreEqual($"{orderInDatabase.Customer.User.FirstName} {orderInDatabase.Customer.User.LastName}", retrievedOrder.Customer);
        Assert.AreEqual(orderInDatabase.Items.Count, retrievedOrder.OrderItems.Count());
        Assert.AreEqual(orderInDatabase.OrderStatus.Name, retrievedOrder.Status);
    }
    [Test]
    public async Task GetStatusNamesAsync_Should_Return_Status_Names()
    {
        var orderStatuses = new List<OrderStatus>()
        {
            new OrderStatus() { Id = 1, Name = "Pending" },
            new OrderStatus() { Id = 2, Name = "In Progress" },
            new OrderStatus() { Id = 3, Name = "Out for Delivery"},
            new OrderStatus() { Id = 4, Name = "Delivered" },
            new OrderStatus() { Id = 5, Name = "Cancelled" }
        };

        await repository.AddRangeAsync(orderStatuses);
        await repository.SaveChangesAsync();

        IEnumerable<string> statusNames = await orderService.GetStatusNamesAsync();

        Assert.IsNotNull(statusNames);
        Assert.AreEqual(orderStatuses.Count, statusNames.Count());

        foreach (var statusName in orderStatuses.Select(s => s.Name))
        {
            Assert.Contains(statusName, (System.Collections.ICollection?)statusNames);
        }
    }
}