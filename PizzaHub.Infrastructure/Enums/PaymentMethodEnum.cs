using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Infrastructure.Enums
{
    public enum PaymentMethodEnum
    {
        [Description("Cash")]
        Cash = 1,

        [Description("Card")]
        Card = 2,
    }
}
