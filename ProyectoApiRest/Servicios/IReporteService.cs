using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public interface IReporteService
    {
        List<Vehiculo> ObtenerVehiculosSinLavadoPorMasDeUnMes();
    }
}
