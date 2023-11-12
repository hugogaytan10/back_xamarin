using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;
using System.Collections.Generic;
using System.Linq;

namespace movilapispruebas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonaParqueoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ZonaParqueoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/zonaparqueo
        [HttpGet]
        public IEnumerable<ZonasParqueo> Get()
        {
            return context.zonasparqueo.ToList();
        }

        // GET api/zonaparqueo/5
        [HttpGet("{id}")]
        public ZonasParqueo Get(long id)
        {
            return context.zonasparqueo.FirstOrDefault(x => x.id == id);
        }

        // POST api/zonaparqueo
        [HttpPost]
        public int Post([FromBody] ZonasParqueo zonaParqueo)
        {
            context.zonasparqueo.Add(zonaParqueo);
            return context.SaveChanges();
        }

        // PUT api/zonaparqueo/5
        [HttpPut("{id}")]
        public int Put(long id, [FromBody] ZonasParqueo zonaParqueoActualizada)
        {
            ZonasParqueo zonaParqueoBuscada = context.zonasparqueo.FirstOrDefault(x => x.id == id);
            if (zonaParqueoBuscada == null)
            {
                return 0;
            }
            zonaParqueoBuscada.nombre = zonaParqueoActualizada.nombre;
            zonaParqueoBuscada.ubicacion = zonaParqueoActualizada.ubicacion;
            zonaParqueoBuscada.capacidad = zonaParqueoActualizada.capacidad;
            int result = context.SaveChanges();
            return result;
        }

        // DELETE api/zonaparqueo/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            int response = 0;
            ZonasParqueo zonaParqueoBuscada = context.zonasparqueo.FirstOrDefault(x => x.id == id);
            if (zonaParqueoBuscada != null)
            {
                context.zonasparqueo.Remove(zonaParqueoBuscada);
                response = context.SaveChanges();
            }
            return response;
        }
    }
}