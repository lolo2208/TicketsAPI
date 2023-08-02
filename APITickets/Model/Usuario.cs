using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITickets.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Apaterno { get; set; }

        public string? Amaterno { get; set; }

        public string? Celular { get; set; }

        public string? Contrasenia { get; set; }

        public string? Correo { get; set; }

        public string? FotoUri { get; set; }

        public int? IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Rol? Rol { get; set; }
        
    }
}
