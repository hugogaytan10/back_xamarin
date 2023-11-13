using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movilapispruebas.Data;
using movilapispruebas.Models;

namespace movilapispruebas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehiculosController : ControllerBase
	{
		private readonly AppDbContext context;

		public VehiculosController(AppDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IEnumerable<Vehiculos> Get()
		{
			return context.vehiculos.ToList();
		}

		[HttpGet("{placa}")]
		public ActionResult<Vehiculos> Get(string placa)
		{
			var vehiculo = context.vehiculos.FirstOrDefault(x => x.placa == placa);
			if (vehiculo == null)
			{
				return NotFound(); // 404 Not Found
			}
			return vehiculo;
		}

		[HttpPost]
		public IActionResult Post([FromBody] Vehiculos vehiculo)
		{
			context.vehiculos.Add(vehiculo);
			context.SaveChanges();
			return CreatedAtAction(nameof(Get), new { placa = vehiculo.placa }, vehiculo);
		}

		[HttpPut("{placa}")]
		public IActionResult Put(string placa, [FromBody] Vehiculos vehiculoActualizado)
		{
			try
			{
				var vehiculoBuscado = context.vehiculos.FirstOrDefault(x => x.placa == placa);
				if (vehiculoBuscado == null)
				{
					return NotFound(); // 404 Not Found
				}

				vehiculoBuscado.marca = vehiculoActualizado.marca;
				vehiculoBuscado.modelo = vehiculoActualizado.modelo;
				vehiculoBuscado.color = vehiculoActualizado.color;
				vehiculoBuscado.id_usuario = vehiculoActualizado.id_usuario;

				context.SaveChanges();
				return NoContent(); // 204 No Content
			}
			catch (Exception)
			{
				return BadRequest(); // 400 Bad Request
			}
		}

		[HttpDelete("{placa}")]
		public IActionResult Delete(string placa)
		{
			var vehiculoBuscado = context.vehiculos.FirstOrDefault(x => x.placa == placa);
			if (vehiculoBuscado == null)
			{
				return NotFound(); // 404 Not Found
			}

			context.vehiculos.Remove(vehiculoBuscado);
			context.SaveChanges();
			return NoContent(); // 204 No Content
		}
	}

}
