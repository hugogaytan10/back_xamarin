using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly AppDbContext context;
        public VehiculosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<VehiculosController>
        [HttpGet]
        public IEnumerable<Vehiculos> Get()
        {
            return context.vehiculos.ToList();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{placa}")]
        public Vehiculos Get(string placa)
        {
            return context.vehiculos.FirstOrDefault(x => x.placa == placa);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public int Post([FromBody] Vehiculos vehiculos)
        {
            return context.vehiculos.Add(vehiculos).Context.SaveChanges();
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{placa}")]
        public int Put(string placa, [FromBody] Vehiculos vehiculosActualizada)
        {
            Vehiculos? vehiculoBuscado = context.vehiculos.FirstOrDefault(x => x.placa == placa);
            if (vehiculoBuscado == null) { return 0; }
            vehiculoBuscado.marca = vehiculosActualizada?.marca;
            vehiculoBuscado.modelo = vehiculosActualizada?.modelo;
            vehiculoBuscado.color = vehiculosActualizada?.color;
            vehiculoBuscado.id_usuario = vehiculosActualizada.id_usuario;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{placa}")]
        public int Delete(string placa)
        {
            int response = 0;

            var vehiculoBuscado = context.vehiculos.FirstOrDefault(x => x.placa == placa);

            if (vehiculoBuscado != null)
            {
                response = context.vehiculos.Remove(vehiculoBuscado).Context.SaveChanges();
            }

            return response;
        }
    }
}
