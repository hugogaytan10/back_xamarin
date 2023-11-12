using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movilapispruebas.Models
{
    public class Puestos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public int? numero { get; set; }
        public string? estado { get; set; }
        public Int64 id_zona_parqueo { get; set; }
    }

    public enum EstadoPuesto
    {
        libre,
        ocupado,
        inactivo
    }

}
