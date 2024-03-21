using System;
using System.ComponentModel;

namespace PizzaHub.Infrastructure.Enums
{
    public enum OrderStatusEnum
    {
        [Description("In Progress")] 
        InProgress = 1,

        [Description("Out For Delivery")]
        OutForDelivery = 2,

        [Description("Delivered")] 
        Delivered = 3,

        [Description("Canceled")]
        Canceled = 4,

        [Description("Pending")]
        Pending = 5,

    }
}
