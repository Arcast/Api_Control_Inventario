using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventario_Api_DTO
{
    public class BodegaDTO
    {

        public Guid BodegaId { get; set; } = Guid.Empty;      
        public string Nombre { get; set; } = string.Empty;      
        public string Codigo { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }
}