using Microsoft.EntityFrameworkCore;
using AuthManagment_WebAPI_80.Models;

namespace AuthManagment_WebAPI_80.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<PersonaModel> Personas { get; set; }

    }
}
