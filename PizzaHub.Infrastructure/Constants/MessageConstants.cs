namespace PizzaHub.Infrastructure.Constants
{
    public class MessageConstants
    {
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
