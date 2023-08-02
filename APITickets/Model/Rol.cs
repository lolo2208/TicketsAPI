using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        public string? Descripcion { get; set; }
    }
}