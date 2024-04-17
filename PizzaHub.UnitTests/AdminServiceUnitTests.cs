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
using PizzaHub.Infrastructure.Enums;
using PizzaHub.Core.ViewModels.Courier;

namespace PizzaHub.UnitTests;

[TestFixture]
public class AdminServiceUnitTests
{
    private PizzaHubDbContext dbContext;

    private IRepository repository;

    private IAdminService adminService;
    private IOrderService orderService;
    private ISendGridEmailSender emailSender;

    private Restaurant Restaurant;

    private ICollection<MenuItem> MenuItems;
    private ICollection<Order> Orders;
    private ICollection<OrderStatus> OrderStatuses;

    private ApplicationUser GuestUser;

    private Customer Customer;
    private ApplicationUser CustomerUser;
    private CourierApplicationRequest CourierRequest;
    private CourierApplicationRequest CourierRequestTwo;

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
        CourierRequest = new CourierApplicationRequest()
        {
            Id = 1,
            UserId = Customer.UserId,
            PhoneNumber = "000 000 000",
            Description = "blah blah blah"
        };
        CourierRequestTwo = new CourierApplicationRequest()
        {
            Id = 2,
            UserId = GuestUser.Id,
            PhoneNumber = "000 000 000",
            Description = "blah blah blah"
        };

        Pending = new OrderStatus { Id = 1, Name = "Pending" };
        InProgress = new OrderStatus { Id = 2, Name = "In Progress" };
        OutForDelivery = new OrderStatus { Id = 3, Name = "Out for Delivery" };
        Delivered = new OrderStatus { Id = 4, Name = "Delivered" };
        Canceled = new OrderStatus { Id = 5, Name = "Canceled" };
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
            IsDeleted = false
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
            }
        };
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
        adminService = new AdminService(repository, orderService, emailSender);

        await dbContext.AddAsync(Restaurant);
        await dbContext.AddAsync(CustomerUser);
        await dbContext.AddAsync(GuestUser);
        await dbContext.AddAsync(Customer);
        await dbContext.AddAsync(CourierRequest);
        await dbContext.AddAsync(CourierRequestTwo);
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
    public async Task GetMenuItemFormAsync_Should_Return_Correct_Model()
    {
        MenuItemFormModel model = await adminService.GetMenuItemFormAsync(Margheritta.Id);

        Assert.IsNotNull(model);
        Assert.IsInstanceOf<MenuItemFormModel>(model);
        Assert.AreEqual(Margheritta.Id, model.Id);
        Assert.AreEqual(Margheritta.ImageUrl, model.ImageUrl);
        Assert.AreEqual(Margheritta.Ingredients, model.Ingredients);
        Assert.AreEqual(Margheritta.Name, model.Name);
        Assert.AreEqual(Margheritta.Price, model.Price);

    }

    [Test]
    public async Task GetMenuItemFormAsync_Should_Return_Null_With_If_Wrong_Id()
    {
        MenuItemFormModel model = await adminService.GetMenuItemFormAsync(100);

        Assert.IsNull(model);
    }

    [Test]
    public async Task MarkOrderAcceptedAsync_Should_Change_Order_Status_To_InProgress()
    {
        await adminService.MarkOrderAcceptedAsync(PendingOrder.Id);

        Assert.AreEqual((int)OrderStatusEnum.InProgress, PendingOrder.OrderStatusId);
    }

    [Test]
    public async Task MarkOrderAcceptedAsync_Should_Not_Change_Order_Status_If_OrderId_Is_Invalid()
    {
        await adminService.MarkOrderAcceptedAsync(100);

        Assert.AreEqual((int)OrderStatusEnum.Pending, PendingOrder.OrderStatusId);
    }

    [Test]
    public async Task GetCourierApplicantsAsync_Should_Return_Correct_Model()
    {
        CourierApplicantModel model = await adminService.GetCourierApplicantsAsync(Customer.Id);

        Assert.IsNotNull(model);
        Assert.IsInstanceOf<CourierApplicantModel>(model);
        Assert.AreEqual(model.Id,Customer.Id);
        Assert.AreEqual(model.FullName, Customer.User.FirstName + " " + Customer.User.LastName);
        Assert.AreEqual(model.Email, Customer.User.Email);
        Assert.AreEqual(model.PhoneNumber, CourierRequest.PhoneNumber);
        Assert.AreEqual(model.Description, CourierRequest.Description);
    }

    [Test]
    public async Task GetCourierApplicantsAsync_Should_Return_Null_When_Invalid_Id()
    {
        CourierApplicantModel model = await adminService.GetCourierApplicantsAsync(100);

        Assert.IsNull(model);
    }

    [Test]
    public async Task DeleteMenuItemAsync_Should_Return_True()
    {
        bool result = await adminService.DeleteMenuItemAsync(Margheritta.Id);

        Assert.IsTrue(result);
        Assert.IsTrue(Margheritta.IsDeleted);
    }

    [Test]
    public async Task DeleteMenuItemAsync_Should_Return_False_If_Invalid_Id()
    {
        bool result = await adminService.DeleteMenuItemAsync(100);

        Assert.IsFalse(result);
        Assert.IsFalse(Margheritta.IsDeleted);
    }

    [TestCase("Pending")]
    [TestCase("In Progress")]
    [TestCase("Out for Delivery")]
    [TestCase("Delivered")]
    [TestCase("Canceled")]
    public async Task GetAllOrdersAsync_Should_Filter_Correctly(string status)
    {
        var model = await adminService.GetAllOrdersAsync(status, FilterDays.All);

        Assert.IsNotNull(model);
        Assert.AreEqual(1,model.Orders.Count());
        Assert.AreEqual(1, model.OrdersCount);
    }

    [Test]
    public async Task GetAllOrdersAsync_Should_Filter_By_Days_Correctly()
    {
        var model = await adminService.GetAllOrdersAsync("All", FilterDays.Today);

        Assert.IsNotNull(model);
        Assert.AreEqual(5,model.Orders.Count());
        Assert.AreEqual(5, model.OrdersCount);
    }

    [Test]
    public async Task AddMenuItemAsync_Should_Add_And_Return_Correct_Id()
    {
        MenuItemFormModel formModel = new MenuItemFormModel()
        {
            Id = 5,
            ImageUrl = "someUrl",
            Ingredients = "ingredients",
            Name = "new item",
            Price = 10.00M
        };

        int newItemId = await adminService.AddMenuItemAsync(formModel);

        Assert.IsNotNull(newItemId);
        Assert.AreEqual(5,newItemId);
        Assert.AreEqual(5,repository.AllReadOnly<MenuItem>().Count());
    }
}