using System;
using System.ComponentModel;

namespace PizzaHub.Infrastructure.Enums
{
    public enum OrderStatusEnum
    {
        [Description("Pending")]
        Pending = 1,

        [Description("In Progress")] 
        InProgress = 2,

        [Description("Out For Delivery")]
        OutForDelivery = 3,

        [Description("Delivered")] 
        Delivered = 4,

        [Description("Canceled")]
        Canceled = 5,
        
    }
}
