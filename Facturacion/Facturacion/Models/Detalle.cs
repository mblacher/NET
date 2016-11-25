namespace Facturacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Detalle
    {
        public int Id { get; set; }

        public int FacturaId { get; set; }

        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public virtual Articulo Articulos { get; set; }

        public virtual Factura Factura { get; set; }

        public static decimal getPrecio(int Id)
        {
            Contexto c = new Contexto();
            return ((Articulo)c.Articulos.Where(a => a.Id == Id)).Precio;
        }
    }
}
