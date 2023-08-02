using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Servicio")]
    public class Servicio
    {
        [Key]
        public int IdServicio{ get; set; }
        public string? Descripcion { get; set; }
    }
}
