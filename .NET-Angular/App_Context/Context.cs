using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLG_Interview.Models;
using MLG_Interview.Models.User;

namespace MLG_Interview.Context
{
    public class MLG_Context:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public MLG_Context(DbContextOptions<MLG_Context> options) : base(options) { }
    }
}
