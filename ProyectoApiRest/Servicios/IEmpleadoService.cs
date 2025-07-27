using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerTodos();
        List<Empleado> Buscar(string filtro);
        Empleado BuscarPorId(int id);
        void Crear(Empleado nuevo);
        void Editar(Empleado actualizado);
        void Eliminar(int id);
    }
}
