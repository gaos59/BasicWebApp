using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoApiRest.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoApiRest.Controllers
{
    [Route("api/Vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService servicio;
        public VehiculosController(IVehiculoService vehiculoService)
        {
            servicio = vehiculoService;
        }
        // GET: api/<VehiculosController>
        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> GetVehiculos([FromQuery] string? filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? servicio.ObtenerTodos()
                : servicio.Buscar(filtro);

            return Ok(lista);
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{placa}")]
        public ActionResult<Vehiculo> GetVehiculo(string placa)
        {
            var vehiculo = servicio.BuscarPorPlaca(placa);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public ActionResult<Vehiculo> Crear([FromBody] Vehiculo nuevo)
        {
            servicio.Crear(nuevo);
            return CreatedAtAction(nameof(GetVehiculo), new { placa = nuevo.Placa }, nuevo);
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{placa}")]
        public IActionResult Editar(string placa, [FromBody] Vehiculo actualizado)
        {
            var vehiculo = servicio.BuscarPorPlaca(placa);
            if (vehiculo == null) return NotFound();

            servicio.Editar(actualizado);
            return NoContent();
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{placa}")]
        public IActionResult Eliminar(string placa)
        {
            var vehiculo = servicio.BuscarPorPlaca(placa);
            if (vehiculo == null) return NotFound();

            servicio.Eliminar(placa);
            return NoContent();
        }
    }
}
