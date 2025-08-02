using Microsoft.AspNetCore.Mvc;
using ProyectoWebMVC.Models;
using ProyectoApiRest.Servicios;


namespace ProyectoApiRest.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService servicio;
        public ClientesController(IClienteService ClienteService)
        {
            servicio = ClienteService;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes([FromQuery] string? filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? servicio.ObtenerTodos()
                : servicio.Buscar(filtro);

            return Ok(lista);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult<Cliente> Crear([FromBody] Cliente nuevo)
        {
            servicio.Crear(nuevo);
            return CreatedAtAction(nameof(GetCliente), new { id = nuevo.Identificacion }, nuevo);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Cliente actualizado)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();

            servicio.Editar(actualizado);
            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();

            servicio.Eliminar(id);
            return NoContent();
        }
    }
}
