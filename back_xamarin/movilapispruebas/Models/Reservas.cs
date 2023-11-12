using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movilapispruebas.Models
{
    public class Reservas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public Int64 id_puesto { get; set; }
        public Int64 id_usuario { get; set; }
        public DateTime fecha_reserva { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public string? estado { get; set; }
    }

    public enum EstadoReserva
    {
        activa,
        expirada,
        cancelada
    }
}

