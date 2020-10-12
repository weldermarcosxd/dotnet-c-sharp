using GoogleBooksDomain;
using Microsoft.EntityFrameworkCore;

namespace GoogleBooksData.Context
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
