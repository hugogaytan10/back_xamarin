using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movilapispruebas.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string? tipo_usuario { get; set; }
    }

    public enum TipoUsuario
    {
        E, // estudiantes
        D, // docentes
        V, // vigilante
        A  // admin
    }
}

