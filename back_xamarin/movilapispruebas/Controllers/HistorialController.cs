using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly AppDbContext context;
        public HistorialController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ReservasController>
        [HttpGet]
        public IEnumerable<Historiales> Get()
        {
            return context.historial.ToList();
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public Historiales Get(int id)
        {
            return context.historial.FirstOrDefault(x => x.id == id);
        }

        // POST api/<ReservasController>
        [HttpPost]
        public int Post([FromBody] Historiales historial)
        {

            return context.historial.Add(historial).Context.SaveChanges();

        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Historiales historialesActualizada)
        {
            Historiales? personaBuscada = context.historial.FirstOrDefault(x => x.id == id);
            if (personaBuscada == null) { return 0; }
            personaBuscada.id_puesto = historialesActualizada.id_puesto;
            personaBuscada.placa_vehiculo = historialesActualizada?.placa_vehiculo;
            personaBuscada.id_reservas = historialesActualizada.id_reservas;
            

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.historial.FirstOrDefault(x => x.id == id);

            if (personaBuscada != null)
            {
                response = context.historial.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }
    }
}
