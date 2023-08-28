using Microsoft.EntityFrameworkCore;

namespace QVision_Task.Models
{
    public class QvisionContext : DbContext
    {
        public QvisionContext()
        {
        }
        public QvisionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }

        public DbSet<Account> accounts { get; set; }

    }
}
