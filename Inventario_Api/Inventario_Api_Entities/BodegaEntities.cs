using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario_Api_Entities
{
    [Table("Bodega", Schema = "Inventario")]
    public partial class BodegaEntities
    {

        [Column("BodegaId")]
        [Key]
        public Guid BodegaId { get; set; }

        [Column("Nombre")]       
        public string Nombre { get; set; }

        [Column("Codigo")]
        public String Codigo { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

    }
}