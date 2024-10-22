using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Entities
{
    [Table("MovimientoInventario", Schema = "Inventario")]
    public partial class MovimientoInventarioEntities
    {
        [Column("MovimientoId")]
        [Key]
        public Guid MovimientoId { get; set; }

        [Column("ProductoId")]
        public Guid ProductoId { get; set; }

        [Column("BodegaId")]
        public Guid BodegaId { get; set; }

        [Column("TipoMovimiento")]
        public string TipoMovimiento { get; set; }

        [Column("Cantidad")]
        public decimal Cantidad { get; set; }

        [Column("Observaciones")]
        public string Observaciones { get; set; }

        [Column("FechaMovimiento")]
        public DateTime FechaMovimiento { get; set; }

        [Column("CreadoPor")]
        public string CreadoPor { get; set; }
    }
}
