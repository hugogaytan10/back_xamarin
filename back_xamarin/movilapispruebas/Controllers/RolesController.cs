using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly AppDbContext context;
        public RolesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<Roles> Get()
        {
            return context.roles.ToList();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public Roles Get(int id)
        {
            return context.roles.FirstOrDefault(x => x.id == id);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public int Post([FromBody] Roles roles)
        {

            return context.roles.Add(roles).Context.SaveChanges();

        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Roles personaActualizada)
        {
            Roles? personaBuscada = context.roles.FirstOrDefault(x => x.id == id);
            if (personaBuscada == null) { return 0; }
            personaBuscada.tipo_usuario = personaActualizada?.tipo_usuario;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.roles.FirstOrDefault(x => x.id == id);

            if (personaBuscada != null)
            {
                response = context.roles.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }

    }
}
