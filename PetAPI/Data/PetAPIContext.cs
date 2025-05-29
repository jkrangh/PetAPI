using Microsoft.EntityFrameworkCore;
using PetAPI.Model;

namespace PetAPI.Data
{
    public partial class PetAPIContext : DbContext
    {
        public PetAPIContext(DbContextOptions<PetAPIContext> options) : base(options)
        {
        }
    }
}
