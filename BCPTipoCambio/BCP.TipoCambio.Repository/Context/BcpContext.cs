using BCP.TipoCambio.Domain.Entities;
using BCP.TipoCambio.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BCP.TipoCambio.Repository.Context
{
    public class BcpContext : DbContext
    {
        public BcpContext(DbContextOptions<BcpContext> options) : base(options)
        {
        }
            
        #region DBSET
        public DbSet<Moneda> MONEDA { get; set; }
        public DbSet<BCP.TipoCambio.Domain.Entities.TipooCambio> TIPOCAMBIO { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Moneda>()
                .HasKey(o => new { o.ID });

            builder.Entity<BCP.TipoCambio.Domain.Entities.TipooCambio>()
                .HasKey(o => new { o.ID });

            DbSeed(builder);

            base.OnModelCreating(builder);
        }

        protected virtual void DbSeed(ModelBuilder builder) { }
    }
}
