using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly AppDbContext context;

        public PuestosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/puestos
        [HttpGet]
        public IEnumerable<Puestos> Get()
        {
            return context.puestos.ToList();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public Puestos Get(int id)
        {
            return context.puestos.FirstOrDefault(x => x.id == id);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public int Post([FromBody] Puestos puestos)
        {

            return context.puestos.Add(puestos).Context.SaveChanges();

        }


        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Puestos puestosActualizada)
        {
            Puestos? personaBuscada = context.puestos.FirstOrDefault(x => x.id == id);
            if (personaBuscada == null) { return 0; }
            personaBuscada.numero = puestosActualizada.numero;
            personaBuscada.estado = puestosActualizada.estado;
            personaBuscada.id_zona_parqueo = puestosActualizada.id_zona_parqueo;
           

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.puestos.FirstOrDefault(x => x.id == id);

            if (personaBuscada != null)
            {
                response = context.puestos.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }
    }
}