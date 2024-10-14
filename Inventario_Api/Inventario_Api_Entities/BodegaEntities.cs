using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario_Api_Entities
{
    [Table("Bodega", Schema = "Inventario")]
    public class BodegaEntities
    {
        [Column("BodegaId")]
        [Key]
        public Guid BodegaId { get; set; }

        [Column("Nombre")]
        [Required]
        public string Nombre { get; set; } 

        [Column("Codigo")]
        public String Codigo { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

    }
}