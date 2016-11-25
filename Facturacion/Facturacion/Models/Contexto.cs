namespace Facturacion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
            Database.SetInitializer<Contexto>(new CreateDatabaseIfNotExists<Contexto>());
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Precio);
              //  .HasPrecision(18, 0);

            modelBuilder.Entity<Articulo>()
                .HasMany(e => e.Detalles)
                .WithRequired(e => e.Articulos)
                .HasForeignKey(e => e.ArticuloId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detalle>()
                .Property(e => e.Precio);
            // .HasPrecision(18, 0);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Total);
               // .HasPrecision(18, 0);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Detalles)
                .WithRequired(e => e.Factura)
                .HasForeignKey(e => e.FacturaId)
                .WillCascadeOnDelete(false);
        }
    }
}
