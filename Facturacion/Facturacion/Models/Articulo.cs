namespace Facturacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public static decimal getPrecio(int Id)
        {
            Contexto c = new Contexto();
            return ((Articulo)c.Articulos.Where(a => a.Id == Id)).Precio;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
