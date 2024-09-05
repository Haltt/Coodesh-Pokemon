using Coodesh_Pokemon.Models;
using Microsoft.EntityFrameworkCore;

namespace Coodesh_Pokemon.Data
{
    public class PokemonMasterContext(DbContextOptions<PokemonMasterContext> options) : DbContext(options)
    {
        public DbSet<PokemonMaster> PokemonMasters { get; set; }
    }
}
