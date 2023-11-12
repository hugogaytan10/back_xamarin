using System.ComponentModel.DataAnnotations;

namespace movilapispruebas.Models
{
    public class Login
    {
        [Key]
        public string? correoelectronico { get; set; }
        public string? contrasena { get; set; }
    }
}
