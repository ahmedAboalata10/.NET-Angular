using Microsoft.EntityFrameworkCore;
using MLG_Interview.Models;

namespace MLG_Interview.Context
{
    public class MLG_Context:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public MLG_Context(DbContextOptions<MLG_Context> options) : base(options) { }
    }
}
