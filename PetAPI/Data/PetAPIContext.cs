using Microsoft.EntityFrameworkCore;
using PetAPI.Model;

namespace PetAPI.Data
{
    public class PetAPIContext : DbContext
    {
        public PetAPIContext(DbContextOptions<PetAPIContext> options) : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; } = default!;
        public DbSet<Cat> Cats { get; set; } = default!;

    }
}
