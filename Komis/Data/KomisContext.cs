using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Komis.Models;

namespace Komis.Data
{
    public class KomisContext : DbContext
    {
        public KomisContext() { }
        public KomisContext(DbContextOptions<KomisContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Meeting> Meetings { get; set; }
    }
}
