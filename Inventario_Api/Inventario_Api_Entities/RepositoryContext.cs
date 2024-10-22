using Inventario_Api_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
           : base(options)
        {
        }

        // Here configure DbSets
        public virtual DbSet<BodegaEntities> Bodegas { get; set; }
        public virtual DbSet<ProductoEntities> Productos { get; set; }
        public virtual DbSet<MovimientoInventarioEntities> MovimientoInventarioEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
