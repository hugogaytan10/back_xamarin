using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movilapispruebas.Models
{
    public class Vehiculos
    {
        [Key]
        public string? placa { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public string? color { get; set; }
        public Int64 id_usuario { get; set; }
    }
}
