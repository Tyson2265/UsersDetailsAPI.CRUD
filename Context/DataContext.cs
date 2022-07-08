using web_api_2.Models;
using Microsoft.EntityFrameworkCore;
namespace web_api_2.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
