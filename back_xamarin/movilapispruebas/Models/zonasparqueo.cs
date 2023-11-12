using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movilapispruebas.Models
{
    public class ZonasParqueo
    {
        [Key]
        public Int64 id { get; set; }
        public string? nombre { get; set; }
        public string? ubicacion { get; set; }

        public Int64 capacidad { get; set; }



    }
}
