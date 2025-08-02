using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public class ReporteService : IReporteService
    {
        private readonly IVehiculoService _vehiculoService;

        public ReporteService(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        public List<Vehiculo> ObtenerVehiculosSinLavadoPorMasDeUnMes()
        {
            var todos = _vehiculoService.ObtenerTodos();
            var limite = DateTime.Today.AddDays(-30);

            return todos
                .Where(v => v.UltimaFechaAtencion < limite)
                .ToList();
        }
    }
}
