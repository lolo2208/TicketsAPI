using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int IdEstado{ get; set; }
        public string? Descripcion { get; set; }
    }
}

