using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public interface IReporteService
    {
        List<Vehiculo> ObtenerVehiculosSinLavadoPorMasDeUnMes();
    }
}
