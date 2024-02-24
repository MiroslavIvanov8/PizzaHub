using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PizzaHub.Data
{
    public class PizzaHubDbContext : IdentityDbContext
    {
        public PizzaHubDbContext(DbContextOptions<PizzaHubDbContext> options)
            : base(options)
        {
        }
    }
}
