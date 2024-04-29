using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Author_API.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<News> News { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

    }
}
