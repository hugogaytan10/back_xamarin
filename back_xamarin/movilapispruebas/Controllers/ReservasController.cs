using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reservasController : Controller
    {
        private readonly AppDbContext context;
        public reservasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<Reservas> Get()
        {
            return context.reservas.ToList();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public Reservas Get(int id)
        {
            return context.reservas.FirstOrDefault(x => x.id == id);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public int Post([FromBody] Reservas reservas)
        {

            return context.reservas.Add(reservas).Context.SaveChanges();

        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Reservas personaActualizada)
        {
            Reservas? personaBuscada = context.reservas.FirstOrDefault(x => x.id == id);
            if (personaBuscada == null) { return 0; }
            personaBuscada.id_puesto = personaActualizada.id_puesto;
            personaBuscada.id_usuario = personaActualizada.id_usuario;
            personaBuscada.fecha_reserva = personaActualizada.fecha_reserva;
            personaBuscada.hora_inicio = personaActualizada.hora_inicio;
            personaBuscada.hora_fin = personaActualizada.hora_fin;
            personaBuscada.estado = personaActualizada?.estado;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.reservas.FirstOrDefault(x => x.id == id);

            if (personaBuscada != null)
            {
                response = context.reservas.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }
    }
}
