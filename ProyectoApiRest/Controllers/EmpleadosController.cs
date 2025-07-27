using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoApiRest.Servicios;


namespace ProyectoApiRest.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService servicio;
        public EmpleadosController(IEmpleadoService EmpleadoService)
        {
            servicio = EmpleadoService;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> GetEmpleados([FromQuery] string? filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? servicio.ObtenerTodos()
                : servicio.Buscar(filtro);

            return Ok(lista);
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public ActionResult<Empleado> GetEmpleado(int id)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public ActionResult<Empleado> Crear([FromBody] Empleado nuevo)
        {
            servicio.Crear(nuevo);
            return CreatedAtAction(nameof(GetEmpleado), new { id = nuevo.Cedula }, nuevo);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Empleado actualizado)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();

            servicio.Editar(actualizado);
            return NoContent();
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();

            servicio.Eliminar(id);
            return NoContent();
        }
    }
}
