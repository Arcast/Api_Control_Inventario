using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_DTO
{
    public class MovimientoInventarioDTO
    {
        public Guid MovimientoId { get; set; }
        public Guid ProductoId { get; set; }
        public Guid BodegaId { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Cantidad { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string CreadoPor { get; set; }
    }
}
