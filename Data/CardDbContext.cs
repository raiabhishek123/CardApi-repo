using CardServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CardServiceApi.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
