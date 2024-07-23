using Microsoft.EntityFrameworkCore;
using TheBazzarTest.Entity;

namespace TheBazzarTest.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
}