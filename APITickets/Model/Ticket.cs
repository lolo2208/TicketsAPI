using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITickets.Model
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }

        public string? CodTicket { get; set; }

        public string? Titulo { get; set; }

        public int? IdServicio { get; set; }

        public int? IdCategoria { get; set; }

        public string? ComentarioUsuario { get; set; }

        public string? ComentarioSolucion { get; set; }

        public int? IdEstado { get; set; }

        public int? IdUsuarioReg { get; set; }

        public DateTime? FecRegistro { get; set; }

        public DateTime? HorRegistro { get; set; }

        public DateTime? FecSolucion { get; set; }

        public DateTime? HorSolucion { get; set; }

        public int? IdUsuarioSol { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio Servicio { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }

        [ForeignKey("IdUsuarioReg")]
        public Usuario UsuarioRegistro { get; set; }

        [ForeignKey("IdUsuarioSol")]
        public Usuario UsuarioSolucion { get; set; }
    }
}
