using ProyectoWebMVC.Models;
using static ProyectoWebMVC.Models.Lavado;

namespace ProyectoWebMVC.Datos
{
    public class Lavados
    {
        private static List<Lavado> lavados = new List<Lavado>
        {
            new Lavado
            {
                IdLavado = 0,
                PlacaVehiculo = null,
                IdCliente = 101,
                IdEmpleado = 5,
                Tipo = TipoLavado.Basico,
                Precio = 8000,
                Estado = EstadoLavado.EnProceso
            }
        };

        public List<Lavado> ObtenerTodos()
        {
            return lavados;
        }

        public List<Lavado> Buscar(string filtro)
        {
            return lavados.Where(l =>
                l.IdLavado.ToString().Contains(filtro) ||
                (l.PlacaVehiculo != null && l.PlacaVehiculo.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public Lavado BuscarPorId(int id)
        {
            return lavados.FirstOrDefault(l => l.IdLavado == id);
        }

        public void Crear(Lavado nuevo)
        {
            lavados.Remove(lavados.FirstOrDefault(lavado => lavado.PlacaVehiculo == null));
            lavados.Add(nuevo);
        }

        public void Editar(Lavado actualizado)
        {
            var lavado = lavados.FirstOrDefault(l => l.IdLavado == actualizado.IdLavado);
            if (lavado != null)
            {
                lavado.PlacaVehiculo = actualizado.PlacaVehiculo;
                lavado.IdCliente = actualizado.IdCliente;
                lavado.IdEmpleado = actualizado.IdEmpleado;
                lavado.Tipo = actualizado.Tipo;
                lavado.Precio = actualizado.Precio;
                lavado.Estado = actualizado.Estado;
            }
        }

        public void Eliminar(int id)
        {
            var lavado = lavados.FirstOrDefault(l => l.IdLavado == id);
            if (lavado != null)
            {
                lavados.Remove(lavado);
            }
        }
    }
}
