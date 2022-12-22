using Microsoft.EntityFrameworkCore;
using PokeAPI.Models;

namespace PokeAPI.Services
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }
        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
