using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movilapispruebas.Models
{
    public class Historiales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public Int64 id_puesto { get; set; }
        public string? placa_vehiculo { get; set; }
        public Int64 id_reservas { get; set; }
    }
}
