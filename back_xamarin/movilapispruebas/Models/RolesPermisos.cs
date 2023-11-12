using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace movilapispruebas.Models
{
    public class RolesPermisos
    {


        [ForeignKey("id_rol")]
        public Int64 id_rol { get; set; }

        [ForeignKey("id_permiso")]
        public Int64 id_permiso { get; set; } // Se ha agregado 'set' aquí
    }
}
