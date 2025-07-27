using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public interface IClienteService
    {
        List<Cliente> ObtenerTodos();
        List<Cliente> Buscar(string filtro);
        Cliente BuscarPorId(int id);
        void Crear(Cliente nuevo);
        void Editar(Cliente actualizado);
        void Eliminar(int id);
    }
}
