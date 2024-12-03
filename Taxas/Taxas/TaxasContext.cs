using System.Collections.Generic;

namespace Taxas
{
    public class TaxasContext
    {
        public class TaxasContext : DbContext
        {
            public TaxasContext(DbContextOptions<TaxasContext> options)
            : base(options)
            { }

            public DbSet<Models.Taxa> Taxas { get; set; }
        }
    }
}
