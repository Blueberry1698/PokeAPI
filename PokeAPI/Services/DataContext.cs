using Microsoft.EntityFrameworkCore;
using PokeAPI.Models;

namespace PokeAPI.Services
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Types> Types { get; set; }
    }
}
