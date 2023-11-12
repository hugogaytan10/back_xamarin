using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesPermisosController : Controller
    {
        private readonly AppDbContext context;
        public RolesPermisosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<RolesPermisos> Get()
        {
            return context.rolespermisos.ToList();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("por-id-rol/{id_rol}")]
        public IActionResult GetByIdRol(int id_rol)
        {
            var rolesPermisos = context.rolespermisos
                .Where(rp => rp.id_rol == id_rol)
                .ToList();

            if (rolesPermisos.Count == 0)
            {
                return NotFound();
            }

            return Ok(rolesPermisos);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public int Post([FromBody] RolesPermisos rolespermisos)
        {

            return context.rolespermisos.Add(rolespermisos).Context.SaveChanges();

        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id_rol}/{id_permiso}")]
        public IActionResult Put(int id_rol, int id_permiso, [FromBody] RolesPermisos rolesPermisosActualizado)
        {
            var rolesPermisosBuscado = context.rolespermisos
                .FirstOrDefault(rp => rp.id_rol == id_rol && rp.id_permiso == id_permiso);

            if (rolesPermisosBuscado == null)
            {
                return NotFound();
            }

            // Elimina el registro existente
            context.rolespermisos.Remove(rolesPermisosBuscado);
            context.SaveChanges();

            // Inserta un nuevo registro con los valores actualizados
            context.rolespermisos.Add(rolesPermisosActualizado);
            context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id_rol}/{id_permiso}")]
        public IActionResult Delete(int id_rol, int id_permiso)
        {
            var rolesPermisosBuscado = context.rolespermisos
                .FirstOrDefault(rp => rp.id_rol == id_rol && rp.id_permiso == id_permiso);

            if (rolesPermisosBuscado == null)
            {
                return NotFound();
            }

            // Elimina el registro existente
            context.rolespermisos.Remove(rolesPermisosBuscado);
            context.SaveChanges();

            return NoContent();
        }
    }
}
