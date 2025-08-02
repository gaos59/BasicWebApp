using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public interface ILavadoService
    {
        List<Lavado> ObtenerTodos();
        List<Lavado> Buscar(string filtro);
        Lavado BuscarPorId(int id);
        void Crear(Lavado nuevo);
        void Editar(Lavado actualizado);
        void Eliminar(int id);
    }
}
