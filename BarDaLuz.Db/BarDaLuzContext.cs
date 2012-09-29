using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BarDaLuz.Db
{
    public class BarDaLuzContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<ProductTab> ProductsTabs { get; set; }
    }
}
