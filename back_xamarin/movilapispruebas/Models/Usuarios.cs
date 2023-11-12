using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movilapispruebas.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string? tipoindentificacion { get; set; }
        public int? identificacion { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public int? edad { get; set; }
        public int? telefono { get; set; }
        public string? G_S_RH { get; set; }
        public string? sexo { get; set; }
        public string? login_correoelectronico { get; set; }
        public Int64 id_rol { get; set; }
    }

    public enum TipoIdentificacion
    {
        C, // Cédula
        T  // Tarjeta de Identidad
    }

    public enum Sexo
    {
        M, // Masculino
        F  // Femenino
    }
}

