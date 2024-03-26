namespace PizzaHub.Core.ViewModels.Courier
{
    public class CourierApplicantModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
