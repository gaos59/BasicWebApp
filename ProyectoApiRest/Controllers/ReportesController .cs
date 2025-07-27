using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoApiRest.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet("vehiculos-sin-lavado")]
        public ActionResult<IEnumerable<Vehiculo>> GetVehiculosSinLavado()
        {
            var lista = _reporteService.ObtenerVehiculosSinLavadoPorMasDeUnMes();
            return Ok(lista);
        }
    }
}
