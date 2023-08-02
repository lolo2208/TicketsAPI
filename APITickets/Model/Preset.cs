using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Preset")]
    public class Preset
    {
        [Key]
        public int IdPreset { get; set; }

        public string? SiglaPreset { get; set; }

        public string? Titulo { get; set; }

        public int? IdServicio { get; set; }

        public int? IdCategoria { get; set; }

        public string? Comentario { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio? Servicio { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
    }
}
