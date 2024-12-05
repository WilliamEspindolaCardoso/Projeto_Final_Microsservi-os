using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Moradores
{
    public class MoradoresContext : DbContext
    {
        public MoradoresContext(DbContextOptions<MoradoresContext> options)
        : base(options)
        { }

        public DbSet<Models.Morador> Moradores { get; set; }
    }
}