﻿using System.ComponentModel.DataAnnotations.Schema;
using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static DataConstants.MenuItem;
    public class MenuItem
    {
        public MenuItem()
        {
            this.CustomerCart = new HashSet<CustomerCart>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required] 
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [ForeignKey(nameof(RestaurantId))]
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; } = null!;

        public virtual ICollection<CustomerCart> CustomerCart { get; set; }
    }
}