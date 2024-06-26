﻿using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static PizzaHub.Infrastructure.Constants.DataConstants.Order;

    public class Order
    {
        public Order()
        {
            this.Items = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(CourierId))]
        public int? CourierId { get; set; }
        public virtual Courier? Courier { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        [Required]
        [ForeignKey(nameof(OrderStatusId))]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? DeliveredOn { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

    }
}
