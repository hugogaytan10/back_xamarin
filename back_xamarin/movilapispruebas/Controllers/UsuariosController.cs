using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext context;
        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ReservasController>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return context.usuarios.ToList();
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public Usuarios Get(int id)
        {
            return context.usuarios.FirstOrDefault(x => x.id == id);
        }

        // POST api/<ReservasController>
        [HttpPost]
        public int Post([FromBody] Usuarios usuarios)
        {

            return context.usuarios.Add(usuarios).Context.SaveChanges();

        }



        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Usuarios usuariosActualizada)
        {
            Usuarios? personaBuscada = context.usuarios.FirstOrDefault(x => x.id == id);
            if (personaBuscada == null) { return 0; }
            personaBuscada.tipoindentificacion = usuariosActualizada?.tipoindentificacion;
            personaBuscada.identificacion = usuariosActualizada.identificacion;
            personaBuscada.nombres = usuariosActualizada?.nombres;
            personaBuscada.apellidos = usuariosActualizada?.apellidos;
            personaBuscada.edad = usuariosActualizada.edad;
            personaBuscada.telefono = usuariosActualizada.telefono;
            personaBuscada.G_S_RH = usuariosActualizada?.G_S_RH;
            personaBuscada.sexo = usuariosActualizada?.sexo;
            personaBuscada.login_correoelectronico = usuariosActualizada?.login_correoelectronico;
            personaBuscada.id_rol = usuariosActualizada.id_rol;



            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.usuarios.FirstOrDefault(x => x.id == id);

            if (personaBuscada != null)
            {
                response = context.usuarios.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }
       }

    }
