using ProyectoApiRest.Datos;
using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public class ReporteService : IReporteService
    {
        private readonly DbContexto _context;

        public ReporteService(DbContexto context)
        {
            _context = context;
        }

        public List<Vehiculo> ObtenerVehiculosSinLavadoPorMasDeUnMes()
        {
            var limite = DateTime.Today.AddDays(-30);

            return _context.Vehiculos
                .Where(v => v.UltimaFechaAtencion < limite)
                .ToList();
        }
    }
}
