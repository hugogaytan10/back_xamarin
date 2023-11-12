using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AppDbContext context;
        public LoginController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<VehiculosController>
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return context.login.ToList();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{correoelectronico}")]
        public Login Get(string correoelectronico)
        {
            return context.login.FirstOrDefault(x => x.correoelectronico == correoelectronico);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public int Post1([FromBody] Login login)
        {
            return context.login.Add(login).Context.SaveChanges();
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest("El objeto Login no puede ser nulo.");
            }

            var existingLogin = context.login.FirstOrDefault(x => x.correoelectronico == login.correoelectronico);

            if (existingLogin == null)
            {
                return NotFound("El correo electrónico no está registrado.");
            }

            if (existingLogin.contrasena == login.contrasena)
            {
                // Puedes devolver un token aquí si estás utilizando autenticación basada en token
                return Ok("Inicio de sesión exitoso.");
            }

            return Unauthorized("La contraseña ingresada es incorrecta.");
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{correoelectronico}")]
        public int Put(string correoelectronico, [FromBody] Login loginActualizada)
        {
            Login? vehiculoBuscado = context.login.FirstOrDefault(x => x.correoelectronico == correoelectronico);
            if (vehiculoBuscado == null) { return 0; }
            vehiculoBuscado.contrasena = loginActualizada?.contrasena;
           

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{correoelectronico}")]
        public int Delete(string correoelectronico)
        {
            int response = 0;

            var vehiculoBuscado = context.login.FirstOrDefault(x => x.correoelectronico == correoelectronico);

            if (vehiculoBuscado != null)
            {
                response = context.login.Remove(vehiculoBuscado).Context.SaveChanges();
            }

            return response;
        }
    }
}
