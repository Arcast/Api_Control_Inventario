using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_DTO
{
    public class ProductoDTO
    {
        public Guid ProductoId { get; set; }

        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string CreadoPor { get; set; }
    }
}
