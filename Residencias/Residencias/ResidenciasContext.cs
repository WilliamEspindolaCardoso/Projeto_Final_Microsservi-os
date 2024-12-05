using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Residencias
{
    public class ResidenciasContext : DbContext
        {
        public ResidenciasContext(DbContextOptions<ResidenciasContext> options)
        : base(options)
        { }

        public DbSet<Models.Residencia> Residencias { get; set; }
    }
}
