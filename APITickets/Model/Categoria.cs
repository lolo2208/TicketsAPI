using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public int IdServicio { get; set; }
        public string? Descripcion { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio Servicio{ get; set; }
    }
}
