using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Entities
{
    [Table("Producto", Schema = "Inventario")]
    public class ProductoEntities
    {
        [Key]
        [Column("ProductoId")]
        public Guid ProductoId { get; set; }

        [Column("NombreProducto")]
        public string NombreProducto { get; set;}

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set;}

        [Column("CreadoPor")]
        public string CreadoPor { get; set; }
    }
}
