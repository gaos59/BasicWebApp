using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerTodos();
        List<Vehiculo> Buscar(string filtro);
        Vehiculo BuscarPorPlaca(string placa);
        void Crear(Vehiculo nuevo);
        void Editar(Vehiculo actualizado);
        void Eliminar(string placa);
    }
}
