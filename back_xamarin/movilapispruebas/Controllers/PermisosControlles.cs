using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movilapispruebas.Data;
using movilapispruebas.Models;
using System.Collections.Generic;
using System.Linq;


namespace TuNombreDeProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private readonly AppDbContext context;
        
        public PermisosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/permisos
        [HttpGet]
        public IEnumerable<Permisos> Get()
        {
            return context.permisos.ToList();
        }

        // GET api/permisos/5
        [HttpGet("{id}")]
        public Permisos Get(int id)
        {
            return context.permisos.FirstOrDefault(x => x.id == id);
        }

        // POST api/permisos
        [HttpPost]
        public int Post([FromBody] Permisos permiso)
        {
            context.permisos.Add(permiso);
            return context.SaveChanges();
        }

        // PUT api/permisos/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Permisos permisoActualizado)
        {
            Permisos permisoBuscado = context.permisos.FirstOrDefault(x => x.id == id);
            if (permisoBuscado == null)
            {
                return 0;
            }
            permisoBuscado.nombre = permisoActualizado.nombre;
            int result = context.SaveChanges();
            return result;
        }

        // DELETE api/permisos/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;
            Permisos permisoBuscado = context.permisos.FirstOrDefault(x => x.id == id);
            if (permisoBuscado != null)
            {
                context.permisos.Remove(permisoBuscado);
                response = context.SaveChanges();
            }
            return response;
        }
    }
}