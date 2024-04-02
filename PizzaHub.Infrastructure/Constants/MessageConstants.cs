namespace PizzaHub.Infrastructure.Constants
{
    public class MessageConstants
    {
        public static class AppEmailConstants
        {
            //TODO fix these messages here and the ones in message constants
            public const string FromAppEmail = "pizzamailtoyou@gmail.com";
            public const string FromAppTeam = "Pizza Hub Team";

            public const string OrderOutForDelivery = "Great news! Your order has been picked up by our courier and it's on it's way to you!";

            public const string OrderAcceptedSuccessfully = "Your order has been accepted successfully!";

            public const string OrderAcceptedBody =
                "Great news! Your order is now being prepared. Thanks for choosing us for your pizza delivery!";

            public const string CourierApprovalEmailMessage =
                "Congratulations! You've been approved to join our Courier ranks! Welcome to Pizza Hub Courier Service!";

            public const string CourierDeclinedEmailMessage =
                "We regret to inform you that your request to become a courier has been declined. We appreciate your interest and thank you for considering our platform.";
        }

        public static class ErrorMessages
        {
            public const string LengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

            public const string RequiredErrorMessage = "{0} is required.";

            public const string ErrorInCourierRequestMessage = 
               "Failed to submit your request to become a courier. You either have an ongoing request or and error occurred. Please try again later.";
        }

        public static class SuccessMessages
        {
            public const string SuccessCourierRequestSubmission =
                "Your request to become a courier has been successfully submitted. You will receive an email with the result of your request.";
        }

    }
}
