using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoApiRest.Servicios;

namespace ProyectoApiRest.Controllers
{
    [Route("api/Lavados")]
    [ApiController]
    public class LavadosController : ControllerBase
    {
        private readonly ILavadoService servicio;
        public LavadosController(ILavadoService LavadoService)
        {
            servicio = LavadoService;
        }
        // GET: api/<LavadosController>
        [HttpGet]
        public ActionResult<IEnumerable<Lavado>> GetLavados([FromQuery] string? filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? servicio.ObtenerTodos()
                : servicio.Buscar(filtro);

            return Ok(lista);
        }

        // GET api/<LavadosController>/5
        [HttpGet("{id}")]
        public ActionResult<Lavado> GetLavado(int id)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();
            return Ok(lavado);
        }

        // POST api/<LavadosController>
        [HttpPost]
        public ActionResult<Lavado> Crear([FromBody] Lavado nuevo)
        {
            servicio.Crear(nuevo);
            return CreatedAtAction(nameof(GetLavado), new { id = nuevo.IdLavado }, nuevo);
        }

        // PUT api/<LavadosController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Lavado actualizado)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();

            servicio.Editar(actualizado);
            return NoContent();
        }

        // DELETE api/<LavadosController>/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();

            servicio.Eliminar(id);
            return NoContent();
        }
    }
}
